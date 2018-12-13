using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCaseSystem_KokovinMedvedevStartsev
{
    class MetaControllContext
    {
        public ModelMetaDataContainer context;
        SqlConnection conn;
        

        public MetaControllContext(string connectionStr)
        {


            context = new ModelMetaDataContainer();
            if (connectionStr is null)
            {
                this.conn = context.Database.Connection as SqlConnection;
            }
            else
            {
                this.conn = new SqlConnection(connectionStr);
                context.Database.Connection.ConnectionString = connectionStr;
            }
        }
        
        //Сreate, read, update, download
        #region CRUD
        public void CreateDB()
        {
            Table[] tables = context.TableSet.ToArray();
            Attribute[] attributes = context.AttributeSet.ToArray();
            Relation[] relations = context.RelationSet.ToArray();

            conn.Open();

            SqlCommand command = new SqlCommand(" ");

            command.Connection = conn;

            string[] tablesCreation = new string[tables.Length];

            //Добавляет поля для создания ключа
            for (int i = 0; i < tables.Length; i++)
            {
                //TODO: разобраться с SQL CREATE TABLE + понять, как создавать связи
                //Поменять типы в схеме БД
                //Надо ли делать новую БД?

                string primaryKeys = "CONSTRAINT PK_" + tables[i].Name +" PRIMARY KEY (" + tables[i].Name + "Id";
                string indexed = "";
                tablesCreation[i] = "CREATE TABLE " + tables[i].Name + "(";

                Attribute[] tablesAttributes = (from temp in attributes where temp.Table.Name == tables[i].Name select temp).ToArray();

                //Генерируем айди - ключ
                tablesCreation[i] += tables[i].Name + "Id int IDENTITY(1,1)";

                for (int j = 0; j < tablesAttributes.Length; j++)
                {

                    tablesCreation[i] += tablesAttributes[j].Name + " ";
                    tablesCreation[i] += tablesAttributes[j].Type + " ";

                    if (tablesAttributes[j].Length != 0)
                        tablesCreation[i] += "(" + tablesAttributes[j].Length.ToString() + ")" + " ";

                    if (!tablesAttributes[j].IsNull)
                        tablesCreation[i] += "NOT NULL" + " ";

                    if (tablesAttributes[j].IsKey)
                        primaryKeys += ", " + tablesAttributes[j].Name;

                    tablesCreation[i] += ",";

                    if (attributes[j].Indexed)
                        indexed = " IF NOT EXISTS(SELECT * FROM sys.indexes WHERE Name =" + "'" + "idx_" + tables[i].Name + "_" + attributes[j].Name + "') " +
                            "CREATE INDEX " + "idx_" + tables[i].Name + "_" + tablesAttributes[j].Name +
                        " ON " + tables[i].Name + "(" + tablesAttributes[j].Name + "); ";
                }

                tablesCreation[i] += primaryKeys + ")); ";
                tablesCreation[i] += indexed;


            }

            //Пример:
            ///
            ///     CREATE TABLE Persons (
            ///     PersonsId  int IDENTITY(1,1),                       - Автогенерируемый ID
            ///     LastName varchar(255) NOT NULL,
            ///     FirstName varchar(255),
            ///     Age int,
            ///     CONSTRAINT PK_Persons PRIMARY KEY(PersonsId)        - Ключ задаётся
            ///     );
            /// 
            ///     CREATE INDEX idx_Persons_LastName
            ///     ON Persons(LastName);
            /// 
            ///


            command.ExecuteNonQuery();
            conn.Close();
        }

        //Обновляет первичный ключ таблицы в БД
        public void RefreshTablePrimaryKey(Table table)
        {
            conn.Open();

            SqlCommand command = new SqlCommand(" ");

            command.Connection = conn;
            Attribute[] primaryAttributes = (from temp in context.AttributeSet
                                             where temp.IsKey && temp.Table.Name == table.Name
                                             select temp).ToArray();

            command.CommandText = "ALTER TABLE " + table.Name + "DROP PRIMARY KEY; ";

            command.CommandText += "ALTER TABLE " + table.Name +
                                  " ADD CONSTRAINT PK_" + table.Name + " PRIMARY KEY (" + table.Name + "Id";

            foreach (var temp in primaryAttributes)
                command.CommandText += "," + temp.Name;

            command.CommandText += ");";

            //Если есть ключ LastName, то будет
            //ALTER TABLE Persons
            //ADD CONSTRAINT PK_Persons PRIMARY KEY(PersonsId, LastName);

            command.ExecuteNonQuery();
            conn.Close();
        }

        #region Column
        public void AddColumn(Table table, Attribute attribute)
        {
            conn.Open();

            SqlCommand command = new SqlCommand(" ");

            command.Connection = conn;
            command.CommandText = "ALTER TABLE " + table.Name +
                                  " ADD " + attribute.Name +
                                  " " + attribute.Type + " ";

            if (attribute.Length != 0)
                command.CommandText += "(" + attribute.Length.ToString() + ")";

            command.CommandText += " ";

            if (!attribute.IsNull)
                command.CommandText += "NOT NULL";

            command.CommandText += "; ";



            if (attribute.Indexed)
                command.CommandText += "CREATE INDEX " + "idx_" + table.Name + "_" + attribute.Name +
                " ON " + table.Name + "(" + attribute.Name + "); ";


            command.ExecuteNonQuery();
            conn.Close();
            
            context.AttributeSet.Add(attribute);
            context.SaveChanges();
        }

        public void EditColumn(Table table, Attribute oldAttribute, Attribute newAttribute)
        {
            conn.Open();

            SqlCommand command = new SqlCommand(" ");

            command.Connection = conn;

            command.CommandText = "sp_rename" +
                                  "'" + table.Name + "." + oldAttribute.Name + "'," +
                                  "'" + newAttribute.Name + "', 'COLUMN; " +
                                  "GO";

            command.CommandText += "ALTER TABLE " + table.Name +
                                  " ALTER COLUMN " + newAttribute.Name + " " + newAttribute.Type;

            if (newAttribute.Length != 0)
                command.CommandText += "(" + newAttribute.Length.ToString() + ")";

            command.CommandText += " ";

            if (!newAttribute.IsNull)
                command.CommandText += "NOT NULL";

            command.CommandText += "; ";

            if (newAttribute.Indexed)
                command.CommandText += "CREATE INDEX " + "idx_" + table.Name + "_" + newAttribute.Name +
                " ON " + table.Name + "(" + newAttribute.Name + "); ";

            
            command.ExecuteNonQuery();
            conn.Close();

            context.Entry(oldAttribute).CurrentValues.SetValues(newAttribute);
            context.SaveChanges();
        }
        
        public void RemoveColumn(Table table, Attribute attribute)
        {
            conn.Open();

            SqlCommand command = new SqlCommand(" ");

            command.Connection = conn;

            command.CommandText = "ALTER TABLE " + table.Name + "DROP COLUMN " + attribute.Name + " ;";

            command.ExecuteNonQuery();
            conn.Close();

            context.AttributeSet.Remove(attribute);
            context.SaveChanges();
        }

        #endregion
        
        #region Table
        public void AddTable(Table table)
        {
            conn.Open();

            SqlCommand command = new SqlCommand(" ");

            command.Connection = conn;
            ///TODO: доделать запросы
            //CREATE TABLE TableName (TableNameId int IDENTITY(1,1) PRIMARY KEY);
            command.CommandText = "CREATE TABLE " + table.Name + "(" + table.Name + "Id int IDENTITY(1,1) PRIMARY KEY);";

            command.Connection = conn;
            command.ExecuteNonQuery();
            conn.Close();

            context.TableSet.Add(table);
            context.SaveChanges();
        }
        public void EditTable(Table table, string name)
        {
            conn.Open();

            SqlCommand command = new SqlCommand(" ");

            command.Connection = conn;
            command.Connection = conn;
            //sp_rename 'supplier', 'vendor';
            command.CommandText = "sp_rename '" + table.Name + "', '" + name + "';";


            command.ExecuteNonQuery();
            conn.Close();
            context.Entry(context.TableSet.Find(table.Id)).CurrentValues.SetValues(table);
            context.SaveChanges();
        }
        public void RemoveTable(Table table)
        {
            conn.Open();

            SqlCommand command = new SqlCommand(" ");

            command.Connection = conn;
            //DROP TABLE TableName;
            command.CommandText = "DROP TABLE " + table.Name + ";";


            command.ExecuteNonQuery();
            conn.Close();

            context.TableSet.Remove(table);
            context.SaveChanges();
            
        }
        #endregion

        #region Relation
        public void AddRelation(Relation relation)
        {
            SqlCommand command = new SqlCommand(" ");
            conn.Open();

            command.Connection = conn;
            string tableName = relation.Table.Name;
            string type = relation.Type;
            string tableBname = context.TableSet.Find(relation.ConnectedTableID).Name;

            if (type.Equals("child"))
                command.CommandText = "ALTER TABLE " + tableName +
                    " ADD FOREIGN KEY("+ tableBname + "Id) REFERENCES " + tableBname + "("+ tableBname + "Id);";

            if (type.Equals("parent"))
                ;//Добавляется FOREIGN KEY у чайлда

            if (type.Equals("equal"))
                ;//Создавать новую таблицу 

            command.ExecuteNonQuery();
            conn.Close();

            context.RelationSet.Add(relation);
            context.SaveChanges();

        }
        public void RemoveRelation(Relation relation)
        {
            ///
            ///
            /// ALTER TABLE Orders
            /// DROP FOREIGN KEY FK_PersonOrder;
            /// 
            ///
            conn.Open();

            SqlCommand command = new SqlCommand(" ");

            command.Connection = conn;
            string tableName = relation.Table.Name;
            string type = relation.Type;
            string tableBname = context.TableSet.Find(relation.ConnectedTableID).Name;

            if (type.Equals("child"))
                command.CommandText = "ALTER TABLE " + tableName +
                                      " DROP FOREIGN KEY " + tableBname + "Id";

            if (type.Equals("parent"))
                ;//Добавляется FOREIGN KEY у чайлда

            if (type.Equals("equal"))
                ;//Создавать новую таблицу 

            command.ExecuteNonQuery();
            conn.Close();


            context.RelationSet.Remove(relation);
            context.SaveChanges();
        }
        #endregion

        //Добавить удаление аттрибута
        //Добваить удаление таблицы
        //Добавить удаление отношения

        //Добавить обновление???
        #endregion

        //Проверка, можно ли сделать что-то с базой данных
        //Например, можно ли добавить таблицу с таким именем (проверка на существование такой таблицы в бд)
        #region Action legallity
        public bool NewTableIsLegal(Table table)
        {
            return !context.TableSet.Contains(table);
        }
        #endregion
    }
}

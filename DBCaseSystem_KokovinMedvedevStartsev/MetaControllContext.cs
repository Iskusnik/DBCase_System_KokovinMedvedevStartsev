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
        ModelMetaDataContainer context;
        string connectionStr;


        public MetaControllContext(string connectionStr)
        {
            context = new ModelMetaDataContainer();
            this.connectionStr = connectionStr;
        }

        public void CreateDB()
        {
            Table[] tables = context.TableSet.ToArray();
            Attribute[] attributes = context.AttributeSet.ToArray();
            Relation[] relations = context.RelationSet.ToArray();

            SqlConnection conn = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand(" ");

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



        public void AddColumn(Table table, Attribute attribute)
        {
            SqlConnection conn = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand(" ");

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
        }

        public void EditColumn(Table table, Attribute attribute)
        {
            SqlConnection conn = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand(" ");

            command.CommandText = "ALTER TABLE " + table.Name +
                                  " DROP COLUMN " + attribute.Name;

            command.ExecuteNonQuery();
            conn.Close();
        }
        
        public void RemoveColumn(Table table, Attribute attribute)
        {
            SqlConnection conn = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand(" ");


            command.CommandText = "ALTER TABLE " + table.Name + "DROP COLUMN " + attribute.Name + " ;";

            command.ExecuteNonQuery();
            conn.Close();
        }

        //Обновляет первичный ключ таблицы в БД
        public void RefreshTablePrimaryKey(Table table)
        {
            SqlConnection conn = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand(" ");

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



        public void AddTable(Table table)
        {
            SqlConnection conn = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand(" ");



            command.ExecuteNonQuery();
            conn.Close();
        }
        public void EditTable(Table table)
        {
            SqlConnection conn = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand(" ");



            command.ExecuteNonQuery();
            conn.Close();
        }
        public void RemoveTable(Table table)
        {
            SqlConnection conn = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand(" ");



            command.ExecuteNonQuery();
            conn.Close();
        }


        public void AddRelation(Relation relation)
        {
            SqlConnection conn = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand(" ");



            command.ExecuteNonQuery();
            conn.Close();
        }
        public void RemoveRelation(Relation relation)
        {
            SqlConnection conn = new SqlConnection(connectionStr);
            SqlCommand command = new SqlCommand(" ");



            command.ExecuteNonQuery();
            conn.Close();
        }

        //Добавить удаление аттрибута
        //Добваить удаление таблицы
        //Добавить удаление отношения

        //Добавить обновление???
    }
}

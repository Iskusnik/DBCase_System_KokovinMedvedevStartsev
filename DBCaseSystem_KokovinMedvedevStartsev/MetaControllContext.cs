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

                string primaryKeys = "PRIMARY KEY (" + tables[i].Name + "Id";
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
                        tablesCreation[i] += "("+ tablesAttributes[j].Length.ToString() + ")" + " ";

                    if (!tablesAttributes[j].IsNull)
                        tablesCreation[i] +=  "NOT NULL" + " ";

                    if (tablesAttributes[j].IsKey)
                        primaryKeys += ", " + tablesAttributes[j].Name;
                    
                        tablesCreation[i] += ",";

                    indexed = "CREATE INDEX " + "idx_" + tables[i].Name + "_" + tablesAttributes[j].Name +
                    " ON " + tables[i].Name + "(" + tablesAttributes[j].Name + "); ";
                }

                tablesCreation[i] += primaryKeys + ")); ";
                tablesCreation[i] += indexed;


            }

            //Пример:
            ///
            ///     CREATE TABLE Persons (
            ///     PersonsId  int IDENTITY(1,1),           - Автогенерируемый ключ - айди
            ///     LastName varchar(255) NOT NULL,
            ///     FirstName varchar(255),
            ///     Age int,
            ///     PRIMARY KEY(PersonsId)                  - Ключ задаётся
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
        { }
        public void RemoveColumn(Table table, Attribute attribute)
        { }

        public void AddTable(Table table)
        { }
        public void RemoveTable(Table table)
        { }


        public void AddRelation(Relation relation)
        { }
        public void RemoveRelation(Relation relation)
        { }

        //Добавить удаление аттрибута
        //Добваить удаление таблицы
        //Добавить удаление отношения

        //Добавить обновление???
    }
}

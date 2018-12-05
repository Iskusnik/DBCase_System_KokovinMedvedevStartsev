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



            for (int i = 0; i < tables.Length; i++)
            {
                //TODO: разобраться с SQL CREATE TABLE + понять, как создавать связи
                tablesCreation[i] = "CREATE TABLE " + tables[i].Name;

                Attribute[] tablesAttributes = (from temp in attributes where temp.Table.Name == tables[i].Name select temp).ToArray();

                for (int j = 0; j < tablesAttributes.Length; j++)
                    tablesCreation[i] += tablesAttributes[j].Name;

                //В процессе

            }



            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}

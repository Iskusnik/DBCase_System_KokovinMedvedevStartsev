using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBCaseSystem_KokovinMedvedevStartsev.Queries
{
    /// <summary>
    /// Модуль, обрабатвающий работу с запросами <see cref="Query"/>
    /// </summary>
    public class QueryHandler
    {
        /// <summary>
        /// Контейнер данных
        /// </summary>
        ModelMetaDataContainer ModelMetaDataContainer;
        public QueryHandler(ModelMetaDataContainer cont)
        {
            ModelMetaDataContainer = cont;
        }

        /// <summary>
        /// Представление запроса <see cref="Query"/> в качестве выполняемой строки SQL
        /// </summary>
        /// <param name="input">Преобразуемый запрос</param>
        /// <returns>Строка SQL</returns>
        public string QueryToSQLString(Query input)
        {
            string[] tokens = input.QueryText.Split();
            string result = string.Empty;
            bool search = false;
            for (int i = 0; i < tokens.Length; i++)
            {
                if (search)
                {
                    int id = int.Parse(tokens[i]);
                    var obj = ModelMetaDataContainer.QueryObjectSet.Find(id);
                    result += ConvertFromQueryObject(obj);
                }
                else
                {
                    if (tokens[i] == QueryInsertPrefix)
                        search = true;
                    else
                    {
                        result += tokens[i] + " ";
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Получение строкового представления <see cref="QueryObject"/>
        /// </summary>
        /// <param name="queryObject"></param>
        /// <returns></returns>
        public string ConvertFromQueryObject(QueryObject queryObject)
        {
            switch (queryObject.Type)
            {
                case QueryObjectType.Attribute:
                    var atr = ModelMetaDataContainer.AttributeSet.Find(queryObject.ObjectID);
                    return atr.Name;
                case QueryObjectType.Query:
                    var query = ModelMetaDataContainer.QuerySet.Find(queryObject.ObjectID);
                    return QueryToSQLString(query);
                case QueryObjectType.Table:
                    var table = ModelMetaDataContainer.TableSet.Find(queryObject.ObjectID);
                    return table.Name;
                default: throw new Exception("Неожиданное значение queryObject.Type=" + queryObject.Type);
            }
        }


        /// <summary>
        /// Токен вставки в запрос
        /// <example>"/%/ 1" означает вставку представления объекта <see cref="QueryObject"/> 
        /// c <see cref="QueryObject.Id" = 1/></example>
        /// </summary>
        public static string QueryInsertPrefix = "/%/";

        /// <summary>
        /// Получить возможные варианты источников для запросов
        /// <para>Это либо <see cref="Table"/>, либо <see cref="Query"/></para>
        /// <para>Представляются в FROM</para>
        /// </summary>
        /// <returns>Список вариантов источников</returns>
        public List<object> GetSources()
        {
            List<object> result = new List<object>();
            foreach (var t in ModelMetaDataContainer.TableSet)
            {
                result.Add(t);
            }
            foreach (var q in ModelMetaDataContainer.QuerySet)
            {
                result.Add(q);
            }
            return result;
        }

        /// <summary>
        /// Получение атрибутов <see cref="Attribute"/> таблицы <see cref="Table"/>
        /// </summary>
        /// <param name="table">Таблица</param>
        /// <returns>Атрибуты таблицы</returns>
        public List<Attribute> GetTableAttribute(Table table)
        {
            return table.Attribute.ToList();
        }

        /// <summary>
        /// Получение атрибутов <see cref="QueryOutput"/> резудьтатов запросов <see cref="Query"/>
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <returns>Атрибуты результатов</returns>
        public List<QueryOutput> GetQueryOutputs(Query query)
        {
            return query.QueryOutput.ToList();
        }
    }
}

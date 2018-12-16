using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBCaseSystem_KokovinMedvedevStartsev.Queries
{
    /// <summary>
    /// Репозиторий работы с запросами <see cref="Query"/>
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
        
        /// <summary>
        /// Получение источника для запроса по имени
        /// </summary>
        /// <param name="Name">Имя источника</param>
        /// <returns>Источник - <see cref="Table"/> или <see cref="Query"/></returns>
        public object RestoreSource(string Name)
        {
            Table table = ModelMetaDataContainer.TableSet
                .Where(x => x.Name == Name)
                .Select(x => x)
                .SingleOrDefault();
            if (table == null)
            {
                Query query = ModelMetaDataContainer.QuerySet
                    .Where(x => x.Name == Name)
                    .Select(x => x)
                    .SingleOrDefault();
                return query;
            }
            else return table;
        }

        /// <summary>
        /// Получить атрибут по его таблице и названию
        /// </summary>
        /// <param name="table">таблица атрибута</param>
        /// <param name="Name">название атрибута</param>
        /// <returns>Атрибут</returns>
        public Attribute GetAttribute(Table table, string Name)
        {
            return ModelMetaDataContainer.AttributeSet
                .Where(x => x.Name == Name && x.Table.Id == table.Id)
                .Select(x => x)
                .SingleOrDefault();
        }
        
        /// <summary>
        /// Получить атрибут результата запроса по его запросу и названию
        /// </summary>
        /// <param name="query">запрос атрибута результата</param>
        /// <param name="Name">название атрибута резульатта</param>
        /// <returns>Атрибут результата</returns>
        public QueryOutput GetQueryOutput(Query query, string Name)
        {
            return ModelMetaDataContainer.QueryOutputSet
                .Where(x => x.Name == Name && x.Query.Id == query.Id)
                .Select(x => x)
                .SingleOrDefault();
        }

        /// <summary>
        /// Получение модельного представления по статусу управляющих элементов
        /// </summary>
        /// <param name="selectedSources">Выбранные источники</param>
        /// <param name="queryControls">Коллекция усправляющих элементов</param>
        /// <param name="isAggregate">Является ли запрос итоговым</param>
        /// <returns>Модельное представление запроса</returns>
        public QueryConstractState ConstractState(IEnumerable<object> selectedSources, 
            IEnumerable<QueryControlPack> queryControls, bool isAggregate)
        {
            QueryConstractState queryConstractState = new QueryConstractState(selectedSources.ToList(),isAggregate);
            if (isAggregate) {
                foreach (var item in queryControls)
                {
                    var conv = (QueryControlPackAgr)item;
                    var source = RestoreSource(conv.Source);
                    QueryAttributeInfoAgr queryAttributeInfoAgr = new QueryAttributeInfoAgr
                    {
                        Show = conv.Show,
                        QuerySortType = conv.Sort,
                        Func = conv.Func
                    };
                    foreach (var ifText in conv.If)
                    {
                        //возможно нужна верификация
                        if (string.IsNullOrEmpty(ifText)) continue;
                        queryAttributeInfoAgr.Where.Add(ifText);
                    }
                    if (source == null)
                    {
                        //исключительная ситуация, пока не знаю, как обработать
                        continue;
                    }
                    if (source is Table table)
                    {
                        var Attribute = GetAttribute(table, conv.Attribute);
                        if (Attribute == null)
                        {
                            //исключительная ситуация, пока не знаю, как обработать
                            continue;
                        }
                        queryConstractState.AttributesInfo.Add(Attribute, queryAttributeInfoAgr);
                    }
                    else if (source is Query query)
                    {
                        var QueryOutput = GetQueryOutput(query, conv.Attribute);
                        if (QueryOutput == null)
                        {
                            //исключительная ситуация, пока не знаю, как обработать
                            continue;
                        }
                        queryConstractState.QueryAttributesInfo.Add(QueryOutput, queryAttributeInfoAgr);
                    }
                    else
                    {
                        //исключительная ситуация, не знаю, как обработать
                        continue;
                    }
                }
            }
            else
            {
                foreach (var item in queryControls)
                {
                    var conv = (QueryControlPackGen)item;
                    var source = RestoreSource(conv.Source);
                    QueryAttributeInfo
 queryAttributeInfoAgr = new QueryAttributeInfo
                    {
                        Show = conv.Show,
                        QuerySortType = conv.Sort
                    };
                    foreach (var ifText in conv.If)
                    {
                        //возможно нужна верификация
                        if (string.IsNullOrEmpty(ifText)) continue;
                        queryAttributeInfoAgr.Where.Add(ifText);
                    }
                    if (source == null)
                    {
                        //исключительная ситуация, пока не знаю, как обработать
                        continue;
                    }
                    if (source is Table table)
                    {
                        var Attribute = GetAttribute(table, conv.Attribute);
                        if (Attribute == null)
                        {
                            //исключительная ситуация, пока не знаю, как обработать
                            continue;
                        }
                        queryConstractState.AttributesInfo.Add(Attribute, queryAttributeInfoAgr);
                    }
                    else if (source is Query query)
                    {
                        var QueryOutput = GetQueryOutput(query, conv.Attribute);
                        if (QueryOutput == null)
                        {
                            //исключительная ситуация, пока не знаю, как обработать
                            continue;
                        }
                        queryConstractState.QueryAttributesInfo.Add(QueryOutput, queryAttributeInfoAgr);
                    }
                    else
                    {
                        //исключительная ситуация, не знаю, как обработать
                        continue;
                    }
                }
            }
            return queryConstractState;
        }


        /// <summary>
        /// Начало создания запроса
        /// </summary>
        /// <param name="selectedSources">Выбранные источники запроса</param>
        /// <param name="queryControls">Управляющие элементы</param>
        /// <param name="isAggregate">Является ли запрос итоговым</param>
        public void StartCreateQuery(IEnumerable<object> selectedSources,
            IEnumerable<QueryControlPack> queryControls, bool isAggregate)
        {
            var State = ConstractState(selectedSources, queryControls, isAggregate);

            //Данный стейт надо будет обработать:
            //1. Создать объекты QueryObject
            //2. Построить строку
            //3. Создать Query и записать
        }
    }
}

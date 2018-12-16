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
            List<object> result = new List<object>(); /*
            foreach (var t in ModelMetaDataContainer.TableSet)
            {
                result.Add(t);
            }
            foreach (var q in ModelMetaDataContainer.QuerySet)
            {
                result.Add(q);
            }
            */
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
        /// <param name="queryControls">Коллекция управляющих элементов</param>
        /// <param name="linkCombos">Колекция управляющих элементов связей таблиц</param>
        /// <param name="isAggregate">Является ли запрос итоговым</param>
        /// <returns>Модельное представление запроса</returns>
        public QueryConstractState ConstractState(IEnumerable<object> selectedSources, 
            IEnumerable<QueryControlPack> queryControls,
            bool isAggregate)
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
        /// Добавление состыковок таблиц в стэйт
        /// </summary>
        /// <param name="queryConstractState">изменяемый стэйт</param>
        /// <param name="linkCombos">Колекция управляющих элементов связей таблиц</param>
        public void AddLinksToState(ref QueryConstractState queryConstractState, IEnumerable<LinkCombos> linkCombos)
        {
            foreach (var item in linkCombos)
            {
                var source1 = RestoreSource(item.Source1);
                if (source1 == null)
                {
                    //исключительная ситуация, пока не знаю, как обработать
                    continue;
                }
                var source2 = RestoreSource(item.Source2);
                if (source2 == null)
                {
                    //исключительная ситуация, пока не знаю, как обработать
                    continue;
                }

                object Attribute1, Attribute2;

                if (source1 is Table table)
                {
                    Attribute1 = GetAttribute(table, item.Attribute1);
                    if (Attribute1 == null)
                    {
                        continue;
                    }
                }
                else if (source1 is Query query)
                {
                    Attribute1 = GetQueryOutput(query, item.Attribute1);
                    if (Attribute1 == null)
                    {
                        continue;
                    }
                }
                else
                {
                    //исключительная ситуация, пока не знаю, как обработать
                    continue;
                }

                if (source2 is Table table2)
                {
                    Attribute2 = GetAttribute(table2, item.Attribute2);
                    if (Attribute2 == null)
                    {
                        continue;
                    }
                }
                else if (source2 is Query query2)
                {
                    Attribute2 = GetQueryOutput(query2, item.Attribute2);
                    if (Attribute2 == null)
                    {
                        continue;
                    }
                }
                else
                {
                    //исключительная ситуация, пока не знаю, как обработать
                    continue;
                }

                Link link;
                if (Attribute1 is Attribute)
                {
                    if (Attribute2 is Attribute)
                    {
                        link = new Link((Attribute)Attribute1, (Attribute)Attribute2);
                    }
                    else
                    {
                        link = new Link((Attribute)Attribute1, (QueryOutput)Attribute2);
                    }
                }
                else
                {
                    if (Attribute2 is Attribute)
                    {
                        link = new Link((Attribute)Attribute2, (QueryOutput)Attribute1);
                    }
                    else
                    {
                        link = new Link((QueryOutput)Attribute1, (QueryOutput)Attribute2);
                    }
                }

                queryConstractState.LinkList.Add(link);

            }
        }



        /// <summary>
        /// Начало создания запроса
        /// </summary>
        /// <param name="selectedSources">Выбранные источники запроса</param>
        /// <param name="queryControls">Управляющие элементы</param>  
        /// <param name="linkCombos">Колекция управляющих элементов связей таблиц</param>
        /// <param name="isAggregate">Является ли запрос итоговым</param>
        public void StartCreateQuery(IEnumerable<object> selectedSources,
            IEnumerable<QueryControlPack> queryControls,
            IEnumerable<LinkCombos> linkCombos,
            bool isAggregate)
        {
            var State = ConstractState(selectedSources, queryControls, isAggregate);
            if (State == null) return;
            AddLinksToState(ref State, linkCombos);

            Query query = new Query();
            query = ModelMetaDataContainer.QuerySet.Add(query);
            ModelMetaDataContainer.SaveChanges();

            CreateQueryObjects(State, query);

            string QueryText = State.IsAggregate ? CreateQueryTextAgr(State, query) : CreateQueryTextGeneral(State,query);

            query.QueryText = QueryText;
            ModelMetaDataContainer.SaveChanges();

            if (State.IsAggregate) CreateQueryOutputAgr(State, query); else CreateQueryOutput(State, query);
            
        }

        #region QueryText
        /// <summary>
        /// Создание хранимого текста общего запроса
        /// </summary>
        /// <param name="State">Стэйт запроса</param>
        /// <param name="query">Текущий объект запроса</param>
        /// <returns>Созданный текст</returns>
        public string CreateQueryTextGeneral(QueryConstractState State, Query query)
        {
            string SQL = "SELECT ";
            #region SELECT
            bool first = true;
            foreach (var item in State.AttributesInfo)
            {
                if (item.Value.Show)
                {
                    SQL += (!first ? ", " : string.Empty) + QueryInsertPrefix +" "+ GetQueryObjectId(item.Key, query);
                    first = false;
                }
            }
            foreach (var item in State.QueryAttributesInfo)
            {
                if (item.Value.Show)
                {
                    SQL += (!first ? ", " : string.Empty) + QueryInsertPrefix +" "+ GetQueryObjectId(item.Key, query);
                    first = false;
                }
            }
            #endregion SELECT
            #region FROM
            SQL += "\n FROM ";
            first = true;
            //TO DO:Необходимо сделать DFS по графу, представленному в виде списка рёбер State.LinkList
            #endregion FROM
            #region WHERE
            SQL += "\n ";

            first = true;
            foreach (var item in State.AttributesInfo)
            {
                if (item.Value.Where.Count == 0) continue;
                string localWhere = string.Empty;
                var QueryObject = GetQueryObjectId(item.Key, query);
                if (first) SQL += " WHERE (";
                else SQL += " AND (";
                bool localFirst = true;
                foreach (var where in item.Value.Where)
                {
                    localWhere += (!localFirst ? " OR " : " ")+ QueryInsertPrefix + " " + QueryObject + where;
                    localFirst = false;
                }
                SQL += ")";
                first = false;
            }

            foreach (var item in State.QueryAttributesInfo)
            {
                if (item.Value.Where.Count == 0) continue;
                string localWhere = string.Empty;
                var QueryObject = GetQueryObjectId(item.Key, query);
                if (first) SQL += " WHERE (";
                else SQL += " AND (";
                bool localFirst = true;
                foreach (var where in item.Value.Where)
                {
                    localWhere += (!localFirst ? " OR " : " ") + QueryInsertPrefix + " " + QueryObject + where;
                    localFirst = false;
                }
                SQL += ")";
            }

            #endregion WHERE
            #region ORDER BY
            SQL += "\n";
            first = true;
            foreach (var item in State.AttributesInfo)
            {
                if (item.Value.QuerySortType == QuerySortType.None) continue;
                string localWhere = string.Empty;
                var QueryObject = GetQueryObjectId(item.Key, query);
                if (first) SQL += " ORDER BY ";
                else SQL += ", ";
                SQL += QueryInsertPrefix + " " + QueryObject + 
                    ((item.Value.QuerySortType == QuerySortType.Ascending) ? (" ASC") :(" DESC"));
                first = false;
            }

            foreach (var item in State.QueryAttributesInfo)
            {
                if (item.Value.QuerySortType == QuerySortType.None) continue;
                string localWhere = string.Empty;
                var QueryObject = GetQueryObjectId(item.Key, query);
                if (first) SQL += " ORDER BY ";
                else SQL += ", ";
                SQL += QueryInsertPrefix + " " + QueryObject +
                    ((item.Value.QuerySortType == QuerySortType.Ascending) ? (" ASC") : (" DESC"));
                first = false;
            }
            #endregion  ORDER BY
            return SQL +";";
        }

        /// <summary>
        /// Создание хранимого текста итогового запроса
        /// </summary>
        /// <param name="State">Стэйт запроса</param>
        /// <param name="query">Текущий объект запроса</param>
        /// <returns>Созданный текст</returns>
        public string CreateQueryTextAgr(QueryConstractState State, Query query)
        {
            string SQL = "SELECT ";
            #region SELECT
            bool first = true;
            foreach (var item in State.AttributesInfo)
            {
                var info = (QueryAttributeInfoAgr)item.Value;
                if (info.Show)
                {
                    SQL += (!first ? ", " : string.Empty);
                    SQL += info.Func == AggregateFunc.Group 
                        ?
                        QueryInsertPrefix +" "+ GetQueryObjectId(item.Key, query)
                        :
                        info.Func.ToString()+"(" +QueryInsertPrefix + " " + GetQueryObjectId(item.Key, query)+")";
                    first = false;
                }
            }
            foreach (var item in State.QueryAttributesInfo)
            {
                var info = (QueryAttributeInfoAgr)item.Value;
                if (info.Show)
                {
                    SQL += (!first ? ", " : string.Empty);
                    SQL += info.Func == AggregateFunc.Group
                        ?
                        QueryInsertPrefix + " " + GetQueryObjectId(item.Key, query)
                        :
                        info.Func.ToString() + "(" + QueryInsertPrefix + " " + GetQueryObjectId(item.Key, query) + ")";
                    first = false;
                }
            }
            #endregion SELECT
            #region FROM
            SQL += "\n FROM ";
            first = true;
            //TO DO:Необходимо сделать DFS по графу, представленному в виде списка рёбер State.LinkList
            #endregion FROM
            #region WHERE
            SQL += "\n ";

            first = true;
            foreach (var item in State.AttributesInfo)
            {
                if (item.Value.Where.Count == 0) continue;
                string localWhere = string.Empty;
                var QueryObject = GetQueryObjectId(item.Key, query);
                if (first) SQL += " WHERE (";
                else SQL += " AND (";
                bool localFirst = true;
                foreach (var where in item.Value.Where)
                {
                    localWhere += (!localFirst ? " OR " : " ")+ QueryInsertPrefix + " " + QueryObject + where;
                    localFirst = false;
                }
                SQL += ")"; first = false;
            }

            foreach (var item in State.QueryAttributesInfo)
            {
                if (item.Value.Where.Count == 0) continue;
                string localWhere = string.Empty;
                var QueryObject = GetQueryObjectId(item.Key, query);
                if (first) SQL += " WHERE (";
                else SQL += " AND (";
                bool localFirst = true;
                foreach (var where in item.Value.Where)
                {
                    localWhere += (!localFirst ? " OR " : " ") + QueryInsertPrefix + " " + QueryObject + where;
                    localFirst = false;
                }
                SQL += ")"; first = false;
            }

            #endregion WHERE
            #region GROUP BY
            SQL += "\n";
            first = true;
            foreach (var item in State.AttributesInfo)
            {
                var info = (QueryAttributeInfoAgr)item.Value;
                if (info.Func == AggregateFunc.Group) continue;
                if (info.Show)
                {
                    SQL += (!first ? ", " : string.Empty);
                    SQL +=  QueryInsertPrefix + " " + GetQueryObjectId(item.Key, query);
                    first = false;
                }
            }
            foreach (var item in State.QueryAttributesInfo)
            {
                var info = (QueryAttributeInfoAgr)item.Value;
                if (info.Func == AggregateFunc.Group) continue;
                if (info.Show)
                {
                    SQL += (!first ? ", " : string.Empty);
                    SQL += QueryInsertPrefix + " " + GetQueryObjectId(item.Key, query);
                    first = false;
                }
            }

            #endregion GROUP BY
            #region ORDER BY
            SQL += "\n";
            first = true;
            foreach (var item in State.AttributesInfo)
            {
                var info = (QueryAttributeInfoAgr)item.Value;
                if (info.QuerySortType == QuerySortType.None) continue;
                string localWhere = string.Empty;
                var QueryObject = GetQueryObjectId(item.Key, query);
                if (first) SQL += " ORDER BY ";
                else SQL += ", ";
                SQL += info.Func == AggregateFunc.Group
                          ?
                          QueryInsertPrefix + " " + GetQueryObjectId(item.Key, query)
                          :
                          info.Func.ToString() + "(" + QueryInsertPrefix + " " + GetQueryObjectId(item.Key, query) + ")";
                SQL +=  ((item.Value.QuerySortType == QuerySortType.Ascending) ? (" ASC") :(" DESC"));
                first = false;
            }

            foreach (var item in State.QueryAttributesInfo)
            {
                var info = (QueryAttributeInfoAgr)item.Value;
                if (info.QuerySortType == QuerySortType.None) continue;
                string localWhere = string.Empty;
                var QueryObject = GetQueryObjectId(item.Key, query);
                if (first) SQL += " ORDER BY ";
                else SQL += ", ";
                SQL += info.Func == AggregateFunc.Group
                          ?
                          QueryInsertPrefix + " " + GetQueryObjectId(item.Key, query)
                          :
                          info.Func.ToString() + "(" + QueryInsertPrefix + " " + GetQueryObjectId(item.Key, query) + ")";
                SQL += ((item.Value.QuerySortType == QuerySortType.Ascending) ? (" ASC") : (" DESC"));
                first = false;
            }
            #endregion  ORDER BY
            return SQL +";";
        }
        #endregion QueryText

        #region QueryObjects

        /// <summary>
        /// Создание объектов <see cref="QueryObject"/> запроса
        /// </summary>
        /// <param name="State">Стэйт запроса</param>
        /// <param name="query">Текущий объект запроса</param>
        public void CreateQueryObjects(QueryConstractState State, Query query)
        {

            foreach (var item in State.Sources)
            {
                QueryObject queryObject = new QueryObject();


                if (item is Table table1)
                {
                    queryObject.Type = QueryObjectType.Table;
                    queryObject.ObjectID = table1.Id.ToString();
                }
                else if (item is Query query1)
                {
                    queryObject.Type = QueryObjectType.Query;
                    queryObject.ObjectID = query1.Id.ToString();
                }
                else
                {
                    throw new Exception();
                }

                queryObject.Query = query;
                ModelMetaDataContainer.QueryObjectSet.Add(queryObject);
            }


            foreach (var item in State.AttributesInfo)
            {
                var attribute = item.Key;
                var queryObject = new QueryObject
                {
                    Type = QueryObjectType.Attribute,
                    ObjectID = attribute.Id.ToString(),
                    Query = query
                };
                ModelMetaDataContainer.QueryObjectSet.Add(queryObject);
            }

            foreach (var item in State.QueryAttributesInfo)
            {

                var attribute = item.Key;
                var queryObject = new QueryObject
                {
                    Type = QueryObjectType.QueryOutput,
                    ObjectID = attribute.Id.ToString(),
                    Query = query
                };
                ModelMetaDataContainer.QueryObjectSet.Add(queryObject);
            }

            foreach (var item in State.LinkList)
            {
                var attribute1 = item.Left;
                var queryObject = new QueryObject();
                if (attribute1 is Attribute attribute)
                {
                    queryObject.Type = QueryObjectType.Attribute;
                    queryObject.ObjectID = attribute.Id.ToString();
                }
                else if (attribute1 is QueryOutput query1)
                {
                    queryObject.Type = QueryObjectType.QueryOutput;
                    queryObject.ObjectID = query1.Id.ToString();
                }
                else
                {
                    throw new Exception();
                }

                queryObject.Query = query;
                ModelMetaDataContainer.QueryObjectSet.Add(queryObject);

                var attribute2 = item.Right;
                var queryObject1 = new QueryObject();
                if (attribute2 is Attribute attribute3)
                {
                    queryObject1.Type = QueryObjectType.Attribute;
                    queryObject1.ObjectID = attribute3.Id.ToString();
                }
                else if (attribute2 is QueryOutput query2)
                {
                    queryObject1.Type = QueryObjectType.QueryOutput;
                    queryObject1.ObjectID = query2.Id.ToString();
                }
                else
                {
                    throw new Exception();
                }

                queryObject1.Query = query;
                ModelMetaDataContainer.QueryObjectSet.Add(queryObject1);
            }
            ModelMetaDataContainer.SaveChanges();
        }
        #endregion

        #region QueryOutput
        /// <summary>
        /// Создание объектов <see cref="QueryOutput"/> итогового запроса
        /// </summary>
        /// <param name="State">Стэйт запроса</param>
        /// <param name="query">Текущий объект запроса</param>
        public void CreateQueryOutputAgr(QueryConstractState State, Query query)
        {
            foreach (var item in State.AttributesInfo)
            {
                var info = (QueryAttributeInfoAgr)item.Value;
                if (info.Show)
                {
                    QueryOutput queryOutput = new QueryOutput
                    {
                        Name = info.Func == AggregateFunc.Group ?
                        item.Key.Name
                        :
                        info.Func.ToString() + "(" + item.Key.Name + ")",
                        Query = query,
                        Type = GetType(item.Key.Type, info.Func)
                    };
                    ModelMetaDataContainer.QueryOutputSet.Add(queryOutput);
                }
            }
            foreach (var item in State.QueryAttributesInfo)
            {
                var info = (QueryAttributeInfoAgr)item.Value;
                if (info.Show)
                {
                    QueryOutput queryOutput = new QueryOutput
                    {
                        Name = info.Func == AggregateFunc.Group ?
                        item.Key.Name
                        :
                        info.Func.ToString() + "(" + item.Key.Name + ")",
                        Query = query,
                        Type = GetType(item.Key.Type, info.Func)
                    };
                    ModelMetaDataContainer.QueryOutputSet.Add(queryOutput);
                }
            }
            ModelMetaDataContainer.SaveChanges();
        }

        /// <summary>
        /// Получить тип, получаемый после агрегирующей функции
        /// </summary>
        /// <param name="Type">Входной тип</param>
        /// <param name="aggregateFunc">Функция</param>
        /// <returns>Возвращаемый тип</returns>
        private string GetType(string Type, AggregateFunc aggregateFunc)
        {
            //Нужна когда введу Count
            return Type;
        }

        /// <summary>
        /// Создание объектов <see cref="QueryOutput"/> обычного запроса
        /// </summary>
        /// <param name="State">Стэйт запроса</param>
        /// <param name="query">Текущий объект запроса</param>
        public void CreateQueryOutput(QueryConstractState State, Query query)
        {
            foreach (var item in State.AttributesInfo)
            {
                if (item.Value.Show)
                {
                    QueryOutput queryOutput = new QueryOutput
                    {
                        Name = item.Key.Name,
                        Query = query,
                        Type = item.Key.Type
                    };
                    ModelMetaDataContainer.QueryOutputSet.Add(queryOutput);
                }
            }
            foreach (var item in State.QueryAttributesInfo)
            {
                if (item.Value.Show)
                {
                    QueryOutput queryOutput = new QueryOutput
                    {
                        Name = item.Key.Name,
                        Query = query,
                        Type = item.Key.Type
                    };
                    ModelMetaDataContainer.QueryOutputSet.Add(queryOutput);
                }
            }
            ModelMetaDataContainer.SaveChanges();
        }
        #endregion QueryOutput

        /// <summary>
        /// Получить идентификатор объекта <see cref="QueryObject"/> соответствующий данному в данному запросе
        /// </summary>
        /// <param name="Input">Искомый объект</param>
        /// <param name="InputQuery">Запрос</param>
        /// <returns>Идентификатор объекта</returns>
        public string GetQueryObjectId(object Input, Query InputQuery)
        {
            QueryObjectType queryObjectType;
            string ID;
            if (Input is Attribute attribute)
            {
                queryObjectType = QueryObjectType.Attribute;
                ID = attribute.Id.ToString();
            }
            else if (Input is Table table)
            {
                queryObjectType = QueryObjectType.Table;
                ID = table.Id.ToString();
            }
            else if (Input is Query query)
            {
                queryObjectType = QueryObjectType.Query;
                ID = query.Id.ToString();
            }
            else if (Input is QueryOutput output)
            {
                queryObjectType = QueryObjectType.QueryOutput;
                ID = output.Id.ToString();
            }
            else throw new Exception();


            return ModelMetaDataContainer.QueryObjectSet
                .Where(x => x.ObjectID == ID && x.Type == queryObjectType)
                .Select(x => x.Id.ToString())
                .Single();
        }
    }
}

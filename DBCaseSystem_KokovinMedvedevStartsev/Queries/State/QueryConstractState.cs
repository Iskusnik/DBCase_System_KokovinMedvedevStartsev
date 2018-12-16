using System.Collections.Generic;

namespace DBCaseSystem_KokovinMedvedevStartsev.Queries
{

    /// <summary>
    /// Модель запроса
    /// </summary>
    public class QueryConstractState
    {
        /// <summary>
        /// Источники запроса
        /// </summary>
        public List<object> Sources { get; }

        /// <summary>
        /// Информация об используемых атрибутах
        /// </summary>
        public Dictionary<Attribute, QueryAttributeInfo> AttributesInfo;

        /// <summary>
        /// Информация об используемых атрибутах результатов запросов
        /// </summary>
        public Dictionary<QueryOutput, QueryAttributeInfo> QueryAttributesInfo;

        /// <summary>
        /// Список связей таблиц
        /// </summary>
        public List<Link> LinkList;
        
        /// <summary>
        /// Является ли запрос итоговым
        /// </summary>
        public bool IsAggregate { get; set; }

       
        public QueryConstractState(List<object> Sources, bool IsAggregate)
        {
            this.Sources = Sources;
            this.IsAggregate = IsAggregate;
            AttributesInfo = new Dictionary<Attribute, QueryAttributeInfo>();
            QueryAttributesInfo = new Dictionary<QueryOutput, QueryAttributeInfo>();
            LinkList = new List<Link>();
        }

        public QueryConstractState()
        {
            Sources = new List<object>();
            AttributesInfo = new Dictionary<Attribute, QueryAttributeInfo>();
            QueryAttributesInfo = new Dictionary<QueryOutput, QueryAttributeInfo>();
            LinkList = new List<Link>();

        }


    }
}

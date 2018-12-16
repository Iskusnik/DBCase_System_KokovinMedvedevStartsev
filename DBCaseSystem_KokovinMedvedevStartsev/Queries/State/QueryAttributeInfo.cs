using System.Collections.Generic;

namespace DBCaseSystem_KokovinMedvedevStartsev.Queries
{
    /// <summary>
    /// Информация об атрибуте
    /// </summary>
    public class QueryAttributeInfo
    {
        /// <summary>
        /// Условия
        /// </summary>
        public List<string> Where;

        /// <summary>
        /// Сортировка
        /// </summary>
        public QuerySortType QuerySortType;

        /// <summary>
        /// Требуется ли вывод атрибута
        /// </summary>
        public bool Show;
    }

    /// <summary>
    /// Информация об атрибуте для итогового запроса
    /// </summary>
    public class QueryAttributeInfoAgr : QueryAttributeInfo
    {
        /// <summary>
        /// Тип операции
        /// </summary>
        public AggregateFunc Func;
    }
}

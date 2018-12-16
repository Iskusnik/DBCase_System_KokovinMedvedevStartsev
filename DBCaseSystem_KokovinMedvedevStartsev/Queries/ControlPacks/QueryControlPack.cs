using DBCaseSystem_KokovinMedvedevStartsev.Queries;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBCaseSystem_KokovinMedvedevStartsev
{

    /// <summary>
    /// Информация об элементах управления, определяющих запрос
    /// </summary>
    public abstract class QueryControlPack
    {
        /// <summary>
        /// Выбранные источники
        /// </summary>
        public List<object> selectedSources;

        /// <summary>
        /// Репозиторий
        /// </summary>
        public QueryHandler handler;


        public QueryControlPack(ref QueryHandler handler, ref List<object> Sources)
        {
            this.handler = handler;
            selectedSources = Sources;
        }

        /// <summary>
        /// Коллекция самих элементов
        /// </summary>
        /// <returns>Коллекция самих элементов</returns>
        public abstract IEnumerable<Control> Controls();

        /// <summary>
        /// Установка элементов <see cref="ComboBox"/> как выбранные источники
        /// </summary>
        /// <param name="comboBox">Изменяемый комбобокс</param>
        protected void SetSourceCombo(ref ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(selectedSources.ToArray());
        }

        /// <summary>
        /// Установка элементов <see cref="ComboBox"/> как атрибуты выбранного источника
        /// </summary>
        /// <param name="comboBox">Изменяемый комбобокс</param>
        /// <param name="Source">Источник</param>
        protected void SetAttributeCombo(ref ComboBox comboBox, object Source)
        {
            if (Source is Table)
            {
                comboBox.Items.Clear();
                comboBox.Items.AddRange(handler.GetTableAttribute((Table)Source).ToArray());
            }
            else if (Source is Query)
            {
                comboBox.Items.Clear();
                comboBox.Items.AddRange(handler.GetQueryOutputs((Query)Source).ToArray());
            }
            else throw new Exception("Объект " + Source + " имеет недопустимый тип");
        }

        /// <summary>
        /// Изменение типа из-за смены типа запроса (с обычного на итоговый)
        /// </summary>
        /// <returns>Результат изменения</returns>
        public abstract QueryControlPack Convert();
    }
}

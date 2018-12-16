using DBCaseSystem_KokovinMedvedevStartsev.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DBCaseSystem_KokovinMedvedevStartsev
{
    /// <summary>
    /// Управляющие элементы связей таблиц
    /// </summary>
    public class LinkCombos
    {
        /// <summary>
        /// Комбобокс первого источника
        /// </summary>
        ComboBox source1;

        /// <summary>
        /// Комбобокс второго источника
        /// </summary>
        ComboBox source2;

        /// <summary>
        /// Комбобокс первого атрибута связки
        /// </summary>
        ComboBox atr1;

        /// <summary>
        /// Комбобокс второго атрибута связки
        /// </summary>
        ComboBox atr2;

        List<object> selectedSources;
        private QueryHandler handler;

        public LinkCombos(ref List<object> SelectedSources, ref QueryHandler Handler)
        {
            selectedSources = SelectedSources;
            handler = Handler;
            source1 = new ComboBox();
            source2 = new ComboBox();
            atr1 = new ComboBox();
            atr2 = new ComboBox();
            SetSourceCombo(ref source1);
            SetSourceCombo(ref source2);
            source1.TextChanged += new EventHandler(
                (x, y) => SetAttributeCombo(ref atr1, source1.SelectedItem));
            source2.TextChanged += new EventHandler(
                (x, y) => SetAttributeCombo(ref atr2, source2.SelectedItem));
        }

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
        /// Колекция из самих элементов управления
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Control> Controls()
        {
            yield return source1;
            yield return atr1;
            yield return source2;
            yield return atr2;
        }

        /// <summary>
        /// Название первого источника
        /// </summary>
        public string Source1 => source1.SelectedText;

        /// <summary>
        /// Название второго источника
        /// </summary>
        public string Source2 => source2.SelectedText;

        /// <summary>
        /// Название первого атрибута связки
        /// </summary>
        public string Attribute1 => atr1.SelectedText;

        /// <summary>
        /// Название второго атрибута связки
        /// </summary>
        public string Attribute2 => atr2.SelectedText;
    }
}

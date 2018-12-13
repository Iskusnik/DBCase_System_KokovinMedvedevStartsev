using DBCaseSystem_KokovinMedvedevStartsev.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCaseSystem_KokovinMedvedevStartsev
{
    /// <summary>
    /// Форма конструктора запросов
    /// </summary>
    public partial class QueryConstructForm : Form
    {
        /// <summary>
        /// Обработчик действий конструктора
        /// </summary>
        private QueryHandler handler;

        /// <summary>
        /// Список выбранных источников
        /// </summary>
        private List<object> selectedSources;

        public QueryConstructForm(QueryHandler handler)
        {
            InitializeComponent();
            this.handler = handler;
            selectedSources = new List<object>();
            SetSourcesCombo();
        }

        /// <summary>
        /// Функция настройки элементов <see cref="SourcesCombo"/>
        /// </summary>
        private void SetSourcesCombo()
        {
            var sources = handler.GetSources();
            SourcesCombo.Items.AddRange(sources.ToArray());
        }

        /// <summary>
        /// Функция добавления источника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            selectedSources.Add(SourcesCombo.SelectedItem);
            //очень не уверен
        }

        /// <summary>
        /// Установка элементов <see cref="ComboBox"/> как выбранные источники
        /// </summary>
        /// <param name="comboBox">Изменяемый комбобокс</param>
        private void SetSourceCombo(ref ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(selectedSources.ToArray());
        }

        /// <summary>
        /// Установка элементов <see cref="ComboBox"/> как атрибуты выбранного источника
        /// </summary>
        /// <param name="comboBox">Изменяемый комбобокс</param>
        /// <param name="Source">Источник</param>
        private void SetAttributeCombo(ref ComboBox comboBox, ref object Source)
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
    }
}

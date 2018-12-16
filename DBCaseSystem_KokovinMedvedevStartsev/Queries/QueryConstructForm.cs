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

        /// <summary>
        /// Список представлений управляющих элементов, определяющих запрос
        /// </summary>
        private List<QueryControlPack> QueryControls;

        /// <summary>
        /// Является запрос итоговым
        /// </summary>
        private bool IsAggregate;


        private bool HasChanged;

        /// <summary>
        /// Создание новой таблицы описания запроса
        /// </summary>
        private void SetTable()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = 1;
            IsAggregate = !IsAggregate;

            List<Label> labels;
            if (IsAggregate)
            {
                //устанавливаем для агрегируещего
                labels = new List<Label> {

                new Label() { Text = "Источник" },
                new Label() { Text = "Атрибут" },
                new Label() { Text = "Выводить" },
                new Label() { Text = "Операция" },
                new Label() { Text = "Сортировка" },
                new Label() { Text = "Условие" },
                new Label() { Text = "Или" },
                new Label() { Text = "Или" },
                new Label() { Text = "Или" }
                };

            }
            else
            {
                //устанавливаем для общего
                labels = new List<Label> {
                new Label() { Text = "Источник" },
                new Label() { Text = "Атрибут" },
                new Label() { Text = "Выводить" },
                new Label() { Text = "Сортировка" },
                new Label() { Text = "Условие" },
                new Label() { Text = "Или" },
                new Label() { Text = "Или" },
                new Label() { Text = "Или" },
                new Label() { Text = "Или" }
                };
                
            }
            for (int i = 0; i < labels.Count; i++)
            {
                tableLayoutPanel1.Controls.Add(labels[i], 0, i);
            }
            if (!HasChanged)
                GetNewLine();
            else
                ConvertQueryControls();
            HasChanged = true;
        }
        
        /// <summary>
        /// Изменение элементов управления, определяющих запрос, после нажатия <see cref="ChangeTypeButton"/>
        /// </summary>
        private void ConvertQueryControls()
        {
            List<QueryControlPack> nlist = new List<QueryControlPack>();
            foreach (var pack in QueryControls)
            {
                tableLayoutPanel1.ColumnCount++;

                QueryControlPack queryControlPack = pack.Convert();
               
                tableLayoutPanel1.Controls.AddRange(queryControlPack.Controls().ToArray());
                foreach (var a in queryControlPack.Controls())
                {
                    a.Visible = true;
                    a.Enabled = true;
                }

                nlist.Add(queryControlPack);
            }
            QueryControls.Clear();
            QueryControls = nlist;
        }

        /// <summary>
        /// Добавление новой колонки
        /// </summary>
        private void GetNewLine()
        {

            QueryControlPack queryControlPack;
            if (IsAggregate)
            {
                queryControlPack = new QueryControlPackAgr(ref handler, ref selectedSources);
            }else
            {
                queryControlPack = new QueryControlPackGen(ref handler, ref selectedSources);
            }
            tableLayoutPanel1.ColumnCount++;

            QueryControls.Add(queryControlPack);

            tableLayoutPanel1.Controls.AddRange(QueryControls.Last().Controls().ToArray());
            foreach (var a in QueryControls.Last().Controls())
            {
                a.Visible = true;
                a.Enabled = true;
            }
        }

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="handler">Репозиторий работы с запросами</param>
        /// <param name="Aggregating"><see cref="Boolean.TrueString"/> - создаётся итоговый запроc</param>
        public QueryConstructForm(QueryHandler handler, bool Aggregating=false)
        {
            InitializeComponent();
            this.handler = handler;
            selectedSources = new List<object>();
            SetSourcesCombo();
            QueryControls = new List<QueryControlPack>();
            IsAggregate = !Aggregating;
            ChangeTypeButton_Click(null,null);
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
        private void button1_Click(object sender, EventArgs e)
        {
            selectedSources.Add(SourcesCombo.SelectedItem);
            //очень не уверен
        }
        
        private void ChangeTypeButton_Click(object sender, EventArgs e)
        {
            ChangeTypeButton.Text = IsAggregate?"Итоговый": "Обычный";
            SetTable();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}

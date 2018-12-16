using DBCaseSystem_KokovinMedvedevStartsev.Queries;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBCaseSystem_KokovinMedvedevStartsev
{

    public class QueryControlPackGen : QueryControlPack
    {
        /// <summary>
        /// Комбобокс источников запроса
        /// </summary>
        ComboBox SourceCombo;

        /// <summary>
        /// Комбобокс атрибутов источника
        /// </summary>
        ComboBox AttributeCombo;

        /// <summary>
        /// Чекбокс, включить ли атрибут в результат
        /// </summary>
        CheckBox ShowCheckBox;

        /// <summary>
        /// Комбобокс выбора сортировки
        /// </summary>
        ComboBox SortCombo;

        /// <summary>
        /// Текстбокс условия
        /// </summary>
        TextBox IfTextBox1;

        /// <summary>
        /// Текстбокс условия
        /// </summary>
        TextBox IfTextBox2;

        /// <summary>
        /// Текстбокс условия
        /// </summary>
        TextBox IfTextBox3;


        /// <summary>
        /// Текстбокс условия
        /// </summary>
        TextBox IfTextBox4;


        /// <summary>
        /// Текстбокс условия
        /// </summary>
        TextBox IfTextBox5;
        

        public QueryControlPackGen(ref QueryHandler handler, ref List<object> selectedSources) : 
            base(ref handler, ref selectedSources)
        {
            SourceCombo = new ComboBox();
            SetSourceCombo(ref SourceCombo);
            AttributeCombo = new ComboBox();
            SourceCombo.TextChanged += new EventHandler(
                (x, y) => SetAttributeCombo(ref AttributeCombo, SourceCombo.SelectedItem));
            ShowCheckBox = new CheckBox();
            SortCombo = new ComboBox();
            SortCombo.Items.AddRange(Enum.GetNames(typeof(QuerySortType)));
            SortCombo.SelectedIndex = 0;
            IfTextBox1 = new TextBox();
            IfTextBox2 = new TextBox();
            IfTextBox3 = new TextBox();
            IfTextBox4 = new TextBox();
            IfTextBox5 = new TextBox();
        }


        public QueryControlPackGen(QueryControlPackAgr queryControlPackAgr) : base(ref queryControlPackAgr.handler, ref queryControlPackAgr.selectedSources)
        {
            var Controls = queryControlPackAgr.Controls();
            var enumer = Controls.GetEnumerator();
            enumer.MoveNext();
            SourceCombo = (ComboBox)enumer.Current;
            enumer.MoveNext();
            AttributeCombo = (ComboBox)enumer.Current;
            enumer.MoveNext();
            ShowCheckBox = (CheckBox)enumer.Current;
            enumer.MoveNext();
            //skip OperationComboBox
            enumer.MoveNext();
            SortCombo = (ComboBox)enumer.Current;
            enumer.MoveNext();
            IfTextBox1 = (TextBox)enumer.Current;
            enumer.MoveNext();
            IfTextBox2 = (TextBox)enumer.Current;
            enumer.MoveNext();
            IfTextBox3 = (TextBox)enumer.Current;
            enumer.MoveNext();
            IfTextBox4 = (TextBox)enumer.Current;
            IfTextBox5 = new TextBox();
        }

        /// <summary>
        /// Коллекция самих элементов
        /// </summary>
        /// <returns>Коллекция самих элементов</returns>
        public override IEnumerable<Control> Controls()
        {
            yield return SourceCombo;
            yield return AttributeCombo;
            yield return ShowCheckBox;
            yield return SortCombo;
            yield return IfTextBox1;
            yield return IfTextBox2;
            yield return IfTextBox3;
            yield return IfTextBox4;
            yield return IfTextBox5;
        }
        /// <summary>
        /// Трансформация из-за смены типа запроса с обычного на итоговый
        /// </summary>
        /// <returns>Результат трансформации</returns>
        public override QueryControlPack Convert()
        {
            return new QueryControlPackAgr(this);
        }

        /// <summary>
        /// Имя источника
        /// </summary>
        public string Source { get => SourceCombo.SelectedItem.ToString(); }

        /// <summary>
        /// Имя атрибута
        /// </summary>
        public string Attribute { get => AttributeCombo.SelectedItem.ToString(); }

        /// <summary>
        /// Условия
        /// </summary>
        public IEnumerable<string> If
        {
            get
            {
                yield return IfTextBox1.Text;
                yield return IfTextBox2.Text;
                yield return IfTextBox3.Text;
                yield return IfTextBox4.Text;
                yield return IfTextBox5.Text;
            }
        }

        /// <summary>
        /// Выводить ли как результат
        /// </summary>
        public bool Show { get => ShowCheckBox.Checked; }


        /// <summary>
        /// Способ сортировки
        /// </summary>
        public QuerySortType Sort { get => (QuerySortType)Enum.Parse(typeof(QuerySortType), SortCombo.SelectedText); }
    }
}

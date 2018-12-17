using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCaseSystem_KokovinMedvedevStartsev.Forms
{
    public partial class FormMain : Form
    {
        MetaControllContext context;
        int selectedTable;
        Database selectedDatabase;

        public FormMain(Database dbData)
        {
            selectedDatabase = dbData;
            InitializeComponent();

            buttonAddAttribute.Enabled = false;
            buttonAddRelation.Enabled = false;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewAttributes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 3: EditColumn((int)senderGrid.Rows[e.RowIndex].Cells[3].Value); break;
                    case 4: DeleteColumn((int)senderGrid.Rows[e.RowIndex].Cells[3].Value); break;
                }
            }

            RefreshForm();
        }

        private void dataGridViewTables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 3: EditTable((int)senderGrid.Rows[e.RowIndex].Cells[3].Value); break;
                    case 4: DeleteTable((int)senderGrid.Rows[e.RowIndex].Cells[3].Value); break;
                }
            }

            RefreshForm();
        }



        private void EditColumn(int id)
        {
            Form editColumn = new FormAttributeEdit();
            editColumn.ShowDialog();

            RefreshForm();
        }

        private void EditTable(int id)
        {
            Table table = context.context.TableSet.Find(id);
            string name = "";
            FormNameSelect selectName = new Forms.FormNameSelect();

            selectName.ShowDialog();


            string newName = selectName.name;

            context.EditTable(table, newName);

            RefreshForm();
        }
        private void buttonAddRelation_Click(object sender, EventArgs e)
        {
            Form relations = new FormRelationControll();
            relations.ShowDialog();

            RefreshForm();
        }


        private void DeleteColumn(int id)
        {
            Table table = context.context.TableSet.Find(selectedTable);
            Attribute attribute = context.context.AttributeSet.Find(id);
            context.RemoveColumn(table, attribute);

            RefreshForm();
        }


        private void DeleteTable(int id)
        {
            Table table = context.context.TableSet.Find(id);
            context.RemoveTable(table);

            RefreshForm();
        }



        private void buttonAddAttribute_Click(object sender, EventArgs e)
        {
            Attribute attribute = new Attribute();
            string name = "";
            FormNameSelect selectName = new Forms.FormNameSelect(isTable: false);
            Table table = context.context.TableSet.Find(selectedTable);

            selectName.ShowDialog();

            attribute.Name = selectName.name;

            if (selectName.name != "")
                if (context.NewAttributeIsLegal(attribute))
                    context.AddColumn(table, attribute);
                else
                    MessageBox.Show("Нельзя создать атрибут. Имя занято");
            RefreshForm();
        }

        private void buttonAddTable_Click(object sender, EventArgs e)
        {
            Table table = new Table();
            string name = "";
            FormNameSelect selectName = new Forms.FormNameSelect();


            selectName.ShowDialog();

            table.Name = selectName.name;

            if (context.NewTableIsLegal(table))
                context.AddTable(table);
            else
                MessageBox.Show("Нельзя создать таблицу. Имя занято");

            RefreshForm();
        }

        ///TODO: доделать управление формами и формы + Добавить проверку на уникальность
        ///
        private void FormMain_Load(object sender, EventArgs e)
        {
            context = new MetaControllContext(null);
            context.SelectDatabase(selectedDatabase);
            RefreshForm();
        }

        private void RefreshForm()
        {
            if (context.context.TableSet.Count() > 0)
            {
                Table[] tables = context.context.TableSet.ToArray();

                RefreshAttributes();

                dataGridViewTables.Rows.Clear();
                int i = 0;
                int j = -1;
                foreach (var tab in tables)
                {
                    dataGridViewTables.Rows.Add(tab.Name, "Редактировать", "Удалить", tab.Id);

                    if (tab.Id == selectedTable)
                        j = i;

                    i++;
                }
                if (j != -1)
                    dataGridViewTables.Rows[j].Selected = true;
            }
        }

        private void RefreshAttributes()
        {
            if (context.context.TableSet.Count() > 0)
            {
                Table temp = (from t in context.context.TableSet where t.Id == selectedTable select t).ToArray()[0];
                Attribute[] attributes = temp.Attribute.ToArray();

                dataGridViewAttributes.Rows.Clear();

                foreach (var att in attributes)
                    dataGridViewAttributes.Rows.Add(att.Name, "Редактировать", "Удалить", att.Id);
            }
        }
        private void dataGridViewTables_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewTables.SelectedRows.Count > 0)
            {
                selectedTable = (int)dataGridViewTables.SelectedCells[3].Value;
                buttonAddRelation.Enabled = true;
                buttonAddAttribute.Enabled = true;
            }
            else
            {
                selectedTable = -1;
                buttonAddRelation.Enabled = false;
                buttonAddAttribute.Enabled = false;
            }
        }
    }
}

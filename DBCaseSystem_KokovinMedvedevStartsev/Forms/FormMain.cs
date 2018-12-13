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

        public FormMain()
        {
            InitializeComponent();
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
                    case 3: EditColumn((int)senderGrid.Rows[e.RowIndex].Cells[0].Value); break;
                    case 4: DeleteColumn((int)senderGrid.Rows[e.RowIndex].Cells[0].Value); break;
                }
            }
        }

        private void dataGridViewTables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 3: EditTable((int)senderGrid.Rows[e.RowIndex].Cells[0].Value); break;
                    case 4: DeleteTable((int)senderGrid.Rows[e.RowIndex].Cells[0].Value); break;
                }
            }
        }



        private void EditColumn(int id)
        {
            Form editColumn = new FormAttributeEdit();
            editColumn.ShowDialog();
        }

        private void EditTable(int id)
        {
            Form editTable = new FormTableEdit();
            editTable.ShowDialog();
        }
        private void buttonAddRelation_Click(object sender, EventArgs e)
        {
            Form relations = new FormRelationControll();
            relations.ShowDialog();
        }


        private void DeleteColumn(int id)
        {

        }


        private void DeleteTable(int id)
        {

        }

        

        private void buttonAddAttribute_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddTable_Click(object sender, EventArgs e)
        {
            Table table = new Table();
            string name = "";
            Form selectName = new Forms.FormNameSelect(ref name);
            selectName.ShowDialog();

            table.Name = name;

            context.AddTable(table);
        }

        ///TODO: доделать управление формами и формы + Добавить проверку на уникальность
        ///
        private void FormMain_Load(object sender, EventArgs e)
        {
            context = new MetaControllContext(null);
            RefreshForm();
        }

        private void RefreshForm()
        {
            Table[] tables = context.context.TableSet.ToArray();
            Attribute[] attributes = context.context.AttributeSet.ToArray();

            dataGridViewAttributes.Rows.Clear();
            foreach (var att in attributes)
                dataGridViewAttributes.Rows.Add(att.Name);

            dataGridViewTables.Rows.Clear();
            foreach (var tab in tables)
                dataGridViewAttributes.Rows.Add(tab.Name);
        }
    }
}

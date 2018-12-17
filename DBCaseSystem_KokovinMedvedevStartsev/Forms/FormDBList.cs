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
    public partial class FormDBList : Form
    {
        MetaControllContext context;
        int selectedTable;

        public FormDBList()
        {
            context = new MetaControllContext(null);
            InitializeComponent();
        }

        private void buttonAddDB_Click(object sender, EventArgs e)
        {
            Database table = new Database();
            string name = "";
            FormNameSelect selectName = new Forms.FormNameSelect();


            selectName.ShowDialog();

            table.Name = selectName.name;

            if (context.NewDatabaseIsLegal(table))
                context.AddDatabase(table);
            else
                MessageBox.Show("Нельзя создать базу данных. Имя занято");

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
        }

        private void EditTable(int id)
        {
            Database table = context.context.DatabaseSet.Find(id);
            string name = "";
            FormNameSelect selectName = new Forms.FormNameSelect();

            selectName.ShowDialog();


            string newName = selectName.name;

            context.EditDatabase(table, newName);

            RefreshForm();
        }

        private void DeleteTable(int id)
        {
            Database db = context.context.DatabaseSet.Find(id);
            context.RemoveDatabase(db);

            RefreshForm();
        }

        private void RefreshForm()
        {
            if (context.context.DatabaseSet.Count() > 0)
            {
                Database[] tables = context.context.DatabaseSet.ToArray();


                dataGridViewDB.Rows.Clear();
                int i = 0;
                int j = -1;
                foreach (var tab in tables)
                {
                    dataGridViewDB.Rows.Add(tab.Name, "Редактировать", "Удалить", tab.Id);

                    if (tab.Id == selectedTable)
                        j = i;

                    i++;
                }
                if (j != -1)
                    dataGridViewDB.Rows[j].Selected = true;

            }
        }


        private void dataGridViewTables_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDB.SelectedRows.Count > 0)
            {
                selectedTable = (int)dataGridViewDB.SelectedCells[3].Value;
            }
            else
            {
                selectedTable = -1;
            }
        }

        private void buttonEditWhole_Click(object sender, EventArgs e)
        {
            Database db = context.context.DatabaseSet.Find(selectedTable);
            Form form = new Forms.FormMain(db);
            form.ShowDialog();
        }

        private void FormDBList_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }
    }
}

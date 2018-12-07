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

        }

        private void EditTable(int id)
        {

        }

        private void DeleteColumn(int id)
        { }


        private void DeleteTable(int id)
        { }

        private void buttonAddRelation_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonAddAttribute_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddTable_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            context = new MetaControllContext("!CONNECTION STRING!");
        }
        private void RefreshForm()
        { }

        private void dataGridViewAttributes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

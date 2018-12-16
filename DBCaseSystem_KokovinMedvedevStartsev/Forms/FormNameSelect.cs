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
    public partial class FormNameSelect : Form
    {
        bool isTable;
        public string name;
        public FormNameSelect(bool isTable = true)
        {
            this.isTable = isTable;


            InitializeComponent();

            if (isTable)
                label2.Text = "таблицы";
            else
                label2.Text = "атрибута";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            this.Close();
        }
    }
}

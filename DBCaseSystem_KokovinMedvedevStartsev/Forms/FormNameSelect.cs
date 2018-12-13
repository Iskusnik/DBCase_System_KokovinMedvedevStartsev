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
        string name;
        public FormNameSelect(ref string name, bool isTable = true)
        {
            this.isTable = isTable;
            this.name = name;

            if (isTable)
                label2.Text = "таблицы";
            else
                label2.Text = "атрибута";

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }
    }
}

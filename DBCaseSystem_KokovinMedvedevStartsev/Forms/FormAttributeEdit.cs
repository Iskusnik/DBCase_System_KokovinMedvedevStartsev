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
    public partial class FormAttributeEdit : Form
    {
        Attribute result;

        public FormAttributeEdit()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckForm())
            {
                result = new Attribute();
                result.Name = textBoxName.Text;
                result.IsKey = checkBoxKey.Checked;
                result.IsNull = checkBoxNull.Checked;
                result.Indexed = checkBoxIndexed.Checked;
                result.Type = comboBox2.Text;
                result.Length = int.Parse(textBoxLenght.Text);
                result.DefaultValue = textBoxDefaultName.Text;
            }
        }
        private bool CheckForm()
        {
            int temp;

            if (textBoxName.Text == "")
                MessageBox.Show("Имя не может быть пустым");
            else
            if (textBoxLenght.Text == "")
                MessageBox.Show("Заполните длину поля");
            else
            if (int.TryParse(textBoxLenght.Text, out temp))
                MessageBox.Show("Введите число для длины поля");
            else
            if (temp < 1)
                MessageBox.Show("Число для длины поля должно быть положительным");
            else
            //Рассмотреть для разных типов
            //if (textBoxDefaultName.Text == "")
            //    MessageBox.Show("");
            //else
            if (comboBox2.SelectedItem == null)
                MessageBox.Show("");
            else
                return true;

            return false;
        }
    }
}

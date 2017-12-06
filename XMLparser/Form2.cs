using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLparser
{
    public partial class Form2 : Form
    {
        private Parcel parcel = new Parcel();

        public Form2(Parcel pl)
        {
            this.parcel = pl;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text += "Кадастровый номер: " + parcel.cadastralNumber + Environment.NewLine;
            textBox1.Text += "ОКАТО: " + parcel.okato + Environment.NewLine;
            textBox1.Text += "Регион: " + Convert.ToString(parcel.region) + Environment.NewLine;
            textBox1.Text += "Описание: " + parcel.note + Environment.NewLine;
            textBox1.Text += "Кадастровая стоимость: 50 000 р. " + Environment.NewLine;
            textBox1.Text += "Владелец: Полежакин И.А." + Environment.NewLine;
            textBox1.Text += "Дата регистрации собственности 30.11.2017: " + Environment.NewLine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }
    }
}

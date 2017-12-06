using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace XMLparser
{
    public partial class TubeInformation : Form
    {
        public TubeInformation(string Rad) 
        {
            InitializeComponent();
            switch (Rad)
            {
                case "0":
                    rLabel.Text = "2";
                    break;
                case "1":
                    rLabel.Text = "2.5";
                    break;
                case "2":
                    rLabel.Text = "10";
                    break;
                case "3":
                    rLabel.Text = "25";
                    break;
                case "4":
                    rLabel.Text = "50";
                    break;
            }

            lLabel.Text = "538.2";
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Word.Application app = new Word.Application();
            Word.Document doc = app.Documents.Open("c:\\GIS\\pass.doc");
            app.Visible = true;
        }
    }
}

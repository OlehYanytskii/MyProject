using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyProject
{
    public partial class ReadDaybook : Form
    {
        public ReadDaybook()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          //  richTextBox1.Text = dateTimePicker1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            string path = "";
            richTextBox1.Clear();
            for (int i = 0; i < 10; i++)
                path += dateTimePicker1.Value.ToString()[i];
            if (Directory.Exists(@"C:\\Users\\Oleg\\Documents\\MyProject\\MyProjectText\\щоденник\" + path)) 
            {
              string[] arrayoffiles= Directory.GetFiles(@"C:\\Users\\Oleg\\Documents\\MyProject\\MyProjectText\\щоденник\" + path);
               for(int i = 0; i < arrayoffiles.Length; i++)
                {
                    richTextBox1.Text += File.ReadAllText(arrayoffiles[i]);
                    richTextBox1.Text += "\r\n\r\n";
                }
            }
                    else
            {
                richTextBox1.Text = "Вказаного запису не існує";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

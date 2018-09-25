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
   
    public partial class MainForm : Form
    {
        public static string ToCompileShortTimeString(string time)
        {
            string time1 = "";
            for (int i = 0; i < time.Length; i++)
                if (time[i] == ':')
                    time1 += ' ';
                else time1 += time[i];
            return time1;
        }

        DaybookForm db = new DaybookForm();
        public MainForm()
        {
            InitializeComponent();
this.WindowState = FormWindowState.Maximized;

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.ShowDialog();
            
            
        }
    }
}

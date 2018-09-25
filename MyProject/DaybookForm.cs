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
using System.Data.SqlClient;


namespace MyProject
{
    public partial class DaybookForm : Form
    {
        SqlConnection sqlconnection;
        ReadDaybook rdb = new ReadDaybook();
        public DaybookForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Oleg\Documents\MyProject\MyProject\Database1.mdf;Integrated Security=True";
            sqlconnection = new SqlConnection(stringConnection);

        }
       public static string ToCompileShortTimeString(string time)
        {
            string time1="";
            for (int i = 0; i < time.Length; i++)
                if (time[i] == ':')
                    time1 += '.';
                else time1 += time[i];
            return time1;
        }
        private void button1_Click(object sender, EventArgs e)
        {   if(Directory.Exists(@"C:\\Users\\Oleg\\Documents\\MyProject\\MyProjectText\\щоденник\\" + System.DateTime.Now.ToShortDateString()))
            {
                
                StreamWriter writer = new StreamWriter($"C:\\Users\\Oleg\\Documents\\MyProject\\MyProjectText\\щоденник\\{DateTime.Now.ToShortDateString()}\\" +  MainForm.ToCompileShortTimeString(System.DateTime.Now.ToLongTimeString()+".txt"));
                writer.WriteLine(DateTime.Now);
                writer.Write(richTextBox1.Text);
                writer.Close();
                richTextBox1.Clear();
                
            }
            else
            {
                Directory.CreateDirectory(@"C:\\Users\\Oleg\\Documents\\MyProject\\MyProjectText\\щоденник\" + System.DateTime.Now.ToShortDateString());
                StreamWriter writer = new StreamWriter(($"C:\\Users\\Oleg\\Documents\\MyProject\\MyProjectText\\щоденник\\{DateTime.Now.ToShortDateString()}\\" + MainForm.ToCompileShortTimeString(System.DateTime.Now.ToLongTimeString() + ".txt")));
                writer.WriteLine(System.DateTime.Now);
                writer.Write(richTextBox1.Text);
                writer.Close();
                richTextBox1.Clear();
            }
            

                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rdb.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (Directory.Exists(@"C:\\Users\\Oleg\\Documents\\MyProject\\MyProjectText\\щоденник\\" + dateTimePicker1.Value.ToShortDateString() ))
            {

                StreamWriter writer = new StreamWriter($"C:\\Users\\Oleg\\Documents\\MyProject\\MyProjectText\\щоденник\\{dateTimePicker1.Value.ToShortDateString()}\\" + MainForm.ToCompileShortTimeString(System.DateTime.Now.ToLongTimeString() + ".txt"));
                writer.WriteLine(DateTime.Now);
                writer.Write(richTextBox1.Text);
                writer.Close();
                richTextBox1.Clear();

            }
            else
            {
                Directory.CreateDirectory(@"C:\\Users\\Oleg\\Documents\\MyProject\\MyProjectText\\щоденник\" + dateTimePicker1.Value.ToShortDateString());
                StreamWriter writer = new StreamWriter(($"C:\\Users\\Oleg\\Documents\\MyProject\\MyProjectText\\щоденник\\{dateTimePicker1.Value.ToShortDateString()}\\" + MainForm.ToCompileShortTimeString(System.DateTime.Now.ToLongTimeString() + ".txt")));
                writer.WriteLine(System.DateTime.Now);
                writer.Write(richTextBox1.Text);
                writer.Close();
                richTextBox1.Clear();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject
{

    
    public  partial class Form1 : Form
    {
        static string  password;
        public  string Password
        {
            get
            {
                async  void Read()
                {
                    
                    SqlDataReader sqlDataReader = null;
                    try
                    {
                        string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Oleg\Documents\MyProject\MyProject\Database1.mdf;Integrated Security=True";
                        SqlConnection sqlconnection = new SqlConnection(stringConnection);
                        await sqlconnection.OpenAsync();
                        string select = String.Format($"SELECT password FROM [TablePassword] WHERE Id=1");
                        SqlCommand command = new SqlCommand(select, sqlconnection);
                        sqlDataReader = await command.ExecuteReaderAsync();
                        while (await sqlDataReader.ReadAsync())
                        {
                          label1.Text+= Convert.ToString(sqlDataReader["password"]);
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                    finally
                    {
                        if (sqlDataReader != null) sqlDataReader.Close();

                    }
                }               
                Read();
                return label1.Text;
                // MessageBox.Show(pass);
            }
            set
            {
                password = value;
            }
        }
       public static string pas;
        MainForm mf = new MainForm();
        public Form1()
        {
            InitializeComponent();
            pas = Password;
           
          
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text ==label1.Text)//отут зробити цей метод!
            {
                pas = label1.Text;
                this.Hide();
                mf.ShowDialog();
                this.Close();
               
            }
        }

    }
}

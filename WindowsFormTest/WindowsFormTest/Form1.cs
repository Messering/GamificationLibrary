using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gamificationlibrary.DataBase;
using Gamificationlibrary;
using System.Data.SqlClient;

namespace WindowsFormTest
{
    public partial class Form1 : Form
    {
        SqlConnectionStringBuilder connect;
        public Form1()
        {
            InitializeComponent();
            connect = new SqlConnectionStringBuilder();

            connect.InitialCatalog = "Gamefication";
            connect.DataSource = @"(local)\SQLEXPRESS";
            connect.ConnectTimeout = 30;
            connect.IntegratedSecurity = true;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account.Login(new SqlConnection(connect.ConnectionString), textBox1.Text, textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Account.Registration(new SqlConnection(connect.ConnectionString),textBox4.Text, textBox3.Text, textBox6.Text, textBox7.Text, textBox5.Text);            
        }
    }
}

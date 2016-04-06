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
using MySql.Data.MySqlClient;

namespace WindowsFormTest
{
    public partial class Form1 : Form
    {
        MySqlConnection connect;
        public Form1()
        {
            InitializeComponent();
            string сon = "server=localhost;user id=root;database=gamigicationdb";
            connect = new MySqlConnection(сon);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Account.Login(new MySqlConnection(connect.ConnectionString), textBox1.Text, textBox2.Text))
            {
                this.Hide();
                Profile profile = new Profile();
                profile.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Login or password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == textBox7.Text)
            {
                GamificationConnectGamification.OpenConnection(connect.ConnectionString);
                if (Account.Registration(new MySqlConnection(connect.ConnectionString), textBox4.Text, textBox3.Text, textBox6.Text, textBox7.Text, textBox5.Text))
                {
                    this.Hide();
                    Profile profile= new Profile();
                    profile.ShowDialog();
                }
                else
                {
                    textBox3.ForeColor = Color.Red;
                    MessageBox.Show("This nickname reserved");
                }
                GamificationConnectGamification.CloseConnection();
            }
            else
            {
                textBox6.ForeColor = Color.Red;
                textBox7.ForeColor = Color.Red;
            }
        }
    }
}

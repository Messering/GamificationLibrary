using Gamificationlibrary;
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
    public partial class Profile : Form
    {
        SqlConnectionStringBuilder connect;
        public Profile()
        {
            InitializeComponent();
            label1.Text = Account.nickname_user;
            connect = new SqlConnectionStringBuilder();

            connect.InitialCatalog = "Gamefication";
            connect.DataSource = @"(local)\SQLEXPRESS";
            connect.ConnectTimeout = 30;
            connect.IntegratedSecurity = true;
            UserProfile user = new UserProfile(Account.id_user, new SqlConnection(connect.ConnectionString));
            user.loadInformation();
            label1.Text =""+ user.infUser.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Close();
            Form1 main = new Form1();
            main.ShowDialog();
        }
    }
}

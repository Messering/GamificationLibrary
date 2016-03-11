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

namespace WindowsFormTest
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
            label1.Text = Account.nickname_user;
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

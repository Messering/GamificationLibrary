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
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.IO;

namespace WindowsFormTest
{
    public partial class Profile : Form
    {
        MySqlConnection connect;
        UserProfile user;
        string FileName;
        public Profile()
        {
            InitializeComponent();
            label1.Text = Account.nickname_user;
            string сon = "server=localhost;user id=root; password=ytdbvjdybq96;database=gamigicationdb";
            connect = new MySqlConnection(сon);
            user = new UserProfile(Account.id_user, new MySqlConnection(connect.ConnectionString));
            user.loadInformation();
            load(user);
        }

        private void load(UserProfile user) {

            label1.Text = "" + user.nickname;
            textBox1.Text = "" + user.name;
            textBox2.Text = "" + user.email;
            label2.Text = "" + user.titleLevel;
            label3.Text = "" + user.titleRank;
            if (user.imageUser.Length > 0)
            {
                pictureBox1.Image = byteArrayToImage(user.imageUser);
            }
            else {
                pictureBox1.Image = Image.FromFile(Application.StartupPath+ "\\icon-user-default.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Close();
            Form1 main = new Form1();
            main.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            load(user);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GamificationConnectGamification.OpenConnection(connect.ConnectionString);
            if (textBox1.Text != user.name)
            {
                Users.Update(Account.id_user, "name", textBox1.Text);
            }


            if (textBox2.Text != user.email)
            {
                Users.Update(Account.id_user, "email", textBox2.Text);
            }
            if (textBox3.Text != "")
            {
                if (textBox3.Text == user.passwords)
                {
                    Users.UpdatePassword(Account.id_user, textBox4.Text);
                }
                else
                {
                    textBox3.BackColor = Color.Red;
                }
            }
            Users.UpdateImage(Account.id_user, FileName);
            GamificationConnectGamification.CloseConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog(); opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK) {
                FileName = opf.FileName;
                pictureBox1.Image = Image.FromFile(opf.FileName); }
        }
        public static byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {           
            MemoryStream stream = new MemoryStream(byteArrayIn);           
            var newImage = Image.FromStream(stream); stream.Dispose();
            return newImage;
        }
    }
}

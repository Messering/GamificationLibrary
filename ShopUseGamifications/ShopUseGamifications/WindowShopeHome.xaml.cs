using Gamificationlibrary;
using Gamificationlibrary.DataBase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShopUseGamifications
{
    /// <summary>
    /// Логика взаимодействия для WindowShopeHome.xaml
    /// </summary>
    public partial class WindowShopeHome : Window
    {
        MySqlConnection connect;
        UserProfile user;
        public WindowShopeHome()
        {
            InitializeComponent();
            string сon = "server=localhost;user id=root; password=ytdbvjdybq96;database=gamigicationdb";
            connect = new MySqlConnection(сon);
            GamificationConnectGamification.OpenConnection(connect.ConnectionString);
            user = new UserProfile(Account.id_user, new MySqlConnection(connect.ConnectionString));
            user.loadInformation();
            loadProfile(user);
            GamificationConnectGamification.CloseConnection();
        }

        private void loadProfile(UserProfile user)
        {

            NickName.Content = "" + user.nickname;
            userName.Text = "" + user.name;
            userEmail.Text = "" + user.email;
            userLevel.Text = "" + user.titleLevel;
            //label3.Text = "" + user.titleRank;
            //title = user.titleLevel;
          // pictureBox1.Image = byteArrayToImage(user.imageUser);

        }
        private void TriggerMoveWindow(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (WindowState == System.Windows.WindowState.Maximized)
                {
                    WindowState = System.Windows.WindowState.Normal;

                    double pct = PointToScreen(e.GetPosition(this)).X / System.Windows.SystemParameters.PrimaryScreenWidth;
                    Top = 0;
                    Left = e.GetPosition(this).X - (pct * Width);
                }

                DragMove();
            }
        }

        private void TriggerMaximize(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Maximized)
                WindowState = System.Windows.WindowState.Normal;
            else if (WindowState == System.Windows.WindowState.Normal)
                WindowState = System.Windows.WindowState.Maximized;
        }
        private void TriggerClose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TriggerMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Minimized;
        }

        private void Resize_Click(object sender, RoutedEventArgs e)
        {
            if (resizeIco.Text == "2")
            {
                resizeIco.Text = "1";
                WindowState = System.Windows.WindowState.Normal;
            }
            else
            {
                resizeIco.Text = "2";
                WindowState = System.Windows.WindowState.Maximized;
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

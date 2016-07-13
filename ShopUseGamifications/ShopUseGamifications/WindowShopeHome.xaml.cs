using Gamificationlibrary;
using Gamificationlibrary.DataBase;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ShopUseGamifications
{
    /// <summary>
    /// Логика взаимодействия для WindowShopeHome.xaml
    /// </summary>
    public partial class WindowShopeHome : Window, IDisposable
    {
        MySqlConnection connect;
        UserProfile user;
        public WindowShopeHome()
        {
            InitializeComponent();
            string сon = "Data Source=10.132.13.224;Persist Security Info=yes;" +
            "UserId=p_pobereyko; PWD=YZqzK2sj28f3JHSt; database=p_pobereyko;";
            connect = new MySqlConnection(сon);
            GamificationConnectGamification.OpenConnection(connect.ConnectionString);
            user = new UserProfile(Account.id_user, new MySqlConnection(connect.ConnectionString));
            user.loadInformation();
            loadProfile(user);
            GamificationConnectGamification.CloseConnection();

            // LoadAreaChartData();
              showColumnChart();

        }

        private void showColumnChart()
        {
            GraphicProgressView.AreaChartDraw(areaChart,Histories.getProgressUser(5,DateTime.Now),"Test");
            GraphicProgressView.AreaChartDraw(columnChart, Histories.getProgressUser(5, DateTime.Now), "Test");
            GraphicProgressView.AreaChartDraw(pieChart, Histories.getProgressUser(5, DateTime.Now), "Test");
            GraphicProgressView.AreaChartDraw(barChart, Histories.getProgressUser(5, DateTime.Now), "Test");

            ////Setting data for column chart
            //columnChart.DataContext = valueList;

            //// Setting data for pie chart
            //pieChart.DataContext = valueList;

            ////Setting data for area chart
            ////areaChart.DataContext = valueList;

            ////Setting data for bar chart
            //barChart.DataContext = valueList;

            ////Setting data for line chart
            //lineChart.DataContext = valueList;
        }

        private void loadProfile(UserProfile user)
        {

            NickName.Content = "" + user.nickname;
            userName.Text = "" + user.name;
            userEmail.Text = "" + user.email;
            userLevel.Text = "" + user.titleLevel;
            Level level = new Level();
            LevelBar.Value = user.points;
            level.progressLevel(user.titleLevel);
            LevelBar.Minimum = -4;
            //level.minPoints;
            LevelBar.Maximum = 10;
            //level.maxPoints;
            contentLevelbar.Text = String.Format("{0}/{1}",user.points,LevelBar.Maximum);

            //GraphicProgressView.drawLine(rectang, Histories.getProgressUser(4, new DateTime(2007, 07, 4)), System.Drawing.Color.Coral, 3);
          imgPhoto.Source = ImageFromBuffer(user.imageUser);

        }

        public BitmapImage ImageFromBuffer(Byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            stream.Seek(0, SeekOrigin.Begin);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }
        private void TriggerMoveWindow(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;

                    double pct = PointToScreen(e.GetPosition(this)).X / SystemParameters.PrimaryScreenWidth;
                    Top = 0;
                    Left = e.GetPosition(this).X - (pct * Width);
                }

                DragMove();
            }
        }

        private void TriggerMaximize(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
        }
        private void TriggerClose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TriggerMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Resize_Click(object sender, RoutedEventArgs e)
        {
            if (resizeIco.Text == "2")
            {
                resizeIco.Text = "1";
                WindowState = WindowState.Normal;
            }
            else
            {
                resizeIco.Text = "2";
                WindowState = WindowState.Maximized;
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private System.Windows.Controls.Image ConvertDrawingImageToWPFImage(System.Drawing.Image gdiImg)
        {


            System.Windows.Controls.Image img = new System.Windows.Controls.Image();

            //convert System.Drawing.Image to WPF image
            Bitmap bmp = new Bitmap(gdiImg);
            IntPtr hBitmap = bmp.GetHbitmap();
            ImageSource WpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            img.Source = WpfBitmap;
            img.Stretch = Stretch.Fill;
            return img;
        }

        private void btLoadNewPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GamificationConnectGamification.OpenConnection(connect.ConnectionString);
            if (userName.Text != user.name)
            {
                Users.Update(Account.id_user, "name", userName.Text);
            }


            if (userEmail.Text != user.email)
            {
                Users.Update(Account.id_user, "email", userEmail.Text);
            }
            if (textNewPassword.Text != "")
            {
                if (textNewPassword.Text == user.passwords)
                {
                    Users.UpdatePassword(Account.id_user, textNewPassword.Text);
                }
                else
                {
                    //textNewPassword.Background.Co = System.Drawing.Color.Red;
                }
            }
           // Users.UpdateImage(Account.id_user, FileName);
            GamificationConnectGamification.CloseConnection();
        }

        private void Selected_element(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedItem == log_ouItems) {
                this.Hide();
                MainWindow logform = new MainWindow();
                logform.ShowDialog();
            }
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}

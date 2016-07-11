﻿using Gamificationlibrary;
using Gamificationlibrary.DataBase;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        string newImageName;
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
            Level level = new Level();
            LevelBar.Value = user.points;
            level.progressLevel(user.titleLevel);
            LevelBar.Minimum = -4;
            //level.minPoints;
            LevelBar.Maximum = 10;
            //level.maxPoints;
            contentLevelbar.Text = String.Format("{0}/{1}",user.points,LevelBar.Maximum);
            
            //label3.Text = "" + user.titleRank;
            //title = user.titleLevel;
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
    }
}

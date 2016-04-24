using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Gamificationlibrary;

namespace ShopUseGamifications
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection connect;
        public MainWindow()
        {
            InitializeComponent();
            string сon = "server=localhost;user id=root; password=ytdbvjdybq96;database=gamigicationdb";
            connect = new MySqlConnection(сon);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void move_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            VisibilitiesLogin(Visibility.Visible);
            VisibilitiesRegister(Visibility.Hidden);
            Sign.Content = "Sign in";
        }

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            if (Sign.Content.ToString() == "Sign in")
            {
                if (Account.Login(new MySqlConnection(connect.ConnectionString), textBoxLogin.Text, textBoxPassword.Text))
                {
                    //this.Hide();
                    //Profile profile = new Profile();
                    //profile.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Login or password");
                }
            }
            else if (Sign.Content.ToString() == "Sign up") { }
            else { }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            VisibilitiesLogin(Visibility.Hidden);
            VisibilitiesRegister(Visibility.Visible);
            Sign.Content = "Sign up";
        }

        private void VisibilitiesRegister(Visibility visibility) {
            labelNickname.Visibility = visibility;
            labelName.Visibility = visibility;
            labelEmail.Visibility = visibility;
            labelPasswords.Visibility = visibility;
            labelConfirmpasswords.Visibility = visibility;
            textBoxNickname.Visibility = visibility;
            textBoxName.Visibility = visibility;
            textBoxEmail.Visibility = visibility;
            textBoxPasswords.Visibility = visibility;
            textBoxConfirmPasswords.Visibility = visibility;
        }

        private void VisibilitiesLogin(Visibility visibility)
        {
            labelLogin.Visibility = visibility;
            labelPassword.Visibility = visibility;
            textBoxLogin.Visibility = visibility;
            textBoxPassword.Visibility = visibility;
        }
    }
}

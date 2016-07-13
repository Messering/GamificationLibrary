using System.Windows;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using Gamificationlibrary;
using Gamificationlibrary.DataBase;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ShopUseGamifications
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MySqlConnection connect;

        private static Regex ValidNameAllowedRegEx = new Regex(@"^(?=[a-zA-Z])[-\w.]{0,23}([a-zA-Z\d]|(?<![-.])_)$", RegexOptions.Compiled);
        private bool checkValid;
        public MainWindow()
        {
            InitializeComponent();
            string сon = "Data Source=10.132.13.224;Persist Security Info=yes;" +
            "UserId=p_pobereyko; PWD=YZqzK2sj28f3JHSt; database=p_pobereyko;";
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
                if (Account.Login(new MySqlConnection(connect.ConnectionString), textBoxLogin.Text, textBoxPassword.Password))
                {
                    this.Hide();
                    
                    WindowShopeHome homeForms = new WindowShopeHome();
                    homeForms.ShowDialog();
                }
                else
                {
                    errormessageLogin.Text = ("Invalid Login or password");
                    textBoxPassword.SecurePassword.Clear();
                    textBoxPassword.Focus();
                }
            }
            else if (Sign.Content.ToString() == "Sign up") {
                checkValid = true;
                errormessageConfirmPassword.Text = errormessageEmail.Text = errormessageName.Text = errormessageNick.Text = errormessagePassword.Text = null;
                GamificationConnectGamification.OpenConnection(connect.ConnectionString);
                if (!IsValidNameAllowed(textBoxNickname.Text))
                {
                    errormessageNick.Text = "Enter a valid Nickname.";
                    textBoxNickname.Focus();
                    checkValid = false;
                }
                if (!IsValidNameAllowed(textBoxName.Text))
                {
                    errormessageName.Text = "Enter a valid Name";
                    textBoxName.Focus();
                    checkValid = false;
                }

                if (textBoxEmail.Text.Length == 0)
                {
                    errormessageEmail.Text = "Enter an email.";
                    textBoxEmail.Focus();
                    checkValid = false;
                }
                if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    errormessageEmail.Text = "Enter a valid email.";
                    textBoxEmail.Select(0, textBoxEmail.Text.Length);
                    textBoxEmail.Focus();
                    checkValid = false;
                }
                if (textBoxPasswords.Password.Length == 0)
                {
                    errormessagePassword.Text = "Enter password.";
                    textBoxPassword.Focus();
                    checkValid = false;
                }
                if (textBoxConfirmPasswords.Password.Length == 0)
                {
                    errormessageConfirmPassword.Text = "Enter Confirm password.";
                    textBoxConfirmPasswords.Focus();
                    checkValid = false;
                }
                
                if (textBoxPasswords.Password != textBoxConfirmPasswords.Password)
                {
                    errormessagePassword.Text = "Confirm password must be same as password.";
                    textBoxConfirmPasswords.Focus();
                    textBoxPasswords.Focus();
                    checkValid = false;
                }
                if (checkValid && Account.Registration(new MySqlConnection(connect.ConnectionString), textBoxName.Text, textBoxNickname.Text, textBoxPasswords.Password, textBoxConfirmPasswords.Password, ConvertImage.imageToByteArray(Properties.Resources.default_avatar1), textBoxEmail.Text))
                {
                    this.Hide();
                    WindowShopeHome homeForm = new WindowShopeHome();
                    homeForm.ShowDialog();
                }
                
                GamificationConnectGamification.CloseConnection();
            }
            else
            {
                MessageBox.Show("Error program");
            }
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
            errormessageConfirmPassword.Text = null;
            errormessageEmail.Text = null;
            errormessageLogin.Text = null;
            errormessageName.Text = null;
            errormessageNick.Text = null;
            errormessagePassword.Text = null;
        }

        private bool IsValidNameAllowed(string userName)
        {
            if (string.IsNullOrEmpty(userName)
                || !ValidNameAllowedRegEx.IsMatch(userName))
            {
                return false;
            }
            return true;
        }

        private void textBoxPasswords_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

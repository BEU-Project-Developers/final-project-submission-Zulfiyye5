using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace MyProject.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly MovieService _movieService;

        public LoginPage()
        {
           
            InitializeComponent();
            _movieService = new MovieService();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        

       

        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, emailPattern);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SignUpCLick(object sender, RoutedEventArgs e)
        {

            MainWindow.NavigationService.Navigate(new SignUpPage());
        }

        private void SignInClick(object sender, RoutedEventArgs e)
        {
            var mainFrame = Application.Current.MainWindow.FindName("MainFrame") as Frame;


            if (IsValidEmail(EmailTextbox.Text))
            {
                if (_movieService.UserExists(EmailTextbox.Text))
                {
                    if (_movieService.CheckUserFromTable(EmailTextbox.Text, PasswordBox.Password) != null)
                    {
                        UserSession.Instance.UserId = (int)(_movieService.CheckUserFromTable(EmailTextbox.Text, PasswordBox.Password));
                       UserSession.Instance.UserName=(string)(_movieService.GetUserById(UserSession.Instance.UserId).name);
                        UserSession.Instance.Email = (string)(_movieService.GetUserById(UserSession.Instance.UserId).email);

                        mainFrame?.Navigate(new HomePage());
                    }
                    else
                    {
                        string message = "Wrong password!";
                        string title = "Error";
                        MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                }
                else
                {
                    string message = "This user doesn't exist";
                    string title = "Error";
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
              
                }


            }
            else
            {
                string message = "Invalid email format. Please enter a valid email address.";
                string title = "Error";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

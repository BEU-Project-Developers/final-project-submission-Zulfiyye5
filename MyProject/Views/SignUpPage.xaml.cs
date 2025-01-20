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
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        private readonly MovieManager _movieManager;
        public SignUpPage()
        {
            InitializeComponent();
            _movieManager = new MovieManager();
        }

        private void SignUpClick(object sender, RoutedEventArgs e)
        {
            string email = EmailTextbox.Text;  
            string password = PasswordBox.Password;
            string userName = UserNameTextbox.Text;
           

            if (!IsValidEmail(email))
            {
                string message = "Invalid email format. Please enter a valid email address.";
                string title = "Error";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else { 
          
            bool success = _movieManager.AddUser(email,userName, password);

            if (success)
            {
                UserManager.Instance.UserId = (int)(_movieManager.CheckUserFromTable(EmailTextbox.Text, PasswordBox.Password));
                MainWindow.NavigationManager.Navigate(new HomePage());
            }
            else
            {
                string message = "Sign-up failed. The user may already exist.";
                string title = "Error";
                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        
            } }
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


        private void SignInClick(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationManager.Navigate(new 
                SignInPage());
        }

    }
}

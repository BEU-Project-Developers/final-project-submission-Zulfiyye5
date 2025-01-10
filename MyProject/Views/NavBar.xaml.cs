using MyProject.Views;
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

namespace MyProject
{
    /// <summary>
    /// Interaction logic for NavBar.xaml
    /// </summary>
    public partial class NavBar : UserControl
    { 
  
        


        public NavBar()
        {
            InitializeComponent();
            
            

           

        }
        private void GoToMovies(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationService.Navigate(new MoviesPage());
        }

        private void GoToWatched(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationService.Navigate(new WatchedMovies());
        }

        private void GoToWatchList(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationService.Navigate(new WatchList());
        }

        private void GoToFavorities(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationService.Navigate(new FavoriteMovies());
        }

        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationService.Navigate(new LoginPage());
        }

        private void SearchBoxFocus(object sender, RoutedEventArgs e)
        {
            SearchBoxTextBox.Text="";
        }

        private void SearchMoviesClick(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationService.Navigate(new SearchResults(SearchBoxTextBox.Text));
        }

        private void SearchBoxTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) {
                SearchMoviesClick(sender, e);
            }
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            AccountPopup.IsOpen = !AccountPopup.IsOpen;
        }

        private void GoToHomePage(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationService.Navigate(new HomePage());
        }
    }
}

using MyProject.Models;
using MyProject.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyProject.Views
{
    public partial class HomePage : Page
    {
        private readonly MovieManager _movieManager;


        public HomePage()
        {
            InitializeComponent();
            _movieManager = new MovieManager();
         this.DataContext = new PagesViewModel(_movieManager);
            this.NavBarUserControl.HomeText.Foreground = new SolidColorBrush(Colors.Red);

            this.NavBarUserControl.HomeText.FontSize = 16;


        }
        private void MovieItem_Click(object sender, MouseButtonEventArgs e)
        {
          
            var border = sender as Border;
            var movie = border?.DataContext as Movie;

            if (movie != null)
            {

                MainWindow.NavigationManager
                    .Navigate(new MovieDetailsPage(movie));
             
            }
        }

    
    }
}

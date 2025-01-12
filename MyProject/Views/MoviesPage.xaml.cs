using MyProject.Models;
using MyProject.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyProject.Views
{
    public partial class MoviesPage : Page
    {
        private readonly MovieService _movieService;


        public MoviesPage()
        {
            InitializeComponent();
            _movieService = new MovieService();
         this.DataContext = new PagesViewModel(_movieService);
         

        }
        private void MovieItem_Click(object sender, MouseButtonEventArgs e)
        {
          
            var border = sender as Border;
            var movie = border?.DataContext as Movie;

            if (movie != null)
            {

                MainWindow.NavigationService.Navigate(new MovieDetailsPage(movie));
             
            }
        }

    
    }
}

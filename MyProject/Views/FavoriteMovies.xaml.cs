﻿using MyProject.Models;
using MyProject.ViewModels;
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

namespace MyProject.Views
{
    /// <summary>
    /// Interaction logic for FavoriteMovies.xaml
    /// </summary>
    public partial class FavoriteMovies : Page
    {
        private readonly MovieService _movieService;

        public FavoriteMovies()
        {
            InitializeComponent();
            _movieService = new MovieService();
            this.NavBarUserControl.FavoritesText.Foreground = new SolidColorBrush(Colors.Red);

            this.NavBarUserControl.FavoritesText.FontSize = 16;
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

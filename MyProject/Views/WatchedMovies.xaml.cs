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
    /// Interaction logic for WatchedMovies.xaml
    /// </summary>
    public partial class WatchedMovies : Page
    {
        private readonly MovieManager _movieManager;
        public WatchedMovies()
        {
            _movieManager = new MovieManager();
            this.DataContext = new PagesViewModel(_movieManager);
            InitializeComponent();
            this.NavBarUserControl.WatchedText.Foreground = new SolidColorBrush(Colors.Red);

            this.NavBarUserControl.WatchedText.FontSize = 16;

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

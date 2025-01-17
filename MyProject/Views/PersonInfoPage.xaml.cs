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
    /// Interaction logic for PersonInfoPage.xaml
    /// </summary>
    public partial class PersonInfoPage : Page
    {
        private readonly MovieManager _movieManager;
        MovieCast movieCast;
        Movie Movie;
        public PersonInfoPage(MovieCast moviecast,Movie movie,MovieManager movieManager)
        {
            movieCast = moviecast;
            Movie = movie;
            _movieManager = movieManager;
            InitializeComponent();
            DataContext =new PersonInfoViewModel(moviecast,movie,movieManager);
          
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationManager.Navigate(new MovieDetailsPage(Movie));
        }

        private void MovieItem_Click(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            var movie = border?.DataContext as Movie;

            if (movie != null)
            {
                MainWindow.NavigationManager.Navigate(new MovieDetailsPage(movie));
            }
        }
    }
}

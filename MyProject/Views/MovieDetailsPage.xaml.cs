using MyProject.Models;
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
using System.Windows.Shapes;

namespace MyProject.Views
{
    /// <summary>
    /// Interaction logic for MovieDetailsPage.xaml
    /// </summary>
    /// 
    public partial class MovieDetailsPage : Page
    {
        Movie Movie { get; set; }
        private bool isWatched = false;
        private bool isLiked = false;
        private bool isWatchList = false;
        private readonly MovieService _movieService;
        public MovieDetailsPage(Movie movie)
        {
            Movie = movie;
            _movieService = new MovieService();
            _movieService.AddToFavorite(129,1);
            InitializeComponent();
            if(_movieService.IsFavorite(Movie.dbId, UserSession.Instance.UserId))
            {
                isLiked= true;
                HeartImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\orangeheart.png"));
                LikeText.Text = "Liked";
                HeartImage.ToolTip = "Add to Favorites";
            }
            if(_movieService.IsWatched(Movie.dbId,UserSession.Instance.UserId)) { 
                isWatched= true;
                EyeImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\greeneye.png"));
                WatchText.Text="Watched";
                EyeImage.ToolTip="Add to Watched List";
            }
            if (_movieService.IsWatchList(Movie.dbId, UserSession.Instance.UserId))
            {
                isWatchList = true;
                SaveImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\savered.png"));
                SaveImage.ToolTip="Add to  WatchList" ;
            }
            DataContext = new MoviesDetailViewModel(movie,_movieService);  
        }

        private void GoToMovies(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationService.Navigate(new MoviesPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void EyeButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (isWatched)
            {
                EyeImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\greeneye.png"));
                isWatched = false;
                WatchText.Text = "Watched";
                _movieService.AddToWatched(Movie.dbId, UserSession.Instance.UserId);
                EyeImage.ToolTip = "Remove from Watched List";
            }
            else
            {
                EyeImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\whiteeye.png"));
                isWatched = true;
                WatchText.Text = "Watch";
                _movieService.RemoveFromWatched(Movie.dbId, UserSession.Instance.UserId);
                EyeImage.ToolTip = "Add to Watched List";
            }
        }
        private void NavigateToDetails(object sender, RoutedEventArgs e)
        {
            var border = sender as Border;
            var person =border?.DataContext as MovieCast;
            if(person!=null) {

                MainWindow.NavigationService.Navigate(new PersonInfoPage(person, Movie, _movieService));
               
            }
          
        }

        private void HeartButton_Click(object sender, RoutedEventArgs e)


        {
           
           
            if (isLiked)
            {
                HeartImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\orangeheart.png"));
                isLiked = false;
                LikeText.Text = "Liked";
                _movieService.AddToFavorite(Movie.dbId, UserSession.Instance.UserId);

                HeartImage.ToolTip = "Remove from Favorites";

            }
            else
            {
                HeartImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\whiteheart.png"));
                isLiked = true;
                LikeText.Text = "Like";
                _movieService.RemoveFromFavorite(Movie.dbId, UserSession.Instance.UserId);
                HeartImage.ToolTip = "Add to Favorites";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (isWatchList)
            {
                SaveImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\savered.png"));
                isWatchList = false;
          
                _movieService.AddToWatchList(Movie.dbId, UserSession.Instance.UserId);
                SaveImage.ToolTip = "Remove from  WatchList";

            }
            else
            {
                SaveImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\savewhite.png"));
                isWatchList = true;
                _movieService.RemoveFromWatchList(Movie.dbId, UserSession.Instance.UserId);
                SaveImage.ToolTip = "Add to  WatchList";
            }
        }

        private void GoToFavorites(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationService.Navigate(new FavoriteMovies());

          
        }

        private void GoToWatchList(object sender, RoutedEventArgs e)
        {
           
            MainWindow.NavigationService.Navigate(new WatchList());
           
        }

        private void GoToWatched(object sender, RoutedEventArgs e)
        {
            
            MainWindow.NavigationService.Navigate(new WatchedMovies());
         
        }

        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationService.Navigate(new LoginPage());
        }

        private void SearchBoxFocus(object sender, RoutedEventArgs e)
        {
            SearchBoxTextBox.Text = "";
        }

        private void SearchMoviesClick(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationService.Navigate(new SearchResults(SearchBoxTextBox.Text));
        }

        private void SearchBoxTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchMoviesClick(sender, e);
            }
        }


        private void GoToFavorities(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationService.Navigate(new FavoriteMovies());
        }




        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            AccountPopup.IsOpen = !AccountPopup.IsOpen;
        }

    
    }
}

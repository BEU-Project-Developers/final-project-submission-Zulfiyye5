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
        private readonly MovieManager _movieManager;
        public MovieDetailsPage(Movie movie)
        {
            Movie = movie;
            _movieManager = new MovieManager();
         
            InitializeComponent();
            if(_movieManager.IsFavorite(Movie.dbId, UserManager.Instance.UserId))
            {
                isLiked= true;
                HeartImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\orangeheart.png"));
                LikeText.Text = "Liked";
                HeartImage.ToolTip = "Add to Favorites";
            }
            if(_movieManager.IsWatched(Movie.dbId,UserManager.Instance.UserId)) { 
                isWatched= true;
                EyeImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\greeneye.png"));
                WatchText.Text="Watched";
                EyeImage.ToolTip="Add to Watched List";
            }
            if (_movieManager.IsWatchList(Movie.dbId, UserManager.Instance.UserId))
            {
                isWatchList = true;
                SaveImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\savered.png"));
                SaveImage.ToolTip="Add to  WatchList" ;
            }
            DataContext = new MoviesDetailViewModel(movie, _movieManager);  

        }

        private void GoToMovies(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationManager.Navigate(new HomePage());
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
                _movieManager.AddToWatched(Movie.dbId, UserManager.Instance.UserId);
                EyeImage.ToolTip = "Remove from Watched List";
            }
            else
            {
                EyeImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\whiteeye.png"));
                isWatched = true;
                WatchText.Text = "Watch";
                _movieManager.RemoveFromWatched(Movie.dbId, UserManager.Instance.UserId);
                EyeImage.ToolTip = "Add to Watched List";
            }
        }
        private void NavigateToDetails(object sender, RoutedEventArgs e)
        {
            var border = sender as Border;
            var person =border?.DataContext as MovieCast;
            if(person!=null) {

                MainWindow.NavigationManager.Navigate(new PersonInfoPage(person, Movie, _movieManager));
               
            }
          
        }

        private void HeartButton_Click(object sender, RoutedEventArgs e)


        {
           
           
            if (isLiked)
            {
                HeartImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\orangeheart.png"));
                isLiked = false;
                LikeText.Text = "Liked";
                _movieManager.AddToFavorite(Movie.dbId, UserManager.Instance.UserId);

                HeartImage.ToolTip = "Remove from Favorites";

            }
            else
            {
                HeartImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\whiteheart.png"));
                isLiked = true;
                LikeText.Text = "Like";
                _movieManager.RemoveFromFavorite(Movie.dbId, UserManager.Instance.UserId);
                HeartImage.ToolTip = "Add to Favorites";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (isWatchList)
            {
                SaveImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\savered.png"));
                isWatchList = false;

                _movieManager.AddToWatchList(Movie.dbId, UserManager.Instance.UserId);
                SaveImage.ToolTip = "Remove from  WatchList";

            }
            else
            {
                SaveImage.Source = new BitmapImage(new Uri("C:\\Users\\ADMIN\\source\\repos\\MyProject\\MyProject\\Images\\savewhite.png"));
                isWatchList = true;
                _movieManager.RemoveFromWatchList(Movie.dbId, UserManager.Instance.UserId);
                SaveImage.ToolTip = "Add to  WatchList";
            }
        }

        private void GoToFavorites(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationManager.Navigate(new FavoriteMovies());

          
        }

        private void GoToWatchList(object sender, RoutedEventArgs e)
        {
           
            MainWindow.NavigationManager.Navigate(new WatchList());
           
        }

        private void GoToWatched(object sender, RoutedEventArgs e)
        {
            
            MainWindow.NavigationManager.Navigate(new WatchedMovies());
         
        }

        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationManager.Navigate(new SignInPage());
        }

  

        private void GoToFavorities(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationManager.Navigate(new FavoriteMovies());
        }

        private void AddReviewClick(object sender, RoutedEventArgs e)
        {
            //var addReviewWindow = new AddReviewWindow();
            //addReviewWindow.Owner = Application.Current.MainWindow;
            //addReviewWindow.ShowDialog();


            var blurEffect = new System.Windows.Media.Effects.BlurEffect
            {
                Radius = 10
            };
            this.Effect = blurEffect;

      
            var addReviewWindow = new AddReviewWindow(Movie);

            addReviewWindow.Closed += (s, args) =>
            {
                // Refresh the MovieReviews data after the review window is closed
                DataContext = new MoviesDetailViewModel(Movie, _movieManager);
                this.Effect = null; // Reset blur effect
            };


            addReviewWindow.Owner = Application.Current.MainWindow;
            addReviewWindow.ShowDialog();

        }
    }
}
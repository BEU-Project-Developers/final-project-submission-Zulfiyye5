using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using static System.Net.WebRequestMethods;
using MyProject.Models;

namespace MyProject.ViewModels
{
    public class MovieViewModel
    {
        private readonly MovieManager _movieManager;
       
        public string PageTitle { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }
    
        public MovieViewModel(MovieManager movieManager,string pageName)
        {

            _movieManager = movieManager;
            if (pageName == "HomePage") {
                PageTitle="Movies";
                Movies = new ObservableCollection<Movie>(_movieManager.GetAllMovies());

            }
            else if (pageName == "FavoriteMovies") {
                PageTitle = "Favorite Movies";
                Movies = new ObservableCollection<Movie>(_movieManager.GetFavorities(UserManager.Instance.UserId));
            }
            else if (pageName == "WatchedMovies")
            {
                PageTitle = "Watched Movies";
                Movies = new ObservableCollection<Movie>(_movieManager.GetWatchedMovies(UserManager.Instance.UserId));
            }
            else if (pageName == "WatchList")
            {
                PageTitle = "WatchList";
                Movies = new ObservableCollection<Movie>(_movieManager.GetWatchedMovies(UserManager.Instance.UserId));
            }




        }


    }
}

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
        private readonly MovieService _movieService;
       
        public string PageTitle { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }
    
        public MovieViewModel(MovieService movieService,string pageName)
        {
          
            _movieService = movieService;
            if (pageName == "HomePage") {
                PageTitle="Movies";
                Movies = new ObservableCollection<Movie>(_movieService.GetAllMovies());

            }
            else if (pageName == "FavoriteMovies") {
                PageTitle = "Favorite Movies";
                Movies = new ObservableCollection<Movie>(_movieService.GetFavorities(UserSession.Instance.UserId));
            }
            else if (pageName == "WatchedMovies")
            {
                PageTitle = "Watched Movies";
                Movies = new ObservableCollection<Movie>(_movieService.GetWatchedMovies(UserSession.Instance.UserId));
            }
            else if (pageName == "WatchList")
            {
                PageTitle = "WatchList";
                Movies = new ObservableCollection<Movie>(_movieService.GetWatchedMovies(UserSession.Instance.UserId));
            }




        }


    }
}

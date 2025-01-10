using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using static System.Net.WebRequestMethods;
using MyProject.Models;
using LinqToDB.Common;
using System.ComponentModel;

namespace MyProject.ViewModels
{
    public class PagesViewModel
    {
        private readonly MovieService _movieService;
       
        public string PageTitle { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }
        public ObservableCollection<Movie> FavoriteMovies { get; set; }
        public ObservableCollection<Movie> WatchList { get; set; }
        public ObservableCollection<Movie> WatchedMoviesList { get; set; }
        public ObservableCollection<Movie> HighestImdbMovies { get; set; }

        public ObservableCollection<Movie> PopularMovies { get; set; }

        public ObservableCollection<Movie> SearchResults { get; set; }


      
        public PagesViewModel(MovieService movieService)
        {
          
            _movieService = movieService;
            Movies = new ObservableCollection<Movie>(_movieService.GetAllMovies());
            FavoriteMovies = new ObservableCollection<Movie>(_movieService.GetFavorities(UserSession.Instance.UserId));
            WatchList = new ObservableCollection<Movie>(_movieService.GetWatchList(UserSession.Instance.UserId));
            WatchedMoviesList = new ObservableCollection<Movie>(_movieService.GetWatchedMovies(UserSession.Instance.UserId));
            PopularMovies= new ObservableCollection<Movie>(_movieService.PopularMovies());
            HighestImdbMovies= new ObservableCollection<Movie>(_movieService.HighestImdbMovies());

        }
        private bool _isSearchResultsEmpty;
        public bool IsSearchResultsEmpty
        {
            get => _isSearchResultsEmpty;
            set
            {
                _isSearchResultsEmpty = value;
                OnPropertyChanged(nameof(IsSearchResultsEmpty));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PagesViewModel(MovieService movieService, string movieString)
        {
            _movieService = movieService;
            SearchResults = new ObservableCollection<Movie>(_movieService.SearchMovies(movieString));
            IsSearchResultsEmpty = SearchResults == null || !SearchResults.Any();
        }

    }
}

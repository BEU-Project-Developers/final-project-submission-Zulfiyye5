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
        private readonly MovieManager _movieManager;
       
        public string PageTitle { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }
        public ObservableCollection<Movie> FavoriteMovies { get; set; }
        public ObservableCollection<Movie> WatchList { get; set; }
        public ObservableCollection<Movie> WatchedMoviesList { get; set; }
        public ObservableCollection<Movie> HighestImdbMovies { get; set; }

        public ObservableCollection<Movie> PopularMovies { get; set; }

        public ObservableCollection<Movie> SearchResults { get; set; }


      
        public PagesViewModel(MovieManager movieManager)
        {
          
            _movieManager= movieManager;
            Movies = new ObservableCollection<Movie>(_movieManager.GetAllMovies());
            FavoriteMovies = new ObservableCollection<Movie>(_movieManager.GetFavorities(UserManager.Instance.UserId));
            WatchList = new ObservableCollection<Movie>(_movieManager.GetWatchList(UserManager.Instance.UserId));
            WatchedMoviesList = new ObservableCollection<Movie>(_movieManager.GetWatchedMovies(UserManager.Instance.UserId));
            PopularMovies= new ObservableCollection<Movie>(_movieManager.PopularMovies());
            HighestImdbMovies= new ObservableCollection<Movie>(_movieManager.HighestImdbMovies());

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

        public PagesViewModel(MovieManager movieManager, string movieString)
        {
            _movieManager = movieManager;
            SearchResults = new ObservableCollection<Movie>(_movieManager.SearchMovies(movieString));
            IsSearchResultsEmpty = SearchResults == null || !SearchResults.Any();
        }

    }
}

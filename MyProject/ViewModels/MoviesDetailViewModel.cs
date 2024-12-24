using MyProject.Models;
using System;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace MyProject.ViewModels
{
    public class MoviesDetailViewModel
    {

     public int dbId { get; set; }
        public string Title2 { get; set; }
        public string Image_path { get; set; }
        public string Bg_image_path { get; set; }
        public string Overview { get; set; }
        public string Director_name {  get; set; }  
        public double Imdb { get; set; }
        public string ReleaseDate { get; set; }
        public int ReleaseYear { get; set; }
        public int Runtime { get; set; }
        
        public string Origin_language {  get; set; }  
        public List<Genre>Genres { get; set; }
        public List<MovieCast> TopBilledCast { get; set; }

        
        public MoviesDetailViewModel(Movie movie,MovieService movieService)
        {
            dbId = movie.dbId;
           
            Title2 = movie.Title;
            Image_path = movie.Image_path;
            Bg_image_path = movie.Bg_image_path;
            Overview = movie.Overview;
            Imdb = movie.Imdb;
            ReleaseDate = movie.ReleaseDate;
            ReleaseYear = GetReleaseYear(movie.ReleaseDate); 
            Director_name = movie.Director_name;
            Runtime = movie.Runtime;
            Origin_language = movie.Origin_language;
            Genres = movieService.FindGenreByMovieId(movie.dbId);
            TopBilledCast = movieService.FindCastByMovieId(movie.dbId);

         

        }
        public string Directed_by_string
        {
            get
            {
                return $"Directed by {Director_name}";
            }
        }
        public string Rating_string
        {
            get
            {
                return $"{Imdb}/10";
            }
        }
        public int GetReleaseYear(string releaseDate)
        {
            if (DateTime.TryParse(releaseDate, out DateTime date))
            {
                return date.Year; 
            }
            else
            {
                return 0;  
            }
        }
        public string FormattedDetails
        {
            get
            {
                int hours = Runtime / 60;
                int minutes = Runtime % 60;

                string formattedRuntime = $"{hours}h {minutes}m";

             
                return $"{ReleaseYear} || {formattedRuntime} || Language: {Origin_language}";
            }
        }
    }
}

using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyProject.ViewModels
{
    public class PersonInfoViewModel
    {
        private readonly MovieService _movieService;
        public string Name { get; set; }
      public string Biography {  get; set; }    
        public int Person_id { get; set; }
        public int Movie_id { get; set; }
        public string Image_path {  get; set; }

        public ObservableCollection<Movie> Movies { get; set; }
        public PersonInfoViewModel(MovieCast movieCast, Movie movie,MovieService movieService)
        {
            _movieService = movieService;
            Name = movieCast.Name;
            Biography = movieCast.Biography;
            Image_path = movieCast.image_url;
            Person_id = movieCast.Person_id;
            Movie_id = movieCast.Movie_id;
            Movies = new ObservableCollection<Movie>(_movieService.GetAllMoviesOfPerson(Person_id));



        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyProject.Models
{
    public class Movie
    {
        public int dbId { get;set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Image_path { get; set; }
        public string Bg_image_path { get; set; }
      
        public double Imdb { get; set; }

        public string Origin_country { get; set; }
        public string Origin_language { get; set; }
        public string Director_name { get; set; }
        public int Runtime { get;set; }
        public int WatchList { get; set; }
        public int Liked { get; set; }
        public int Watched {  get; set; }
        public string ReleaseDate { get; set; }
   
    }

}

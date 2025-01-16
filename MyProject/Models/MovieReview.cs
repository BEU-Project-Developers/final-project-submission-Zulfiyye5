using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class MovieReview
    {

        public int Id { get; set; }
        public int user_id {  get; set; }   
        public int movie_id {  get; set; }

        public string user_name { get; set; }
        public string reviewText {  get; set; }
        public string reviewDate {  get; set; } 

    }
}

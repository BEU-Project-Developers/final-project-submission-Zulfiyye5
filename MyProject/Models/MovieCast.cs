using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class MovieCast
    {
        public string Name {  get; set; }   
        public int Movie_id {  get; set; }  
        public int Person_id {  get; set; } 

        public string Biography {  get; set; }
        public string Character_name { get; set; }
        public string image_url { get; set; }

    }
}

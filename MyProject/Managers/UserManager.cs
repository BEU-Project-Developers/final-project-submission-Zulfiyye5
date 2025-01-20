using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
       public class UserManager
    {
        private static UserManager _instance;
        public static UserManager Instance => _instance ??= new UserManager();

        public int UserId { get; set; }

       public string UserName { get; set; }=string.Empty;
        public string Email { get; set; } = string.Empty;
        private UserManager() { }
    }
}

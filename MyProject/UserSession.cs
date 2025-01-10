using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
       public class UserSession
    {
        private static UserSession _instance;
        public static UserSession Instance => _instance ??= new UserSession();

        public int UserId { get; set; }

       public string UserName { get; set; }=string.Empty;
        public string Email { get; set; } = string.Empty;
        private UserSession() { }
    }
}

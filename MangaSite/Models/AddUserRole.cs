using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangaSite.Models
{
    public class AddUserRole
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public List<string> roles { get; set; }
        public AddUserRole()
        {
            roles = new List<string>();
        }
    }
}
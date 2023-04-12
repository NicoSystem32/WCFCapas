using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteUsers.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
    }
}
using SiteUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteUsers.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult UserManagement()
        {
            // Generate a list of random users            
            var users = new List<User>();
            for (int i = 0; i < 10; i++)
            {
                var user = new User
                {
                    Name = GetRandomName(),
                    DateOfBirth = GetRandomDate(),
                    Gender = GetRandomGender()
                };
                users.Add(user);
            }

            // Pass the list of users to the view
            return View(users);
        }

        public ActionResult InsertUser(string username) {

            
            return View();
        }

        // Helper methods to generate random user data
        private string GetRandomName()
        {
            string[] names = { "Nico F", "Liz T", "Grecia F", "Joaquín F", "Caroll F" };
            return names[new Random().Next(0, names.Length)];
        }

        private DateTime GetRandomDate()
        {
            var start = new DateTime(1950, 1, 1);
            var end = new DateTime(2005, 12, 31);
            int range = (end - start).Days;
            return start.AddDays(new Random().Next(range));
        }

        private string GetRandomGender()
        {
            string[] genders = { "M", "F" };
            return genders[new Random().Next(0, genders.Length)];
        }

    }
}

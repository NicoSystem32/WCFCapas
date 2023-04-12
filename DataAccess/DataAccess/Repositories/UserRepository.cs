using DataAccess.DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess.Repositories
{
    public class UserRepository: IUserRepository
    {
        public async Task<List<Users>> GetUsersAsync()
        {
            using (var context = new WCFUsersEntities())
            {
                return await context.Users.ToListAsync();
            }
        }

    }
}

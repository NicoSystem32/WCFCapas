using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<List<Users>> GetUsersAsync();
    }
}

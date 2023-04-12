using Business.ModelsContract;
using DataAccess.DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{

    public class UserBusiness : IUsersBusiness
    {

        private readonly IUserRepository _usersRepository;

        public UserBusiness(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<List<UserBusinessModel>> GetUsersAsync()
        {            
            List<Users> userData = await _usersRepository.GetUsersAsync();
            List<UserBusinessModel> userBusiness = MapUserDataToBusiness(userData);
            return userBusiness;
            
        }

        private List<UserBusinessModel> MapUserDataToBusiness(List<Users> userData)
        {
            return userData.Select(u => new UserBusinessModel
            {
                UserId = u.IdUser,
                Name = u.Nombre,
                DateOfBirth = u.FechaNacimiento,
                Gender = u.Sexo
            }).ToList();
        }
    }
}

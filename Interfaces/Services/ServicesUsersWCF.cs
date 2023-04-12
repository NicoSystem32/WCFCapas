using DataAccess.DataAccess.Interfaces;
using DataAccess.Models;
using Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicesUsersWCF" en el código y en el archivo de configuración a la vez.
    public class ServicesUsersWCF : IServicesUsersWCF
    {
        private readonly IUserRepository _usersRepository;

        public ServicesUsersWCF(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<List<UserBusinessModel>> GetUsersAsync()
        {
            List<Users> userData = await _usersRepository.GetUsersAsync();
            List<UserBusinessModel> userBusiness = MapUserDataToBusiness(userData);
            return userBusiness;
        }

        //public async Task CreateUserAsync(UserBusinessModel user)
        //{
        //    UserDataModel userData = MapBusinessToUserData(user);
        //    await _userRepository.CreateUserAsync(userData);
        //}

        //public async Task UpdateUserAsync(UserBusinessModel user)
        //{
        //    UserDataModel userData = MapBusinessToUserData(user);
        //    await _userRepository.UpdateUserAsync(userData);
        //}

        //public async Task DeleteUserAsync(int userId)
        //{
        //    await _userRepository.DeleteUserAsync(userId);
        //}

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

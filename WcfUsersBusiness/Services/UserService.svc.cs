using DataAccess.DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WcfUsersBusiness.ModelsContract;

namespace WcfUsersBusiness
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UserService : IUsersService
    {
        private readonly IUserRepository _usersRepository;

        public UserService()
        {
            // Aquí puedes inicializar tus variables o recursos
        }
        public UserService(IUserRepository usersRepository)
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

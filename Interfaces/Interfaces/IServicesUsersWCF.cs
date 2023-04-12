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
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicesUsersWCF" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicesUsersWCF
    {
        [OperationContract]
        Task<List<UserBusinessModel>> GetUsersAsync();

        //[OperationContract]
        //Task CreateUserAsync(UserBusinessModel user);

        //[OperationContract]
        //Task UpdateUserAsync(UserBusinessModel user);

        //[OperationContract]
        //Task DeleteUserAsync(int userId);
    }
}

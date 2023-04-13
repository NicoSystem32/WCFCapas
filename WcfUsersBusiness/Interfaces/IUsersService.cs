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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsersService
    {
        /// <summary>
        /// Obtiene la lista de usuarios.
        /// </summary>
        /// <returns>Una lista de objetos de negocio UserBusinessModel.</returns>
        /// <remarks>Autor: Nicolás Flórez.</remarks>
        [OperationContract]
        List<UserBusinessModel> GetUsers();

        /// <summary>
        /// Inserta un usuario.
        /// </summary>
        /// <param name="userToInsert">El objeto de negocio UserBusinessModel a insertar.</param>
        /// <returns>True si la operación fue exitosa, de lo contrario false.</returns>
        /// <remarks>Autor: Nicolás Flórez.</remarks>
        [OperationContract]
        bool InsertUser(UserBusinessModel userToInsert);

        /// <summary>
        /// Edita un usuario.
        /// </summary>
        /// <param name="userToEdit">El objeto de negocio UserBusinessModel a editar.</param>
        /// <returns>True si la operación fue exitosa, de lo contrario false.</returns>
        /// <remarks>Autor: Nicolás Flórez.</remarks>
        [OperationContract]
        bool EditUser(UserBusinessModel userToEdit);

        /// <summary>
        /// Elimina un usuario.
        /// </summary>
        /// <param name="userToDelete">El identificador del usuario a eliminar.</param>
        /// <returns>True si la operación fue exitosa, de lo contrario false.</returns>
        /// <remarks>Autor: Nicolás Flórez.</remarks>
        [OperationContract]
        bool DeleteUser(int userToDelete);

    }

}

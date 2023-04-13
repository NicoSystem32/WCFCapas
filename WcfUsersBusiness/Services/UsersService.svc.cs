using DataAccess.DataAccess.Interfaces;
using DataAccess.DataAccess.Repositories;
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
    
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    /// <summary>
    /// Implementación de la interfaz IUsersService para manejar la lógica de negocios de usuarios.
    /// Autor: Nicolás Flórez
    /// </summary>
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _usersRepository;

        public UsersService()
        {
            _usersRepository = new UserRepository();
        }

        /// <summary>
        /// Obtiene una lista de todos los usuarios.
        /// </summary>
        /// <returns>Lista de objetos UserBusinessModel.</returns>
        public List<UserBusinessModel> GetUsers()
        {
            List<Users> userData = _usersRepository.GetUsers();
            List<UserBusinessModel> userBusiness = MapUserDataToBusiness(userData);
            return userBusiness;

        }

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="userToInsert">Objeto UserBusinessModel con la información del usuario a insertar.</param>
        /// <returns>True si el usuario fue insertado correctamente, false en caso contrario.</returns>
        public bool InsertUser(UserBusinessModel userToInsert)
        {

            Users user = new Users
            {
                Nombre = userToInsert.Name,
                FechaNacimiento = userToInsert.DateOfBirth,
                Sexo = userToInsert.Gender
            };

            var isInsert = _usersRepository.InsertUser(user);

            return isInsert;

        }

        /// <summary>
        /// Actualiza la información de un usuario existente en la base de datos.
        /// </summary>
        /// <param name="userToEdit">Objeto UserBusinessModel con la información del usuario a actualizar.</param>
        /// <returns>True si el usuario fue actualizado correctamente, false en caso contrario.</returns>
        public bool EditUser(UserBusinessModel userToEdit)
        {

            Users user = new Users
            {
                IdUser = userToEdit.UserId,
                Nombre = userToEdit.Name,
                FechaNacimiento = userToEdit.DateOfBirth,
                Sexo = userToEdit.Gender
            };

            var isEdit = _usersRepository.EditUser(user);

            return isEdit;
        }

        /// <summary>
        /// Elimina un usuario existente en la base de datos.
        /// </summary>
        /// <param name="id">Id del usuario a eliminar.</param>
        /// <returns>True si el usuario fue eliminado correctamente, false en caso contrario.</returns>
        public bool DeleteUser(int id)
        {
            var isDelete = _usersRepository.DeleteUser(id);
            return isDelete;
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

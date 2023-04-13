using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccess.Interfaces
{
    /// <summary>
    /// Interfaz para acceder a los usuarios almacenados en un repositorio de datos.
    /// </summary>
    /// <remarks>
    /// Esta interfaz define los métodos necesarios para leer, insertar, editar y eliminar usuarios
    /// en un repositorio de datos específico. 
    /// </remarks>
    /// <author>Nicolás Flórez</author>
    public interface IUserRepository
    {
        /// <summary>
        /// Obtiene una lista con todos los usuarios almacenados en el repositorio.
        /// </summary>
        /// <returns>Una lista de objetos Users que representan a los usuarios almacenados.</returns>
        List<Users> GetUsers();

        /// <summary>
        /// Inserta un nuevo usuario en el repositorio.
        /// </summary>
        /// <param name="userToInsert">El objeto Users que contiene los datos del usuario a insertar.</param>
        /// <returns>Un valor booleano que indica si la operación de inserción fue exitosa.</returns>
        bool InsertUser(Users userToInsert);

        /// <summary>
        /// Edita los datos de un usuario existente en el repositorio.
        /// </summary>
        /// <param name="userToEdit">El objeto Users que contiene los nuevos datos del usuario a editar.</param>
        /// <returns>Un valor booleano que indica si la operación de edición fue exitosa.</returns>
        bool EditUser(Users userToEdit);

        /// <summary>
        /// Elimina un usuario del repositorio.
        /// </summary>
        /// <param name="id">El identificador del usuario a eliminar.</param>
        /// <returns>Un valor booleano que indica si la operación de eliminación fue exitosa.</returns>
        bool DeleteUser(int id);
    }

}

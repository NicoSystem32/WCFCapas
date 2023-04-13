using DataAccess.DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.DataAccess.Repositories
{
    public class UserRepository: IUserRepository
    {
        /// <summary>
        /// Obtiene una lista de todos los usuarios.
        /// </summary>
        /// <returns>Lista de usuarios.</returns>
        public List<Users> GetUsers()
        {
            try
            {
                using (var context = new WCFUsersEntities())
                {
                    return context.Users.ToList();
                }
            }
            catch (Exception ex)
            {
                //Registro en el log de errores
                return null;
            }
        }

        /// <summary>
        /// Inserta un nuevo usuario.
        /// Tambien está comentada la parte endonde se puede trabajar con el mapeo de tablas de entity framework
        /// </summary>
        /// <param name="userToInsert">Usuario a insertar.</param>
        /// <returns>True si la inserción es exitosa, de lo contrario false.</returns>
        public bool InsertUser(Users userToInsert)
        {
            try
            {
                //Usando el contexto con la tabla directamente
                /*using (var context = new WCFUsersEntities())
                {
                    context.Users.Add(userToInsert);
                    context.SaveChanges();
                }
                return true;*/

                //Usando un SP
                using (var context = new WCFUsersEntities())
                {
                    var parameters = new SqlParameter[] {
                        new SqlParameter("@Name", userToInsert.Nombre),
                        new SqlParameter("@DateOfBirth", userToInsert.FechaNacimiento),
                        new SqlParameter("@Gender", userToInsert.Sexo),
                        new SqlParameter("@Action", "CREATE"),
                        new SqlParameter("@RowsAffected", SqlDbType.Int) { Direction = ParameterDirection.Output }
                    };

                    context.Database.ExecuteSqlCommand("SP_USERS_CRUD @Name=@Name, @DateOfBirth=@DateOfBirth, @Gender=@Gender, @Action=@Action, @RowsAffected=@RowsAffected OUTPUT", parameters);
                    int rowsAffected = (int)parameters[4].Value;
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                };
            }
            catch (Exception ex)
            {
                //Registro en el log de errores
                return false;
            }
        }


        /// <summary>
        /// Edita un usuario en la base de datos utilizando un procedimiento almacenado.
        /// Tambien está comentada la parte endonde se puede trabajar con el mapeo de tablas de entity framework
        /// </summary>
        /// <param name="userToEdit">El usuario a editar.</param>
        /// <returns>True si se editó correctamente, False si no se pudo editar.</returns>
        /// <remarks>Este método utiliza un procedimiento almacenado para realizar la edición del usuario en la base de datos.</remarks>
        /// <author>Nicolás Flórez</author>
        public bool EditUser(Users userToEdit)
        {
            try
            {
                //Usando un SP
                using (var context = new WCFUsersEntities())
                {
                    var parameters = new SqlParameter[] {
                    new SqlParameter("@Id", userToEdit.IdUser),
                    new SqlParameter("@Name", userToEdit.Nombre),
                    new SqlParameter("@DateOfBirth", userToEdit.FechaNacimiento),
                    new SqlParameter("@Gender", userToEdit.Sexo),
                    new SqlParameter("@Action", "UPDATE"),
                    new SqlParameter("@RowsAffected", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };

                    context.Database.ExecuteSqlCommand("SP_USERS_CRUD @Id=@Id, @Name=@Name, @DateOfBirth=@DateOfBirth, @Gender=@Gender, @Action=@Action, @RowsAffected=@RowsAffected OUTPUT", parameters);
                    int rowsAffected = (int)parameters[5].Value;
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                };

                //Usando la tabla mapeada por entity framework
                //using (var context = new WCFUsersEntities())
                //{
                //    var userToUpdate = context.Users.FirstOrDefault(u => u.IdUser == userToEdit.IdUser);

                //    if (userToUpdate != null)
                //    {
                //        userToUpdate.Nombre = userToEdit.Nombre;
                //        userToUpdate.FechaNacimiento = userToEdit.FechaNacimiento;
                //        userToUpdate.Sexo = userToEdit.Sexo;

                //        context.SaveChanges();
                //        return true;
                //    }
                //    else {
                //        return false;
                //    }
            //}
            }
            catch (Exception ex)
            {
                //Registro en el log de errores
                return false;
            }
        }

        /// <summary>
        /// Elimina un usuario de la base de datos utilizando un procedimiento almacenado.
        /// Tambien está comentada la parte endonde se puede trabajar con el mapeo de tablas de entity framework
        /// </summary>
        /// <param name="id">El Id del usuario a eliminar.</param>
        /// <returns>True si se eliminó correctamente, False si no se pudo eliminar.</returns>
        /// <remarks>Este método utiliza un procedimiento almacenado para eliminar el usuario de la base de datos.</remarks>
        /// <author>Nicolás Flórez</author>
        public bool DeleteUser(int id)
        {
            //Usando un SP
            using (var context = new WCFUsersEntities())
            {
                var parameters = new SqlParameter[] {
                    new SqlParameter("@Id", id),
                    new SqlParameter("@Action", "DELETE"),
                    new SqlParameter("@RowsAffected", SqlDbType.Int) { Direction = ParameterDirection.Output }
                };

                context.Database.ExecuteSqlCommand("SP_USERS_CRUD @Id=@Id, @Action=@Action, @RowsAffected=@RowsAffected OUTPUT", parameters);
                int rowsAffected = (int)parameters[2].Value;
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };


            //Usando la tabla mapeada por entity framework
            //using (var context = new WCFUsersEntities())
            //{
            //    var user = context.Users.FirstOrDefault(u => u.IdUser == id);
            //    if (user != null)
            //    {
            //        context.Users.Remove(user);
            //        context.SaveChanges();
            //        return true;
            //    }
            //    return false;
            //}
        }

    }
}

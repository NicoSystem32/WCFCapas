using SiteUsers.Models;
using SiteUsers.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteUsers.Controllers
{
    /**
    Controlador encargado de manejar las peticiones relacionadas con la gestión de usuarios    
    */
    public class UsersController : Controller
    {

        /// <summary>
        /// Acción que muestra la vista de administración de usuarios y muestra los usuarios almacenados en la base de datos.
        /// Aquí se hace la solicitud al WCF
        /// </summary>
        /// <returns>La vista de administración de usuarios con los datos de los usuarios en la base de datos.</returns>
        /// <author>Nicolás Flórez</author>
        public ActionResult UserManagement()
        {
            using (UsersServiceClient users = new UsersServiceClient())
            {
                var userInDataBase = users.GetUsers();

                var userViewModels = userInDataBase.Select(u => new UserViewModel
                {
                    Id = u.UserId,
                    Name = u.Name,
                    Gender = u.Gender,
                    DateOfBirth = u.DateOfBirth,
                    Age = DateTime.Today.Year - u.DateOfBirth.Year
                }).ToList();

                return View(userViewModels);
            }
        }

        /// <summary>
        /// Método que inserta un nuevo usuario en la base de datos.
        /// Aquí se hace la solicitud al WCF
        /// </summary>
        /// <param name="userToInsert">Objeto de tipo UserBusinessModel que contiene los datos del usuario a insertar.</param>
        /// <returns>Un objeto JsonResult que indica si la inserción fue exitosa o no y un mensaje correspondiente.</returns>
        /// <author>Nicolás Flórez</author>
        [HttpPost]
        public JsonResult InsertUser(UserBusinessModel userToInsert)
        {
            using (UsersServiceClient users = new UsersServiceClient())
            {
                var isInsert = users.InsertUser(userToInsert);
                if (isInsert)
                {
                    return Json(new { success = true, message = "¡Usuario insertado correctamente!" });
                }
                else
                {
                    return Json(new { success = false, message = "No se pudo insertar el usuario." });
                }
            }
        }

        /// <summary>
        /// Acción que muestra la vista de inserción de usuarios.
        /// </summary>
        /// <param name="username">Nombre del usuario.</param>
        /// <returns>La vista de inserción de usuarios.</returns>
        /// <author>Nicolás Flórez</author>
        public ActionResult InsertUser(string username)
        {
            return View();
        }



        /// <summary>
        /// Muestra la vista de gestión de usuarios con la información de los usuarios obtenida desde el servicio.
        /// Aquí se hace la solicitud al WCF
        /// </summary>
        /// <returns>La vista de gestión de usuarios con la información de los usuarios obtenida desde el servicio.</returns>
        /// <author>Nicolás Flórez</author>
        public ActionResult Edit(int id)
        {
            UserViewModel userToEdit = new UserViewModel();
            using (UsersServiceClient users = new UsersServiceClient())
            {
                var allUsers = users.GetUsers();
                var allUsersList = allUsers.Select(u => new UserViewModel
                {
                    Id = u.UserId,
                    Name = u.Name,
                    Gender = u.Gender,
                    DateOfBirth = u.DateOfBirth,
                    Age = DateTime.Today.Year - u.DateOfBirth.Year
                }).ToList();

                userToEdit = allUsersList.Where(u => u.Id == id).FirstOrDefault();
            }


            if (userToEdit == null)
            {
                return HttpNotFound();
            }

            return View("EditUser", userToEdit);
        }

        /// <summary>
        /// Edita el usuario dado en el servicio si la información proporcionada es válida.
        /// Aquí se hace la solicitud al WCF
        /// </summary>
        /// <param name="userToEdit">El usuario a editar.</param>
        /// <returns>Un JsonResult que indica si la operación fue exitosa y un mensaje correspondiente.</returns>
        /// <author>Nicolás Flórez</author>
        [HttpPost]
        public ActionResult EditUser(UserBusinessModel userToEdit)
        {
            if (ModelState.IsValid)
            {
                using (UsersServiceClient users = new UsersServiceClient())
                {
                    var result = users.EditUser(userToEdit);
                    if (result)
                    {
                        return Json(new { success = true, message = "user edited successfully" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "User no edit" });
                    }
                }
            }
            else
            {
                return Json(new { success = false, message = "Error: Data incorrect " });
            }
        }

        /// <summary>
        /// Elimina el usuario con el ID especificado del servicio.
        /// Aquí se hace la solicitud al WCF
        /// </summary>
        /// <param name="userIdToDelete">El ID del usuario a eliminar.</param>
        /// <returns>Un JsonResult que indica si la operación fue exitosa y un mensaje correspondiente.</returns>
        /// <author>Nicolás Flórez</author>
        [HttpPost]
        public ActionResult DeleteUser(int userIdToDelete)
        {
            if (userIdToDelete > 0)
            {
                using (UsersServiceClient users = new UsersServiceClient())
                {
                    var result = users.DeleteUser(userIdToDelete);
                    if (result)
                    {
                        return Json(new { success = true, message = "User deleted successfully" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "User not deleted" });
                    }
                }
            }
            else
            {
                return Json(new { success = false, message = "Error: Invalid user ID" });
            }
        }


    }
}

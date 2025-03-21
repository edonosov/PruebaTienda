using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tienda
{
    /// <summary>
    /// Representa un usuario en el sistema.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Contraseña del usuario (privada).
        /// </summary>
       // private string Password { get; set; }

        /// <summary>
        /// Rol del usuario (por defecto 'User').
        /// </summary>
        public string Rol { get; set; } = "User";

        /// <summary>
        /// Constructor de la clase Usuario.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="password"></param>
        /// <param name="rol"></param>
        public Usuario(string nombre, string password, string rol)
        {
            Nombre = nombre;
            //Password = password;
            Rol = rol;
        }

        /// <summary>
        /// Valida si la contraseña es correcta.
        /// </summary>
        /// <param name="password">Contraseña ingresada.</param>
        /// <returns>Verdadero si la contraseña es correcta, falso en caso contrario.</returns>
        /*public bool Autenticar(string password)
        {
            return Password == password;
        }*/
    }
}
 
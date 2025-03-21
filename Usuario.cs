using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tienda
{
    public class Usuario
    {
        private List<Usuario> usuarios = new List<Usuario>();
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        private string Password { get; set; }

        /// <summary>
        /// Método para validar a un usuario con su contraseña.
        /// </summary>

        public Usuario(string nombre, string password)
        {
            Nombre = nombre;
            Password = password;
        }

        /// <summary>
        /// Valida si la contraseña es la misma que ha introducido el usuario
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Autenticar(string password)
        {
            return Password == password;
        }

        /// <summary>
        /// Método para obtener un usuario desde un archivo de texto.
        /// </summary>  
        /// <param name="nombre">Nombre del usuario a buscar</param>
        /// <returns>Nuevo Usuario si se encuentra, null si no</returns>
        #region Obtener
        public static Usuario Obtener(string nombre)
        {
            if (!File.Exists("usuarios.txt")) return null;
            string[] lineas = File.ReadAllLines("usuarios.txt");
            foreach (var linea in lineas)
            {
                var datos = linea.Split(',');
                if (datos[0] == nombre)
                {
                    return new Usuario(datos[0], datos[1]);
                }
            }
            return null;
        }


        #endregion

        #region CargarUsuarios
        /// <summary>
        /// Cargar la lista de usuarios
        /// </summary>

        private void CargarUsuarios()
        {
            usuarios.Add(new Usuario("admin", "admin"));
            usuarios.Add(new Usuario("cliente", "1234"));
            usuarios.Add(new Usuario("emma", "emma"));
        }
        #endregion

    }
}
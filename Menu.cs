using System;
using System.Collections.Generic;

namespace Tienda
{
    /// <summary>
    /// Representa un menú con una lista de opciones disponibles para el usuario.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Identificador único del menú.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del menú que se mostrará en la interfaz de usuario.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Lista de opciones disponibles dentro del menú.
        /// </summary>
        public List<Opciones> OpcionesMenu { get; set; } = new List<Opciones>();

        /// <summary>
        /// Muestra el menú con todas sus opciones en la consola.
        /// </summary>
        public void MostrarMenu()
        {
            Console.WriteLine(Nombre);
            foreach (var opcion in OpcionesMenu)
            {
                Console.WriteLine($"{opcion.Id}\t {opcion.Nombre}\t  {opcion.Descripcion}\n");
            }
        }
    }

    /// <summary>
    /// Representa una opción dentro de un menú.
    /// </summary>
    public class Opciones
    {
        /// <summary>
        /// Identificador único de la opción en el menú.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la opción que aparecerá en el menú.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Breve descripción de lo que hace la opción.
        /// </summary>
        public string Descripcion { get; set; }

    }
}

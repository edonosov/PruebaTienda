using System;
using System.Collections.Generic;

namespace Tienda
{
    /// <summary>
    /// Representa un menú con la lista de opciones disponibles
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Identificador del menu
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre del menu
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Lista de opciones del menú
        /// </summary>
        public List<Opciones> OpcionesMenu { get; set; } = new List<Opciones>();
        /// <summary>
        /// Constructor del menu
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="opciones">Lista de opciones del menu</param>
        public Menu(string nombre, List<Opciones> opciones)
        {
            Nombre = nombre;
            OpcionesMenu = opciones;
        }
        /// <summary>
        /// Muestra las opciones del menu
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
    /// Representa una opción dentro del menú
    /// </summary>
    public class Opciones
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Opciones(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }

}

using System;
using System.Collections.Generic;

namespace Tienda
{
    /// <summary>
    /// Clase que gestiona un menú con opciones dinámicas y su ejecución.
    /// Asigna números secuenciales a las opciones para mostrarlas de forma ordenada.
    /// </summary>
    public class MenuOpciones
    {
        /// <summary>
        /// Diccionario que mapea un número secuencial con la opción real del menú.
        /// </summary>
        private readonly Dictionary<int, OpcionMenu> opcionesIndexadas;

        /// <summary>
        /// Diccionario que almacena las acciones asociadas a cada opción del menú.
        /// </summary>
        private readonly Dictionary<OpcionMenu, Action> accion;

        /// <summary>
        /// Nombre del menú que se mostrará al usuario.
        /// </summary>
        public string Nombre { get; }

        /// <summary>
        /// Constructor de la clase MenuOpciones.
        /// Asigna el nombre del menú y organiza las opciones en un orden secuencial.
        /// </summary>
        /// <param name="nombre">Nombre del menú.</param>
        /// <param name="opciones">Diccionario de opciones del menú y sus acciones asociadas.</param>
        public MenuOpciones(string nombre, Dictionary<OpcionMenu, Action> opciones)
        {
            Nombre = nombre;
            accion = opciones;
            opcionesIndexadas = new Dictionary<int, OpcionMenu>();

            int index = 1;
            foreach (var opcion in opciones.Keys)
            {
                opcionesIndexadas[index++] = opcion;
            }
        }

        /// <summary>
        /// Muestra el menú y permite al usuario seleccionar y ejecutar una opción.
        /// </summary>
        public void Ejecutar()
        {
            while (true)
            {
                Console.WriteLine($"\n{Nombre}");

                /// <summary> 
                /// Muestra las opciones con números secuenciales 
                /// </summary>
                foreach (var kvp in opcionesIndexadas)
                    Console.WriteLine($"{kvp.Key}. {kvp.Value}");

                /// <summary> 
                /// Obtiene la selección del usuario y valida que esté en el rango 
                /// </summary>
                int seleccion = Program.ObtenerOpcion("Seleccione una opción:", 1, opcionesIndexadas.Count);
                if (!opcionesIndexadas.ContainsKey(seleccion))
                {
                    Console.WriteLine("Opción no válida.");
                    continue;
                }

                /// <summary> 
                /// Obtiene la opción real y ejecuta la acción correspondiente 
                /// </summary>
                OpcionMenu opcionReal = opcionesIndexadas[seleccion];
                if (opcionReal == OpcionMenu.Salir) break;
                accion[opcionReal].Invoke();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tienda
{
    /// <summary>
    /// Representa un producto dentro de la tienda.
    /// Contiene información como ID, nombre, precio, stock y descripción.
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// Identificador del producto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Precio del producto.
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Cantidad de productos disponibles en stock.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Descripción opcional del producto. Por defecto, indica "Sin descripción".
        /// </summary>
        public string Descripcion { get; set; } = " ";

        /// <summary>
        /// Devuelve una cadena con los datos del producto separados por comas
        /// </summary>
        /// <returns>Cadena con ID, nombre, precio, stock y descripción del producto.</returns>
        public override string ToString()
        {
            return $"{Id}, {Nombre}, {Precio}, {Stock}, {Descripcion}";
        }

        /// <summary>
        /// Carga la lista de productos desde un archivo de texto.
        /// </summary>
        /// <returns>Lista de productos leídos desde el archivo `productos.txt`.</returns>
        public static List<Producto> CargarProductos()
        {
            var productos = new List<Producto>();
            if (File.Exists("productos.txt"))
            {
                foreach (var linea in File.ReadAllLines("productos.txt"))
                {
                    var datos = linea.Split(',');
                    productos.Add(new Producto
                    {
                        Id = int.Parse(datos[0]),
                        Nombre = datos[1],
                        Precio = decimal.Parse(datos[2]),
                        Stock = int.Parse(datos[3]),
                        Descripcion = datos.Length > 4 ? datos[4] : " "
                    });
                }
            }
            return productos;
        }

        /// <summary>
        /// Guarda la lista de productos en un archivo de texto.
        /// </summary>
        /// <param name="productos">Lista de productos a guardar.</param>
        public static void GuardarProductos(List<Producto> productos)
        {
            File.WriteAllLines("productos.txt", productos.Select(p => p.ToString()));
        }
    }
}

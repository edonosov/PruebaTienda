using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tienda
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public Producto(int id, string nombre, decimal precio, int stock)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"{Id},{Nombre},{Precio},{Stock}";
        }

        /// <summary>
        /// Carga los productos desde un archivo de texto
        /// </summary>
        public static List<Producto> CargarProductos()
        {
            var productos = new List<Producto>();
            if (File.Exists("productos.txt"))
            {
                foreach (var linea in File.ReadAllLines("productos.txt"))
                {
                    var datos = linea.Split(',');
                    productos.Add(new Producto(int.Parse(datos[0]), datos[1], decimal.Parse(datos[2]), int.Parse(datos[3])));
                }
            }
            return productos;
        }

        /// <summary>
        /// Guarda la lista de productos en un archivo de texto
        /// </summary>
        public static void GuardarProductos(List<Producto> productos)
        {
            File.WriteAllLines("productos.txt", productos.Select(p => p.ToString()));
        }
    }
}

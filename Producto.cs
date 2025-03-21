using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tienda

{
    public class Producto
    {
        private List<Producto> productos = new List<Producto>();
        /// <summary>
        /// Identificador del producto 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Precio del producto
        /// </summary>
        public decimal Precio { get; set; }
        /// <summary>
        /// Stock del producto
        /// </summary>
        public int Stock { get; set; }
        /// <summary>
        /// Constructor de la clase producto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        public Producto(int id, string nombre, decimal precio, int stock)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }
        /// <summary>
        /// Método que te devuelve los datos del producto
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return $"{Id},{Nombre},{Precio},{Stock}";
        }
        #region CargarProductos
        /// <summary>
        /// Carga la lista de productos desde el archivo productos.txt
        /// </summary>
        private void CargarProductos()
        {
            if (File.Exists("productos.txt"))
            {
                foreach (var linea in File.ReadAllLines("productos.txt"))
                {
                    var datos = linea.Split(',');
                    productos.Add(new Producto(int.Parse(datos[0]), datos[1], decimal.Parse(datos[2]), int.Parse(datos[3])));
                }
            }
        }
        #endregion

        #region GuardarProductos
        /// <summary>
        /// Guardar los productos en el archivo de productos. 
        /// </summary>
        private void GuardarProductos()
        {
            File.WriteAllLines("productos.txt", productos.Select(p => p.ToString()));
        }
        #endregion
    }
}

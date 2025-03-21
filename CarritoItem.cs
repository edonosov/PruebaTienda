using System.Collections.Generic;

namespace Tienda
{
    #region CarritoItem
    public class CarritoItem
    {
        private List<CarritoItem> carrito = new List<CarritoItem>();
        /// <summary>
        /// Producto que están en el carrito
        /// </summary>
        public Producto Producto { get; set; }
        /// <summary>
        /// Cantidad de producto en el carrito
        /// </summary>
        public int Cantidad { get; set; }
        /// <summary>
        /// Constructor de la clase carrito
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="cantidad"></param>
        public CarritoItem(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }
        /// <summary>
        /// Devuelve los datos de los productos que están en el carrito
        /// </summary>
        /// <returns>Una cadena con el nombre del producto, cantidad y total</returns>
        public override string ToString()
        {
            return $"{Producto.Nombre} x {Cantidad} - Total: {Producto.Precio * Cantidad}";
        }
    }
    #endregion
}

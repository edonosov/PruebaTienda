using System;

namespace Tienda
{
    public class CarritoItem
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public CarritoItem(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }
        /// <summary>
        /// Si hay algo en el carrito te devuelve el producto y la cantidad y el precio total
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Producto.Nombre} x {Cantidad} - Total: {Producto.Precio * Cantidad}";
        }
    }
}

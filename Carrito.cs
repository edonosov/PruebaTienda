using System;
using System.Collections.Generic;
using System.Linq;

namespace Tienda
{
    /// <summary>
    /// Representa el carrito de compras, almacenando los productos y sus cantidades.
    /// </summary>
    public class Carrito
    {
        /// <summary>
        /// Lista de productos en el carrito junto con sus cantidades
        /// </summary>
        private List<(Producto producto, int cantidad)> Items { get; set; } = new List<(Producto, int)>();

        /// <summary>
        /// Agrega un producto al carrito en la cantidad especificada.
        /// </summary>
        /// <param name="producto">El producto que se desea agregar.</param>
        /// <param name="cantidad">La cantidad del producto a añadir.</param>
        public void AgregarAlCarrito(Producto producto, int cantidad)
        {
            if (producto.Stock < cantidad)
            {
                Console.WriteLine("No hay suficiente stock disponible.");
                return; //hola
            }

            /// <summary> Verifica si el producto ya está en el carrito </summary>
            var itemExistente = Items.FirstOrDefault(i => i.producto.Id == producto.Id);
            if (itemExistente.producto != null)
            {
                Items.Remove(itemExistente);
                Items.Add((producto, itemExistente.cantidad + cantidad));
            }
            else
            {
                Items.Add((producto, cantidad));
            }

            producto.Stock -= cantidad;
            Console.WriteLine($"Se han añadido {cantidad} unidades de {producto.Nombre} al carrito.");
        }

        /// <summary>
        /// Muestra los productos en el carrito con sus cantidades y el total a pagar.
        /// </summary>
        public void VerCarrito()
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }

            Console.WriteLine("\nCarrito de compras:");
            decimal total = 0;
            foreach (var (producto, cantidad) in Items)
            {
                decimal subtotal = producto.Precio * cantidad;
                total += subtotal;
                Console.WriteLine($"{producto.Nombre} x {cantidad} - Total: {subtotal:C}");
            }
            Console.WriteLine($"Total a pagar: {total:C}");
        }

        /// <summary>
        /// Vacía el carrito de compras
        /// </summary>
        public void VaciarCarrito()
        {
            Items.Clear();
            Console.WriteLine("El carrito ha sido vaciado.");
        }
    }
}

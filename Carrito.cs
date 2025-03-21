using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    using System;
    using System.Collections.Generic;

    namespace Tienda
    {
        public class Carrito
        {
            public List<CarritoItem> Items { get; private set; } = new List<CarritoItem>();

            /// <summary>
            /// Agrega un producto al carrito
            /// </summary>
            public void AgregarAlCarrito(Producto producto, int cantidad)
            {
                Items.Add(new CarritoItem(producto, cantidad));
                producto.Stock -= cantidad;
            }

            /// <summary>
            /// Muestra los productos en el carrito
            /// </summary>
            public void VerCarrito()
            {
                Console.WriteLine("\nCarrito de compras:");
                foreach (var item in Items)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }

}

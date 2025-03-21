using System;
using System.Collections.Generic;
using System.Linq;
using Tienda.Tienda;

namespace Tienda
{
    public class Program
    {
        /// <summary>
        /// Lista de usuarios registrados en el sistema.
        /// </summary>
        private static List<Usuario> usuarios = new List<Usuario>();

        /// <summary>
        /// Lista de productos disponibles en la tienda.
        /// </summary>
        private static List<Producto> productos = Producto.CargarProductos();

        /// <summary>
        /// Instancia del carrito de compras.
        /// </summary>
        private static Carrito carrito = new Carrito();

        /// <summary>
        /// Método principal del programa. Muestra el menú de usuario y administrador.
        /// </summary>
        static void Main()
        {
            var opcionesAdmin = new List<Opciones>
            {
            /// <summary>
            /// Opciones disponibles para el administrador en el menú.
            /// </summary>
                new Opciones(1, "Listar Productos", "(Muestra todos los productos disponibles)"),
                new Opciones(2, "Añadir Producto", "(Permite agregar un nuevo producto)"),
                new Opciones(3, "Eliminar Producto", "(Elimina un producto de la lista)"),
                new Opciones(4, "Salir", "(Salir del menú de administrador)")
            };

            var opcionesUsuario = new List<Opciones>
            {
            /// <summary>
            /// Opciones disponibles para el usuario en el menú.
            /// </summary>
                new Opciones(1, "Comprar", "(Realizar una compra de productos)"),
                new Opciones(2, "Listar Productos", "(Ver la lista de productos disponibles)"),
                new Opciones(3, "Ver Carrito", "(Revisar el carrito de compras)"),
                new Opciones(4, "Salir", "(Salir del menú de usuario)")
            };

            var menuAdmin = new Menu("Menú Administrador", opcionesAdmin);
            var menuUsuario = new Menu("Menú Usuario", opcionesUsuario);

            while (true)
            {
                Console.WriteLine("Seleccione el tipo de usuario: \n1. Administrador \n2. Usuario \n3. Salir");
                string opcionUsuario = Console.ReadLine();

                if (opcionUsuario == "1")
                {
                    menuAdmin.MostrarMenu();
                    Console.Write("Seleccione una opción: ");
                    int opcion = int.Parse(Console.ReadLine());
                    if (opcion == 1) ListarProductos();
                    else if (opcion == 2) AgregarProducto();
                    else if (opcion == 3) EliminarProducto();
                }
                else if (opcionUsuario == "2")
                {
                    menuUsuario.MostrarMenu();
                    Console.Write("Seleccione una opción: ");
                    int opcion = int.Parse(Console.ReadLine());
                    if (opcion == 1) ComprarProducto();
                    else if (opcion == 2) ListarProductos();
                    else if (opcion == 3) carrito.VerCarrito();
                }
                else if (opcionUsuario == "3")
                {
                    Console.WriteLine("¡Adiós!");
                    break;
                }
                else
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                }
            }
        }

        /// <summary>
        /// Muestra la lista de productos disponibles en la tienda.
        /// </summary>
        private static void ListarProductos()
        {
            Console.WriteLine("\nLista de productos disponibles:");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto);
            }
        }

        /// <summary>
        /// Permite al administrador agregar un nuevo producto a la tienda.
        /// </summary>
        private static void AgregarProducto()
        {
            Console.Write("Ingrese el ID del producto: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el precio del producto: ");
            decimal precio = decimal.Parse(Console.ReadLine());
            Console.Write("Ingrese la cantidad disponible: ");
            int cantidad = int.Parse(Console.ReadLine());

            productos.Add(new Producto(id, nombre, precio, cantidad));
            Producto.GuardarProductos(productos);
            Console.WriteLine("Producto agregado exitosamente.");
        }

        /// <summary>
        /// Permite al administrador eliminar un producto existente de la tienda.
        /// </summary>
        private static void EliminarProducto()
        {
            Console.Write("Ingrese el ID del producto a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            var producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto != null)
            {
                productos.Remove(producto);
                Producto.GuardarProductos(productos);
                Console.WriteLine("Producto eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        /// <summary>
        /// Permite al usuario comprar un producto de la tienda.
        /// </summary>
        private static void ComprarProducto()
        {
            ListarProductos();
            Console.Write("Ingrese el ID del producto que desea comprar: ");
            int id = int.Parse(Console.ReadLine());
            var producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto != null && producto.Stock > 0)
            {
                Console.Write("Ingrese la cantidad a comprar: ");
                int cantidad = int.Parse(Console.ReadLine());

                if (cantidad <= producto.Stock)
                {
                    carrito.AgregarAlCarrito(producto, cantidad);
                    producto.Stock -= cantidad;
                    Producto.GuardarProductos(productos);
                    Console.WriteLine("Producto agregado al carrito.");
                }
                else
                {
                    Console.WriteLine("No hay suficiente stock disponible.");
                }
            }
            else
            {
                Console.WriteLine("Producto no encontrado o sin stock.");
            }
        }
    }
}

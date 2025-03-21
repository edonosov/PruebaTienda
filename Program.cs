using System.Collections.Generic;
using System;

namespace Tienda
{
    public class Program
    {
        /// <summary>
        /// Lista de productos cargados desde el archivo.
        /// </summary>
        private static List<Producto> productos = Producto.CargarProductos();

        /// <summary>
        /// Instancia del carrito de compras.
        /// </summary>
        private static Carrito carrito = new Carrito();

        /// <summary>
        /// Método principal donde se ejecuta el programa.
        /// Permite al usuario seleccionar el tipo de menú (Admin o Usuario) y navegar a través de las opciones.
        /// </summary>
        static void Main()
        {
            // Opciones generales disponibles para ambos menús
            var opcionesGenerales = new Dictionary<OpcionMenu, Action>
            {
                { OpcionMenu.ListarProductos, ListarProductos }
            };

            // Menú de administrador con las opciones correspondientes
            var menuAdmin = new MenuOpciones("Menú Administrador", new Dictionary<OpcionMenu, Action>(opcionesGenerales)
            {
                { OpcionMenu.AgregarProducto, AgregarProducto },
                { OpcionMenu.EliminarProducto, EliminarProducto },
                { OpcionMenu.Salir, () => Console.WriteLine("Saliendo del menú administrador...") }
            });

            // Menú de usuario con las opciones correspondientes
            var menuUsuario = new MenuOpciones("Menú Usuario", new Dictionary<OpcionMenu, Action>(opcionesGenerales)
            {
                { OpcionMenu.ComprarProducto, ComprarProducto },
                { OpcionMenu.VerCarrito, carrito.VerCarrito },
                { OpcionMenu.Salir, () => Console.WriteLine("Saliendo del menú usuario...") }
            });

            // Bucle principal del programa donde se selecciona el tipo de usuario
            while (true)
            {
                Console.WriteLine("Seleccione usuario:\n1. Admin\n2. Usuario\n3. Salir");

                // Verifica que la opción seleccionada esté dentro del rango permitido
                if (!int.TryParse(Console.ReadLine(), out int opcionUsuario) || opcionUsuario < 1 || opcionUsuario > 3)
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    continue;
                }

                // Si se selecciona "Salir", termina el programa
                if (opcionUsuario == 3) break;

                // Ejecuta el menú correspondiente dependiendo del tipo de usuario
                (opcionUsuario == 1 ? menuAdmin : menuUsuario).Ejecutar();
            }
        }

        /// <summary>
        /// Obtiene una opción numérica del usuario con un rango válido.
        /// </summary>
        /// <param name="mensaje">El mensaje que se muestra al usuario.</param>
        /// <param name="min">Valor mínimo permitido.</param>
        /// <param name="max">Valor máximo permitido.</param>
        /// <returns>La opción seleccionada por el usuario.</returns>
        public static int ObtenerOpcion(string mensaje, int min, int max)
        {
            int opcion;
            do
                Console.Write(mensaje + " ");
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < min || opcion > max);
            return opcion;
        }

        /// <summary>
        /// Muestra la lista de productos disponibles.
        /// </summary>
        private static void ListarProductos() =>
            Console.WriteLine("\n" + string.Join("\n", productos));

        /// <summary>
        /// Agrega un nuevo producto a la lista de productos.
        /// </summary>
        private static void AgregarProducto()
        {
            // Solicita la información del nuevo producto
            productos.Add(new Producto(
                ObtenerOpcion("ID del producto:", 1, int.MaxValue),
                ObtenerTexto("Nombre del producto:"),
                ObtenerDecimal("Precio del producto:"),
                ObtenerOpcion("Cantidad disponible:", 0, int.MaxValue)
            ));

            // Guarda los cambios en el archivo
            Producto.GuardarProductos(productos);
        }

        /// <summary>
        /// Elimina un producto de la lista de productos, dado su ID.
        /// </summary>
        private static void EliminarProducto()
        {
            int id = ObtenerOpcion("ID del producto a eliminar:", 1, int.MaxValue);

            // Intenta eliminar el producto con el ID indicado
            if (productos.RemoveAll(p => p.Id == id) > 0)
                Producto.GuardarProductos(productos);  // Guarda los cambios si el producto fue eliminado
            else
                Console.WriteLine("Producto no encontrado.");
        }

        /// <summary>
        /// Permite al usuario comprar un producto seleccionando su ID y cantidad.
        /// </summary>
        private static void ComprarProducto()
        {
            ListarProductos();

            // Solicita el ID del producto que el usuario quiere comprar
            int id = ObtenerOpcion("ID del producto a comprar:", 1, int.MaxValue);
            var producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto != null && producto.Stock > 0)
            {
                // Solicita la cantidad a comprar, asegurándose de que no exceda el stock disponible
                int cantidad = ObtenerOpcion("Cantidad a comprar:", 1, producto.Stock);
                carrito.AgregarAlCarrito(producto, cantidad);  // Agrega el producto al carrito
                producto.Stock -= cantidad;  // Reduce el stock del producto
                Producto.GuardarProductos(productos);  // Guarda los cambios en el archivo de productos
            }
            else
                Console.WriteLine("Producto no encontrado o sin stock.");
        }

        /// <summary>
        /// Solicita al usuario un valor decimal de manera segura.
        /// </summary>
        /// <param name="mensaje">Mensaje para indicar al usuario qué valor se debe ingresar.</param>
        /// <returns>El valor decimal ingresado por el usuario.</returns>
        private static decimal ObtenerDecimal(string mensaje)
        {
            decimal valor;
            do
                Console.Write(mensaje + " ");
            while (!decimal.TryParse(Console.ReadLine(), out valor) || valor <= 0);
            return valor;
        }

        /// <summary>
        /// Solicita al usuario una cadena de texto.
        /// </summary>
        /// <param name="mensaje">Mensaje que se muestra para indicar qué información se debe ingresar.</param>
        /// <returns>La cadena de texto ingresada por el usuario.</returns>
        private static string ObtenerTexto(string mensaje)
        {
            Console.Write(mensaje + " ");
            return Console.ReadLine();
        }
    }

    /// <summary>
    /// Enum que representa las diferentes opciones disponibles en el menú.
    /// </summary>
    public enum OpcionMenu
    {
        ListarProductos = 1,
        AgregarProducto = 2,
        EliminarProducto = 3,
        ComprarProducto = 4,
        VerCarrito = 5,
        Salir = 6
    }
}


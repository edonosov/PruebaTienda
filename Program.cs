using System;
using System.Collections.Generic;
using System.Linq;


namespace Tienda
{
    /// <summary>
    /// Clase principal que ejecuta el programa de la tienda.
    /// Maneja la lógica del menú y las operaciones de productos y carrito.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Lista de productos disponibles en la tienda.
        /// Se cargan desde un archivo al iniciar el programa.
        /// </summary>
        private static List<Producto> productos = Producto.CargarProductos();

        /// <summary>
        /// se almacenan los productos que el usuario quiere comprar.
        /// </summary>
        private static Carrito carrito = new Carrito();

        /// <summary>
        /// Método principal del programa.
        /// Muestra los menús de administrador y usuario, y permite seleccionar opciones.
        /// </summary>
        static void Main()
        {
            ///<summary> Opciones comunes a ambos menús </summary>
            var opcionesGenerales = new Dictionary<OpcionMenu, Action>
            {
                { OpcionMenu.ListarProductos, ListarProductos }
            };

            /// <summary>Menú del Administrador con opciones específicas</summary>
            var menuAdmin = new MenuOpciones("Menú Administrador", new Dictionary<OpcionMenu, Action>(opcionesGenerales)
            {
                { OpcionMenu.AgregarProducto, AgregarProducto },
                { OpcionMenu.EliminarProducto, EliminarProducto },
                { OpcionMenu.Salir, () => Console.WriteLine("Saliendo del menú administrador...") }
            });

            /// <summary> Menú del Usuario con opciones específicas </summary>
            var menuUsuario = new MenuOpciones("Menú Usuario", new Dictionary<OpcionMenu, Action>(opcionesGenerales)
            {
                { OpcionMenu.ComprarProducto, ComprarProducto },
                { OpcionMenu.VerCarrito, carrito.VerCarrito },
                { OpcionMenu.Salir, () => Console.WriteLine("Saliendo del menú usuario...") }
            });



            /// <summary> 
            /// Bucle principal de ejecución del programa, verifica que la opción es válida y si no da error. Si si, ejecuta la opcion correspondiente.
            /// </summary>

            while (true)
            {
                Console.WriteLine("Seleccione usuario:\n1. Admin\n2. Usuario\n3. Salir");
                if (!int.TryParse(Console.ReadLine(), out int opcionUsuario) || opcionUsuario < 1 || opcionUsuario > 3)
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    continue;
                }

                if (opcionUsuario == 3) break;
                (opcionUsuario == 1 ? menuAdmin : menuUsuario).Ejecutar();
            }
        }

        /// <summary>
        /// Solicita al usuario un número dentro de un rango válido.
        /// </summary>
        /// <param name="mensaje">Mensaje que se muestra al usuario.</param>
        /// <param name="min">Valor mínimo permitido.</param>
        /// <param name="max">Valor máximo permitido.</param>
        /// <returns>El número ingresado por el usuario.</returns>
        public static int ObtenerOpcion(string mensaje, int min, int max)
        {
            int opcion;
            do Console.Write(mensaje + " ");
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < min || opcion > max);
            return opcion;
        }

        /// <summary>
        /// Muestra la lista de productos disponibles en la tienda.
        /// </summary>
        private static void ListarProductos() =>
            Console.WriteLine("\n" + string.Join("\n", productos));

        /// <summary>
        /// Permite agregar un nuevo producto a la tienda solicitando datos al usuario
        /// </summary>
        private static void AgregarProducto()
        {
            productos.Add(new Producto
            {
                Id = ObtenerOpcion("ID del producto:", 1, int.MaxValue),
                Nombre = ObtenerTexto("Nombre del producto:"),
                Precio = ObtenerDecimal("Precio del producto:"),
                Stock = ObtenerOpcion("Cantidad disponible:", 0, int.MaxValue),
                Descripcion = ObtenerTexto("Descripción del producto (opcional):")
            });
            Producto.GuardarProductos(productos);
        }

        /// <summary>
        /// Permite eliminar un producto de la tienda mediante su ID.
        /// </summary>
        private static void EliminarProducto()
        {
            int id = ObtenerOpcion("ID del producto a eliminar:", 1, int.MaxValue);
            if (productos.RemoveAll(p => p.Id == id) > 0)
                Producto.GuardarProductos(productos);
            else Console.WriteLine("Producto no encontrado.");
        }

        /// <summary>
        /// Permite al usuario comprar un producto seleccionando su ID y cantidad.
        /// </summary>
        private static void ComprarProducto()
        {
            ListarProductos();
            int id = ObtenerOpcion("ID del producto que desea comprar:", 1, int.MaxValue);
            var producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto != null && producto.Stock > 0)
            {
                int cantidad = ObtenerOpcion("Cantidad a comprar:", 1, producto.Stock);
                carrito.AgregarAlCarrito(producto, cantidad);
                producto.Stock -= cantidad;
                Producto.GuardarProductos(productos);
            }
            else Console.WriteLine("Producto no encontrado o sin stock.");
        }

        /// <summary>
        /// Solicita al usuario un valor decimal dentro de un rango válido.
        /// </summary>
        /// <param name="mensaje">Mensaje que se muestra al usuario.</param>
        /// <returns>El valor decimal ingresado por el usuario.</returns>
        private static decimal ObtenerDecimal(string mensaje)
        {
            decimal valor;
            do Console.Write(mensaje + " ");
            while (!decimal.TryParse(Console.ReadLine(), out valor) || valor <= 0);
            return valor;
        }

        /// <summary>
        /// Solicita al usuario una entrada de texto.
        /// </summary>
        /// <param name="mensaje">Mensaje que se muestra al usuario.</param>
        /// <returns>La cadena de texto ingresada por el usuario.</returns>
        private static string ObtenerTexto(string mensaje)
        {
            Console.Write(mensaje + " ");
            return Console.ReadLine();
        }
    }

    /// <summary>
    /// Enumeración de las opciones disponibles en el menú de la tienda.
    /// </summary>
    public enum OpcionMenu
    {
        /// <summary>
        /// Opción para listar los productos disponibles en la tienda.
        /// </summary>
        ListarProductos = 1,

        /// <summary>
        /// Opción para agregar un nuevo producto a la tienda.
        /// </summary>
        AgregarProducto = 2,

        /// <summary>
        /// Opción para eliminar un producto de la tienda.
        /// </summary>
        EliminarProducto = 3,

        /// <summary>
        /// Opción para comprar un producto y agregarlo al carrito.
        /// </summary>
        ComprarProducto = 4,

        /// <summary>
        /// Opción para ver los productos que hay en el carrito de compras.
        /// </summary>
        VerCarrito = 5,

        /// <summary>
        /// Opción para salir del menú y terminar el programa.
        /// </summary>
        Salir = 6
    }
}

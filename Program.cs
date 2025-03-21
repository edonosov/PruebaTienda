using System;
using System.Collections.Generic;
using System.Linq;

namespace Tienda
{
    public class Program
    {
        private static List<Producto> productos = Producto.CargarProductos();
        private static Carrito carrito = new Carrito();

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var opcionesGenerales = new Dictionary<OpcionMenu, Action>
            {
                { OpcionMenu.ListarProductos, ListarProductos }
            };

            var menuAdmin = new MenuOpciones("Menú Administrador", new Dictionary<OpcionMenu, Action>(opcionesGenerales)
            {
                { OpcionMenu.AgregarProducto, AgregarProducto },
                { OpcionMenu.EliminarProducto, EliminarProducto },
                { OpcionMenu.Salir, () => Console.WriteLine("Saliendo del menú administrador...") }
            });

            var menuUsuario = new MenuOpciones("Menú Usuario", new Dictionary<OpcionMenu, Action>(opcionesGenerales)
            {
                { OpcionMenu.ComprarProducto, ComprarProducto },
                { OpcionMenu.VerCarrito, carrito.VerCarrito },
                { OpcionMenu.Salir, () => Console.WriteLine("Saliendo del menú usuario...") }
            });

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

        public static int ObtenerOpcion(string mensaje, int min, int max)
        {
            int opcion;
            do Console.Write(mensaje + " ");
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < min || opcion > max);
            return opcion;
        }

        private static void ListarProductos() =>
            Console.WriteLine("\n" + string.Join("\n", productos));

        private static void AgregarProducto()
        {
            Console.WriteLine("\nLista actual de productos:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"{producto}\n ");
            }

            int id = ObtenerOpcion("ID del producto:", 1, int.MaxValue);

            if (productos.Any(p => p.Id == id))
            {
                Console.WriteLine("Error: Ya existe un producto con este ID.");
                return;
            }

            Producto nuevoProducto = new Producto
            {
                Id = id,
                Nombre = ObtenerTexto("Nombre del producto:").Trim(),
                Precio = ObtenerDecimal("Precio del producto:"),
                Stock = ObtenerOpcion("Cantidad disponible:", 0, int.MaxValue),
                Descripcion = ObtenerTexto("Descripción del producto (opcional):").Trim()
            };

            productos.Add(nuevoProducto);
            Producto.GuardarProductos(productos);

            Console.WriteLine("Producto añadido y guardado correctamente.");
        }


        private static void EliminarProducto()
        {
            Console.WriteLine("\nLista actual de productos:");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto);
            }

            int id = ObtenerOpcion("ID del producto a eliminar:", 1, int.MaxValue);

            var productoAEliminar = productos.FirstOrDefault(p => p.Id == id);
            if (productoAEliminar == null)
            {
                Console.WriteLine("Error: Producto no encontrado.");
                return;
            }

            productos.Remove(productoAEliminar);
            Producto.GuardarProductos(productos);

            Console.WriteLine("Producto eliminado correctamente.");
        }



        private static void ComprarProducto()
        {
            ListarProductos();
            int id = ObtenerOpcion("ID del producto que desea comprar:", 1, int.MaxValue);
            var producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto != null && producto.Stock > 0)
            {
                int cantidad = ObtenerOpcion("Cantidad a comprar:", 1, producto.Stock);
                carrito.AgregarAlCarrito(producto, cantidad);
                Producto.GuardarProductos(productos);
            }
            else Console.WriteLine("Producto no encontrado o sin stock.");
        }

        private static decimal ObtenerDecimal(string mensaje)
        {
            decimal valor;
            do Console.Write(mensaje + " ");
            while (!decimal.TryParse(Console.ReadLine(), out valor) || valor <= 0);
            return valor;
        }

        private static string ObtenerTexto(string mensaje)
        {
            Console.Write(mensaje + " ");
            return Console.ReadLine();
        }
    }

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

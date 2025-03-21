using System;

namespace Tienda
{
    class Program
    {
        /// <summary>
        /// Método principal, inicializa y ejecuta la tienda
        /// </summary>
        /*
         *  public Tienda()
        {
            CargarUsuarios();
            CargarProductos();
        }
        #region Iniciar
        /// <summary>
        /// Permite a los usuarios iniciar sesión o salir de la página, se repite continuamente
        /// </summary>
        public void Iniciar()
        {
            while (true)
            {
                Console.WriteLine("Bienvenido a la Tienda");
                Console.WriteLine("1. Iniciar Sesión");
                Console.WriteLine("2. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out int opcion))
                {
                    Console.WriteLine("Error: opción inválida.");
                    continue;
                }

                if (opcion == 2) break;

                Console.Write("Usuario: ");
                string usuario = Console.ReadLine().Trim();
                Console.Write("Contraseña: ");
                string password = Console.ReadLine().Trim();

                Usuario user = Usuario.Obtener(usuario);
                if (user != null && user.Autenticar(password))
                {
                    if (usuario == "admin")
                        MenuAdmin();
                    else
                        MenuUsuario(user);
                }
                else
                {
                    Console.WriteLine("Usuario o contraseña incorrectos.");
                }
            }
        }
        #endregion



        #region MenuAdmin
        /// <summary>
        /// Menu del administrador, solo se ejecuta con una cu
        /// </summary>
        private void MenuAdmin()
        {
            while (true)
            {
                Console.WriteLine("Menú Administrador:");
                Console.WriteLine("1. Listar productos");
                Console.WriteLine("2. Añadir producto");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Volver al menú principal");

                if (!int.TryParse(Console.ReadLine(), out int opcion)) continue;

                switch (opcion)
                {
                    case 1:
                        productos.ForEach(Console.WriteLine);
                        break;
                    case 2:
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine().Trim());
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine().Trim();
                        Console.Write("Precio: ");
                        decimal precio = decimal.Parse(Console.ReadLine().Trim());
                        Console.Write("Stock: ");
                        int stock = int.Parse(Console.ReadLine().Trim());
                        productos.Add(new Producto(id, nombre, precio, stock));
                        GuardarProductos();
                        Console.WriteLine("Producto añadido correctamente.");
                        break;
                    case 3:
                        Console.Write("Nombre del producto a eliminar: ");
                        string nombreEliminar = Console.ReadLine().Trim().ToLower();
                        productos.RemoveAll(p => p.Nombre.ToLower() == nombreEliminar);
                        GuardarProductos();
                        Console.WriteLine("Producto eliminado correctamente.");
                        break;
                    case 4:
                        return;
                }
            }
        }
        #endregion

        #region MenuUsuario
        private void MenuUsuario(Usuario usuario)
        {
            Console.WriteLine("Bienvenido" +usuario.Nombre);
        }
        #endregion
    }
         */
        static void Main()
        {
            Tienda tienda = new Tienda();
            tienda.Iniciar();
        }
    }
}
using System.Collections.Generic;
using System;

namespace Tienda
{
    /// <summary>
    /// Representa un menú con las opciones disponibles para el usuario.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Identificador del menú.
        /// </summary>
        public int Id { get; set; }
        #region Explicacion1
        /* 1.public: Este es el modificador de acceso de la propiedad. Significa que la propiedad Id es 
         * accesible desde cualquier parte del código, es decir, es pública.
         * 
         * 2.int: Esto indica el tipo de datos de la propiedad. En este caso, la propiedad Id es de tipo entero 
         * (int). Esto significa que esta propiedad almacenará un número entero.
         * 
         * 3.Id: Este es el nombre de la propiedad. En este caso, se llama Id, que generalmente es un 
         * identificador único para objetos en muchas aplicaciones, como el ID de un producto o de un 
         * usuario.
         * 
         * 4.{ get; set; }: Estas son las definiciones de los métodos get y set de la propiedad. Estos 
         * son métodos automáticos de acceso a la propiedad.
         * get: Permite obtener el valor de la propiedad.
         * set: Permite asignar un valor a la propiedad.
         */
        #endregion

        /// <summary>
        /// Nombre del menú.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Lista de opciones disponibles en el menú.
        /// </summary>
        public List<Opciones> OpcionesMenu { get; set; } = new List<Opciones>();
        #region Explicacion2
        /* 1.public: Es un modificador de acceso. Significa que la propiedad OpcionesMenu puede ser accedida 
         * desde fuera de la clase Menu, es decir, cualquier otra clase puede leer y modificar esta 
         * propiedad si lo desea.
         * 
         * 2.List<Opciones>: Es el tipo de la propiedad. Es una lista (List) que contiene objetos de tipo 
         * Opciones. Una List es una colección genérica que permite almacenar elementos de un tipo 
         * específico de manera ordenada. El tipo de los elementos de la lista es la clase Opciones, 
         * que representa una opción de menú con propiedades como Id, Nombre, y Descripcion.
         * 
         * 3.OpcionesMenu: Es el nombre de la propiedad. En este caso, es un nombre descriptivo que indica 
         * que esta propiedad contiene las opciones del menú.
         * 
         * 4.{ get; set; }:
         * get: Permite obtener el valor de la propiedad. Es el "accesor" que permite leer el valor de 
         * OpcionesMenu.
         * set: Permite modificar el valor de la propiedad. Es el "mutador" que permite establecer un 
         * nuevo valor para OpcionesMenu.
         * 
         * 5.= new List<Opciones>();: Este es el valor predeterminado de la propiedad. Aquí, se está 
         * inicializando la lista OpcionesMenu con una nueva instancia de List<Opciones>. Esto significa 
         * que, cuando se crea una nueva instancia de Menu, la propiedad OpcionesMenu empieza vacía, 
         * pero lista para almacenar objetos de tipo Opciones.
         * 
         * En resumen: La propiedad OpcionesMenu es una lista que guarda las diferentes opciones de un menú.
         * Cada opción está representada por un objeto de la clase Opciones, y la lista está inicializada 
         * en su declaración para que siempre comience vacía pero lista para agregar elementos.
         */
        #endregion


        /// <summary>
        /// Constructor del menú.
        /// </summary>
        /// <param name="nombre">Nombre del menú.</param>
        /// <param name="opciones">Lista de opciones del menú.</param>
        public Menu(string nombre, List<Opciones> opciones)
        {
            Nombre = nombre;
            OpcionesMenu = opciones;
        }
        #region ExplicacionConstructor
        /* 1.public Menu(string nombre, List<Opciones> opciones):
         * public: El modificador de acceso public indica que el constructor puede ser llamado desde fuera 
         * de la clase Menu. Es accesible a cualquier otra clase que necesite crear una instancia de Menu.
         * Menu: Es el nombre del constructor. En C#, el constructor tiene el mismo nombre que la clase.
         * (string nombre, List<Opciones> opciones): Estos son los parámetros que acepta el constructor. 
         * En este caso, el constructor requiere:
         * nombre: Un parámetro de tipo string, que representa el nombre del menú.
         * opciones: Un parámetro de tipo List<Opciones>, que es una lista de objetos Opciones que 
         * representa las diferentes opciones que tendrá el menú.
         * 
         * Nombre = nombre;: Esta línea asigna el valor del parámetro nombre a la propiedad Nombre de la 
         * clase Menu. Es decir, el valor de nombre que se pasa al crear una instancia de Menu se guarda 
         * en la propiedad Nombre.
         * OpcionesMenu = opciones;: Esta línea asigna la lista de opciones que se pasa como parámetro 
         * (opciones) a la propiedad OpcionesMenu. Es decir, se guarda la lista de opciones proporcionada 
         * en el momento de la creación del menú.
         * 
         * Propósito del Constructor: El constructor Menu(string nombre, List<Opciones> opciones) tiene 
         * como objetivo inicializar un nuevo objeto de la clase Menu, asignándole un nombre y un conjunto 
         * de opciones. Este constructor es útil cuando quieres crear un menú específico con un nombre y 
         * una lista de opciones que puedes manejar más tarde.
         */
        #endregion


        /// <summary>
        /// Muestra las opciones del menú al usuario.
        /// </summary>
        public void MostrarMenu()
        {
            Console.WriteLine(Nombre);
            foreach (var opcion in OpcionesMenu)
            {
                Console.WriteLine($"{opcion.Id}\t {opcion.Nombre}\t  {opcion.Descripcion}\n");
            }
        }
        #region MostrarMenu
        /* 1.public void MostrarMenu(): public: Este modificador de acceso indica que la función puede ser 
         * llamada desde otras clases.
         * void: La función no devuelve ningún valor (no tiene un tipo de retorno, como int, string, etc.).
         * MostrarMenu: El nombre de la función. Esta función es responsable de mostrar las opciones de un 
         * menú en la consola.
         * 
         * 2.Console.WriteLine(Nombre);: Este comando imprime el nombre del menú en la consola.
         * Nombre es una propiedad de la clase Menu que contiene el nombre del menú (por ejemplo, "Menú Administrador").
         * Console.WriteLine() es un método de C# que imprime texto en la consola seguido de un salto de línea.
         * 3.foreach (var opcion in OpcionesMenu): Este es un bucle foreach que recorre cada elemento en la 
         * lista OpcionesMenu. Cada elemento de la lista es un objeto de tipo Opciones, que representa una 
         * opción en el menú (con propiedades como Id, Nombre, Descripcion).
         * var es un tipo implícito que permite a C# determinar automáticamente el tipo del objeto basado en el tipo 
         * del elemento dentro de OpcionesMenu (en este caso, es un objeto de tipo Opciones).
         * opcion es una variable temporal que representa cada objeto Opciones dentro de la lista OpcionesMenu en 
         * cada iteración del bucle.
         * 4.Console.WriteLine($"{opcion.Id}\t {opcion.Nombre}\t {opcion.Descripcion}\n");: Este comando 
         * imprime una línea por cada opción del menú.
         * $"{opcion.Id}\t {opcion.Nombre}\t {opcion.Descripcion}\n" es una cadena interpolada que permite incluir las propiedades del objeto opcion directamente dentro del texto que se imprime:
         * opcion.Id: Muestra el Id de la opción (un número único que identifica cada opción).
         * opcion.Nombre: Muestra el nombre de la opción (por ejemplo, "Ver Productos").
         * opcion.Descripcion: Muestra la descripción de la opción (por ejemplo, "Muestra todos los 
         * productos disponibles").
         * El \t inserta un tabulador entre los valores para separar las columnas de forma ordenada.
         * El \n añade un salto de línea después de cada opción para que las opciones se muestren de manera 
         * ordenada, con una línea en blanco entre ellas. 
         * Resumen de la Función MostrarMenu: 
         * Esta función tiene como propósito mostrar el nombre del menú y luego imprimir las opciones 
         * disponibles en ese menú, con su Id, Nombre y Descripcion. Cada opción se muestra de manera 
         * tabulada para que sea más legible y ordenada. 
         * Utiliza un bucle foreach para recorrer todas las opciones del menú y luego imprimir cada una en 
         * la consola.
         */
        #endregion
    }

    /// <summary>
    /// Representa una opción dentro del menú.
    /// </summary>
    public class Opciones
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        /// <summary>
        /// Constructor de la opción del menú.
        /// </summary>
        /// <param name="id">Identificador de la opción.</param>
        /// <param name="nombre">Nombre de la opción.</param>
        /// <param name="descripcion">Descripción de la opción.</param>
        public Opciones(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
    #region Opciones
    /* 1.public class Opciones: La palabra clave public significa que la clase Opciones es accesible desde 
     * otras clases en el programa.
     * class es la palabra clave que define una nueva clase.
     * Opciones es el nombre de la clase. Esta clase se utiliza para representar una opción dentro de un 
     * menú, con un identificador (Id), un nombre (Nombre) y una descripción (Descripcion).
     * 
     * 2.public int Id { get; set; }:
     * public: El modificador de acceso permite que esta propiedad sea accesible desde cualquier lugar.
     * int Id: Define una propiedad de tipo int que representará el identificador único de la opción dentro 
     * del menú. Este identificador se usa para diferenciar las opciones entre sí.
     * { get; set; }: Estas son las propiedades automáticas en C#, lo que significa que el compilador crea 
     * de manera implícita los métodos get y set para obtener y asignar el valor de Id.
     * 
     * 3.public string Nombre { get; set; }: string Nombre: Define una propiedad de tipo string que contiene
     * el nombre de la opción, como "Ver Productos" o "Agregar Producto".
     * { get; set; }: Igual que en la propiedad Id, esto permite acceder y modificar el valor de la propiedad Nombre.
     * 
     * 4.public string Descripcion { get; set; }: string Descripcion: Define una propiedad de tipo string 
     * que describe la opción en detalle. Por ejemplo, "Muestra todos los productos disponibles". 
     * { get; set; }: De nuevo, permite el acceso y la modificación del valor de la propiedad Descripcion.
     * 
     * 5.Constructor Opciones(int id, string nombre, string descripcion): public Opciones(int id, 
     * string nombre, string descripcion): Este es el constructor de la clase Opciones. Se llama cada vez 
     * que se crea un nuevo objeto de tipo Opciones. El constructor permite inicializar los valores de las 
     * propiedades de la clase cuando se crea el objeto.
     * int id: El parámetro id es utilizado para asignar el valor a la propiedad Id de la clase Opciones.
     * string nombre: El parámetro nombre es utilizado para asignar el valor a la propiedad Nombre de la 
     * clase Opciones.
     * string descripcion: El parámetro descripcion es utilizado para asignar el valor a la 
     * propiedad Descripcion de la clase Opciones.
     * Dentro del constructor: Los valores de los parámetros (id, nombre, descripcion) se asignan a las 
     * propiedades correspondientes de la clase (Id, Nombre, Descripcion).
     * 
     * Resumen: 
     * La clase Opciones se usa para representar una opción dentro de un menú.
     * Cada opción tiene tres propiedades: Id, Nombre y Descripcion.
     * El constructor permite crear objetos de tipo Opciones inicializando esas propiedades con valores 
     * específicos.
     * Se usa en la clase Menu para definir las opciones disponibles para el usuario.
     */
    #endregion
}


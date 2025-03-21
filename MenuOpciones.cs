using System.Collections.Generic;
using System;

namespace Tienda
{
    /// <summary>
    /// Clase que gestiona un menú con opciones dinámicas y su ejecución.
    /// Asigna números secuenciales a las opciones para mostrarlas de forma ordenada.
    /// </summary>
    public class MenuOpciones
    {
        /// <summary>
        /// Diccionario que mapea un número secuencial con la opción real del menú.
        /// </summary>
        private readonly Dictionary<int, OpcionMenu> opcionesIndexadas;
        #region opcionesIndexadas
        /* 1.private: Esto indica que la variable opcionesIndexadas es accesible solo dentro de la clase 
         * MenuOpciones. No puede ser accedida ni modificada desde fuera de la clase, lo que ayuda a 
         * encapsular los detalles de implementación.
         * 
         * 2.readonly: El modificador readonly significa que una vez que la variable se ha asignado en su 
         * declaración o en el constructor de la clase, su valor no puede cambiar. Esto garantiza que el 
         * diccionario opcionesIndexadas no será modificado después de su inicialización, asegurando la 
         * inmutabilidad para evitar errores.
         * 
         * 3.Dictionary<int, OpcionMenu>: 
         * Dictionary<key, value> es una estructura de datos que almacena pares de clave y valor. En este 
         * caso, int es el tipo de la clave, y OpcionMenu es el tipo del valor.
         * int: La clave será un número entero (por ejemplo, el número de la opción en el menú).
         * OpcionMenu: Es el valor asociado a cada clave. Este es un tipo de enumeración o clase que 
         * representa la opción de menú, dependiendo de cómo se haya definido en tu código. Podría representar 
         * los distintos elementos que aparecen en el menú, como "Listar productos", "Comprar producto", 
         * "Salir", etc.
         * 
         * 4.opcionesIndexadas: Este es el nombre de la variable. Es una colección (un diccionario) que 
         * mapea un número entero (que probablemente representa la opción del menú) con su correspondiente 
         * valor de tipo OpcionMenu.
         * 
         * Resumen:
         * La línea private readonly Dictionary<int, OpcionMenu> opcionesIndexadas; declara un diccionario 
         * que asocia números (que representan las opciones del menú) con las acciones que deben realizarse 
         * cuando se seleccionan esas opciones. La estructura es inmutable después de la inicialización, 
         * lo que garantiza que las opciones del menú no cambien accidentalmente durante la ejecución del 
         * programa.
         */
        #endregion

        /// <summary>
        /// Diccionario que almacena las acciones asociadas a cada opción del menú.
        /// </summary>
        private readonly Dictionary<OpcionMenu, Action> acciones;
        #region Acciones
        /* 1.Dictionary<OpcionMenu, Action>: 
         * Dictionary es una colección que almacena pares de clave-valor. En este caso:
         * Clave (OpcionMenu): La clave es de tipo OpcionMenu. Esto probablemente se refiere a una 
         * enumeración (enum) que representa las distintas opciones del menú. Por ejemplo, ListarProductos, 
         * AgregarProducto, EliminarProducto, etc.
         * Valor (Action): El valor asociado con cada clave es de tipo Action. Action es un delegado que 
         * representa un método que no toma parámetros y no devuelve un valor (es decir, métodos que 
         * ejecutan una acción, pero no devuelven nada).
         * Esto implica que el diccionario acciones almacenará acciones (métodos) asociadas con cada 
         * opción de menú.
         * 
         * 2.acciones:
         * Este es el nombre de la variable que está declarando un diccionario. En este diccionario, 
         * las claves son las opciones del menú (OpcionMenu) y los valores son las acciones que se deben 
         * ejecutar cuando se elige cada opción.
         * 
         * Resumen: 
         * La línea private readonly Dictionary<OpcionMenu, Action> acciones; declara un 
         * diccionario que mapea las opciones del menú (tipo OpcionMenu) a sus respectivas acciones 
         * (métodos, representados por Action). Esto permite una manera flexible y dinámica de asociar 
         * opciones de menú con sus correspondientes métodos sin tener que escribir condicionales 
         * complicados (como if o switch) en el código.
         */
        #endregion

        /// <summary>
        /// Nombre del menú que se mostrará al usuario.
        /// </summary>
        public string Nombre { get; }
        #region Explicacion1
        /* 1.public:
         * public es un modificador de acceso. Esto significa que la propiedad Nombre es accesible desde 
         * cualquier otra parte del código, tanto dentro de la clase donde se define como desde otras 
         * clases que instancien objetos de esa clase.
         * 
         * 2.string:
         * string es el tipo de datos de la propiedad. En este caso, Nombre es de tipo string, lo que 
         * significa que esta propiedad almacenará un valor de texto (cadena de caracteres).
         * 
         * Nombre:
         * Nombre es el nombre de la propiedad. Las propiedades en C# funcionan como métodos, pero permiten 
         * que los datos sean accedidos y modificados de una manera más clara y sencilla. Aquí, Nombre 
         * representa el nombre de algún objeto o entidad dentro de la clase, y se usará para obtener ese 
         * valor.
         * 
         * { get; }:
         * get; es el getter de la propiedad. Es un método implícito que permite acceder al valor de la 
         * propiedad. En este caso, se permite leer el valor de Nombre.
         * El hecho de que no haya un set; significa que la propiedad Nombre es solo de lectura y no puede 
         * ser modificada una vez que ha sido asignada, es decir, no se puede cambiar su valor desde fuera 
         * de la clase. En otras palabras, Nombre es una propiedad de solo lectura.
         * 
         * Resumen:
         * La línea public string Nombre { get; } declara una propiedad de solo lectura llamada Nombre. 
         * Esta propiedad almacena un valor de tipo string que se puede acceder, pero no modificar 
         * directamente después de que se haya inicializado en el constructor o en algún otro lugar dentro 
         * de la clase.
         */
        #endregion


        /// <summary>
        /// Constructor de la clase MenuOpciones.
        /// Asigna el nombre del menú y organiza las opciones en un orden secuencial.
        /// </summary>
        /// <param name="nombre">Nombre del menú.</param>
        /// <param name="opciones">Diccionario de opciones del menú y sus acciones asociadas.</param>
        public MenuOpciones(string nombre, Dictionary<OpcionMenu, Action> opciones)
        {
            Nombre = nombre;
            acciones = opciones;
            opcionesIndexadas = new Dictionary<int, OpcionMenu>();

            int index = 1;
            foreach (var opcion in opciones.Keys)
            {
                opcionesIndexadas[index++] = opcion;
            }
        }
        #region ConstructorMenuOpciones 
        /* 1.public MenuOpciones(string nombre, Dictionary<OpcionMenu, Action> opciones):
         * Este es el constructor de la clase MenuOpciones.
         * El constructor se utiliza para inicializar un nuevo objeto de tipo MenuOpciones.
         * Recibe dos parámetros:
         * nombre: un string que probablemente representa el nombre del menú.
         * opciones: un diccionario (Dictionary<OpcionMenu, Action>) que contiene las opciones disponibles 
         * en el menú, donde cada OpcionMenu es la clave (probablemente un valor de un enum) y Action es la 
         * acción asociada a esa opción (es decir, lo que se ejecutará cuando se seleccione esa opción).
         * 
         * 2.Nombre = nombre;:
         * Aquí se asigna el valor de nombre (pasado como parámetro al constructor) a la propiedad Nombre 
         * de la clase MenuOpciones.
         * Esto establece el nombre del menú para el objeto MenuOpciones.
         * 
         * 3.acciones = opciones;:
         * Asigna el valor del parámetro opciones (el diccionario que contiene las opciones del menú) a la 
         * propiedad acciones de la clase MenuOpciones.Esto guarda todas las opciones del menú y sus 
         * respectivas acciones en la propiedad acciones.
         * 
         * 4.opcionesIndexadas = new Dictionary<int, OpcionMenu>();:
         * Inicializa la propiedad opcionesIndexadas como un nuevo diccionario, donde la clave es un int (un número 
         * que representará el índice de la opción) y el valor es de tipo OpcionMenu.
         * Este diccionario se utilizará para almacenar las opciones del menú indexadas por un número entero 
         * (probablemente para mostrar las opciones numeradas).
         * 
         * 5.int index = 1;:
         * Declara una variable index de tipo int e inicializa su valor en 1. Este índice se utilizará para 
         * asociar números consecutivos a las opciones del menú.
         * 
         * 6.foreach (var opcion in opciones.Keys):
         * Inicia un foreach para recorrer todas las claves del diccionario opciones.
         * Cada clave de opciones es un valor de tipo OpcionMenu, y este ciclo permite recorrer todas 
         * las opciones.
         * 
         * 7.opcionesIndexadas[index++] = opcion;:
         * En cada iteración del ciclo, la opción actual opcion (de tipo OpcionMenu) se asigna al 
         * diccionario opcionesIndexadas, utilizando index como la clave.
         * El operador ++ incrementa el valor de index después de que se ha usado, por lo que las opciones 
         * se indexan con números consecutivos, comenzando desde 1.
         * 
         * Resumen:
         * El constructor MenuOpciones inicializa un objeto de la clase con un nombre de menú y un 
         * diccionario de opciones. Asocia un índice numérico a cada opción del menú y las almacena en un 
         * diccionario llamado opcionesIndexadas. Además, mantiene un diccionario acciones para las 
         * acciones asociadas a las opciones del menú.*/
        #endregion

        /// <summary>
        /// Su función principal es mostrar el menú de opciones en un bucle, permitir que el usuario 
        /// seleccione una opción y ejecutar la acción correspondiente.
        /// </summary>
        public void Ejecutar()
        {
            while (true) //Se inicia un bucle infinito que solo se detendrá cuando el usuario seleccione la opción de Salir.
            {
                Console.WriteLine($"\n{Nombre}"); //Imprime en pantalla el nombre del menú ("Menú Administrador" o "Menú Usuario" por ejemplo).

                /// <summary> 
                /// Muestra las opciones con números secuenciales 
                /// </summary>
                foreach (var kvp in opcionesIndexadas)
                    Console.WriteLine($"{kvp.Key}. {kvp.Value}");
                #region foreach
                /* 1.foreach
                 * Es una estructura de control en C# que permite recorrer los elementos de una colección, 
                 * en este caso, un diccionario. Se usa para iterar (recorrer) cada elemento del 
                 * diccionario opcionesIndexadas.
                 * 
                 * 2.(var kvp in opcionesIndexadas)
                 * var: Es una palabra clave que permite declarar una variable sin especificar su tipo 
                 * explícitamente. El compilador deduce que kvp es un par clave-valor (KeyValuePair<int, 
                 * OpcionMenu>) porque opcionesIndexadas es un diccionario.
                 * kvp: Es el nombre de la variable que representa cada elemento del diccionario en cada 
                 * iteración. "KVP" significa "Key-Value Pair" (Par Clave-Valor).
                 * in: Palabra clave que indica que estamos iterando sobre opcionesIndexadas, que es la 
                 * colección a recorrer.
                 * opcionesIndexadas: Es un diccionario (Dictionary<int, OpcionMenu>) que almacena las 
                 * opciones del menú con un número como clave y una opción del menú como valor.
                 * 
                 * 3.Console.WriteLine($"{kvp.Key}. {kvp.Value}");
                 * Console.WriteLine(...): Método que imprime texto en la consola.
                 * $"{kvp.Key}. {kvp.Value}": Es una cadena interpolada, lo que permite incluir variables 
                 * dentro de la cadena.
                 * Resumen
                 * foreach: Recorre la colección opcionesIndexadas.
                 * var kvp: Representa cada par clave-valor dentro del diccionario.
                 * in opcionesIndexadas: Indica que estamos iterando sobre el diccionario opcionesIndexadas.
                 * Console.WriteLine(...): Imprime la clave y el valor en la consola.
                 * $"{kvp.Key}. {kvp.Value}": Muestra la opción con su número.
                 * Esto permite mostrar un menú numerado dinámico, sin necesidad de escribir manualmente 
                 * cada opción.
                 */
                #endregion

                /// <summary> 
                /// Obtiene la selección del usuario y valida que esté en el rango 
                /// </summary>
                int seleccion = Program.ObtenerOpcion("Seleccione una opción:", 1, opcionesIndexadas.Count);
                if (!opcionesIndexadas.ContainsKey(seleccion))
                {
                    Console.WriteLine("Opción no válida.");
                    continue;
                }
                #region ObtenerOpcion
                /* 1.int seleccion = Program.ObtenerOpcion("Seleccione una opción:", 1, opcionesIndexadas.Count);
                 * int seleccion → Declara una variable llamada seleccion de tipo int. Esta almacenará la opción 
                 * que el usuario elija.
                 * Program.ObtenerOpcion(...) → Llama al método estático ObtenerOpcion dentro de la clase 
                 * Program. Este método:
                 * Muestra un mensaje para que el usuario ingrese un número.
                 * Devuelve el número ingresado por el usuario.
                 * Argumentos de ObtenerOpcion(...):
                 * "Seleccione una opción:" → Mensaje que se mostrará al usuario.
                 * 1 → El número mínimo permitido para la selección.
                 * opcionesIndexadas.Count → Número máximo permitido, que es la cantidad total de opciones 
                 * en el diccionario opcionesIndexadas.
                 * 
                 * 2.if (!opcionesIndexadas.ContainsKey(seleccion))
                 * opcionesIndexadas.ContainsKey(seleccion) → Verifica si seleccion es una clave válida 
                 * dentro del diccionario opcionesIndexadas.
                 * Si seleccion está en el diccionario, devuelve true.
                 * Si seleccion no está en el diccionario, devuelve false.
                 * ! → Operador de negación lógica.
                 * Si ContainsKey(seleccion) devuelve false, la condición if (!opcionesIndexadas.ContainsKey(seleccion)) 
                 * se evalúa como true, lo que significa que la opción ingresada no es válida.
                 * 
                 * Resumen
                 * Solicita al usuario que seleccione una opción válida dentro del rango del menú.
                 * Verifica si la opción ingresada está dentro del diccionario.
                 * Si la opción no es válida, muestra un mensaje de error y vuelve a pedir otra opción.
                 * Si es válida, el programa continuará con la ejecución de la opción seleccionada.
                 */
                #endregion


                /// <summary> 
                /// Obtiene la opción real y ejecuta la acción correspondiente 
                /// </summary>
                OpcionMenu opcionReal = opcionesIndexadas[seleccion];
                if (opcionReal == OpcionMenu.Salir) break;
                acciones[opcionReal].Invoke();
                #region opcionReal
                /* 1.OpcionMenu opcionReal = opcionesIndexadas[seleccion];
                 * OpcionMenu → Es un tipo de dato enumerado (enum) que representa las opciones del menú 
                 * (ej. ListarProductos, AgregarProducto, EliminarProducto, Salir).
                 * opcionReal → Declara una variable de tipo OpcionMenu que almacenará la opción seleccionada
                 * por el usuario.
                 * opcionesIndexadas[seleccion] → Busca en el diccionario opcionesIndexadas la opción 
                 * correspondiente al número ingresado (seleccion).
                 * opcionesIndexadas es un Dictionary<int, OpcionMenu> que asocia números (int) con valores 
                 * del enum OpcionMenu.
                 * 
                 * 2. if (opcionReal == OpcionMenu.Salir) break;
                 * if → Estructura de control que evalúa si la opción seleccionada es la de salir.
                 * opcionReal == OpcionMenu.Salir → Compara si la opción seleccionada es la opción de salir del menú.
                 * Si el usuario eligió Salir, la condición será true.
                 * break; → Sale del bucle while (true), finalizando la ejecución del menú.
                 * 
                 * 3. acciones[opcionReal].Invoke();
                 * acciones → Es un diccionario Dictionary<OpcionMenu, Action>, donde cada opción del 
                 * menú (OpcionMenu) está asociada a una acción (Action).
                 * acciones[opcionReal] → Obtiene la acción asociada a la opción seleccionada.
                 * .Invoke(); → Ejecuta la acción almacenada en el diccionario.
                 * 
                 * Resumen
                 * Obtiene la opción del usuario a partir del diccionario opcionesIndexadas.
                 * Si la opción es Salir, se sale del bucle y termina el menú.
                 * Si no es Salir, busca la acción correspondiente en acciones y la ejecuta con .Invoke().
                 */
                #endregion
            }
        }
    }
}

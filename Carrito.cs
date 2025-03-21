using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace Tienda
{
    /// <summary>
    /// Representa el carrito de compras, donde se gestionan los productos seleccionados 
    /// por el usuario.
    /// </summary>
    public class Carrito
    {
        /// <summary>
        /// Lista de productos en el carrito junto con la cantidad de cada uno.
        /// </summary>
        public List<(Producto Producto, int Cantidad)> Items { get; private set; } = new List<(Producto, int)>();
        #region Explicacion1
        /*Tipo de la propiedad:
         * List<(Producto Producto, int Cantidad)>: Esto indica que la propiedad Items es una lista(List)
         * que contiene elementos de tipo Tuple(tupla). Cada elemento de la lista es una tupla con dos 
         * 
         * elementos:
         * Producto Producto: Un objeto de tipo Producto, que representa el producto que se ha agregado al 
         * carrito.
         * int Cantidad: Un entero que representa la cantidad del producto en el carrito.
         * En resumen, cada elemento de la lista Items es una tupla que tiene dos elementos: 
         * el producto y la cantidad de ese producto.
         * 
         * Visibilidad:
         * public: La propiedad es pública, lo que significa que se puede acceder desde fuera de la 
         * clase Carrito.
         * 
         * Acceso de solo lectura para la propiedad:
         * get; private set;: Esto significa que la propiedad Items tiene un getter público, lo que permite 
         * leer la lista desde fuera de la clase, pero el setter es privado. Esto asegura que solo la clase 
         * Carrito pueda modificar la lista internamente, previniendo que el usuario pueda modificar directamente 
         * la lista de productos en el carrito desde fuera de la clase.
         * 
         * Inicialización:
         * = new List<(Producto, int)>();: Esta parte inicializa la lista con una nueva instancia de List, 
         * es decir, la propiedad Items comienza siendo una lista vacía de tuplas de tipo(Producto, int) 
         * cuando se crea un objeto de tipo Carrito.
         * 
         * Resumen:
         * La propiedad Items es una lista que contiene pares de datos: un objeto Producto y un entero 
         * que representa la cantidad de ese producto en el carrito. La propiedad tiene un getter público 
         * para acceder a los datos, pero el setter es privado, lo que significa que la lista no puede ser 
         * modificada directamente desde fuera de la clase. Además, la lista se inicializa vacía en el 
         * momento de la creación de la clase.
*/
        #endregion

        /// <summary>
        /// Agrega un producto al carrito. Si el producto ya existe, incrementa la cantidad.
        /// </summary>
        /// <param name="producto">El producto que se va a agregar.</param>
        /// <param name="cantidad">La cantidad de ese producto que se va a agregar.</param>
        public void AgregarAlCarrito(Producto producto, int cantidad)
        #region AgregarAlCarrito
        /*1. public: Visibilidad de la función.
         * Indica que este método es público, lo que significa que puede ser accedido desde cualquier 
         * parte del código, es decir, desde otras clases, otros métodos o incluso fuera de la 
         * clase Carrito (si el objeto de tipo Carrito es accesible).
         * Es una palabra clave que define la accesibilidad del método.
         * 
         * 2. void: Tipo de retorno.
         * void significa que el método no devuelve ningún valor. Es decir, este método realiza una acción,
         * pero no devuelve un resultado (como un número o un objeto).
         * En lugar de devolver un valor, simplemente ejecuta su lógica (en este caso, agrega un 
         * producto al carrito).
         * 
         * 3. AgregarAlCarrito: Nombre del método.
         * Es el nombre de la función, y en este caso describe la acción que se va a realizar, 
         * que es agregar un producto al carrito de compras. 
         * 
         * 4. (Producto producto, int cantidad): Parámetros del método.
         * Los parámetros son los valores que se pasan a la función cuando se llama para que esta los 
         * utilice en su lógica.
         * Producto producto: El primer parámetro es de tipo Producto y tiene el nombre producto.
         * Se espera que se pase un objeto de la clase Producto, que contiene información como el nombre, 
         * precio y stock del producto que se desea agregar al carrito.
         * int cantidad: El segundo parámetro es de tipo int y tiene el nombre cantidad.
         * Se espera que se pase un número entero que indica cuántas unidades de ese producto se van 
         * a agregar al carrito.
         * 
         * Resumen de lo que hace la línea:
         * La línea define un método público llamado AgregarAlCarrito que no devuelve nada 
         * (es decir, su tipo de retorno es void). Este método recibe dos parámetros:
         * Un producto (de tipo Producto).
         * Una cantidad (de tipo int).
         * El propósito de este método es agregar una cantidad específica de un producto al carrito. 
         * El producto es un objeto de la clase Producto y la cantidad es un número entero que indica 
         * cuántas unidades del producto se agregarán al carrito de compras.
         */
        #endregion
        {
            // Busca si el producto ya existe en el carrito
            var item = Items.Find(i => i.Producto.Id == producto.Id);
            if (item.Producto != null)
            {
                #region Explicacion2
                /* 1. var: Tipo de la variable.
                 * var es una palabra clave que se utiliza en C# para declarar una variable implícita. 
                 * El compilador determina automáticamente el tipo de la variable en función del valor 
                 * que se le asigna.
                 * En este caso, var se usará para crear una variable llamada item, y el tipo de item 
                 * será determinado por el valor que retorne la función Find.
                 * 
                 * 2. item: Nombre de la variable.
                 * item es el nombre de la variable que almacenerá el resultado de la búsqueda 
                 * realizada en la lista Items. En este caso, item representará el primer elemento de 
                 * la lista Items que cumpla con la condición especificada.
                 * 3. Items: Colección de productos en el carrito.
                 * Items es una propiedad de la clase Carrito, y es una lista de tuplas de tipo 
                 * (Producto, int). Cada tupla contiene un objeto Producto y su cantidad asociada en el 
                 * carrito.
                 * El método Find se utiliza para buscar un elemento en esa lista.
                 * 
                 * 4. .Find(...): Método Find.
                 * Find es un método de la clase List<T> (en este caso, List<(Producto, int)>), 
                 * que se utiliza para encontrar el primer elemento de la lista que cumpla con una condición.
                 * Este método devuelve el primer elemento que cumpla con la condición especificada 
                 * en el predicado. Si no encuentra ningún elemento que cumpla con la condición, 
                 * devuelve null.
                 * 
                 * 5. i => i.Producto.Id == producto.Id: Expresión Lambda(función literal o función anónima, es una subrutina definida que no está enlazada a un identificador.).
                 * Esto es un predicado o condición de búsqueda. 
                 * La expresión i => i.Producto.Id == producto.Id es una expresión lambda que define 
                 * cómo buscar el producto en la lista Items.
                 * i: Representa un elemento de la lista Items. Cada elemento de Items es una tupla 
                 * (Producto Producto, int Cantidad), por lo que i se refiere a esa tupla.
                 * i.Producto.Id: Accede al Producto dentro de la tupla i y luego toma el Id del Producto.
                 * producto.Id: Es el Id del producto que se pasa como parámetro al método AgregarAlCarrito.
                 * La expresión i.Producto.Id == producto.Id compara el Id del producto actual (i.Producto.Id) 
                 * con el Id del producto que estamos intentando agregar al carrito (producto.Id). La función 
                 * Find devolverá el primer elemento de la lista que tenga un producto con el mismo Id.
                 * 
                 * 6. if (item.Producto != null): Condición.
                 * Una vez que Find ha buscado el producto en la lista, la condición if 
                 * (item.Producto != null) se asegura de que se haya encontrado un producto en la 
                 * lista Items con el mismo Id que el producto que estamos tratando de agregar.
                 * Si item.Producto no es null, significa que se encontró el producto en el carrito y,
                 * por lo tanto, podemos proceder a incrementar su cantidad.
                 * ¿Por qué item.Producto != null?
                 * En realidad, el uso de item.Producto != null no es necesario si estamos trabajando 
                 * con una lista de tuplas (Producto, int), ya que una tupla nunca será null en C#.
                 * Sin embargo, la verificación es una medida de seguridad, en caso de que Find devuelva 
                 * un valor null (si no encuentra el producto). A pesar de que en este caso, Find devolverá 
                 * un valor de tipo Producto, la verificación también podría usarse como una precaución 
                 * extra para asegurar que estamos accediendo a un valor válido.
                 * 
                 * Resumen de lo que hace este bloque de código:
                 * Busca si el producto ya existe en el carrito. Se utiliza el método Find para buscar 
                 * una tupla en la lista Items cuyo Id del producto coincida con el Id del producto 
                 * que estamos intentando agregar al carrito.
                 * Si se encuentra un producto en el carrito (es decir, si item.Producto != null), 
                 * el código podrá incrementar la cantidad del producto en el carrito en lugar de 
                 * agregarlo de nuevo como un nuevo producto.
                 * Este código es parte de la lógica que permite agregar más unidades de un producto al 
                 * carrito si el producto ya está presente.
                 */
                #endregion

                // Si el producto ya está, incrementa la cantidad
                item.Cantidad += cantidad;
            }
            #region Explicacion3
            /* 1. item: item es una variable que contiene una tupla de tipo (Producto Producto, int Cantidad),
             * que representa un producto y su cantidad en el carrito de compras.
             * Este item es el producto que se encuentra en el carrito de compras que coincida con 
             * el producto que se está intentando agregar, como se explicó en la línea anterior 
             * con el método Find.
             * 
             * 2. item.Cantidad: item.Cantidad hace referencia a la cantidad del producto que ya está 
             * presente en el carrito.
             * Es un entero (int) que indica cuántas unidades del producto están actualmente en el carrito.
             * 
             * 3. +=: += es un operador de suma y asignación.
             * Este operador toma el valor actual de item.Cantidad y le suma el valor que se 
             * encuentra en la variable cantidad.
             * Es decir, si ya había 2 unidades del producto en el carrito, y se le intentan agregar 3 
             * unidades más, el valor final de item.Cantidad será 5.
             * 
             * 4. cantidad: cantidad es el parámetro del método AgregarAlCarrito y representa cuántas 
             * unidades del producto se están intentando agregar al carrito en ese momento.
             * 
             * Resumen de lo que hace:
             * La línea de código incrementa la cantidad de un producto en el carrito. 
             * Si el producto ya está en el carrito (es decir, si item.Producto no es null), en lugar 
             * de agregarlo de nuevo como un producto diferente, aumenta la cantidad de ese producto
             * en el carrito.
             */
            #endregion

            else
            {
                // Si el producto no está, lo agrega como nuevo
                Items.Add((producto, cantidad));
            }
            #region Explicacion4
            /*1. else:Este bloque de código se ejecuta si la condición anterior (es decir, si el 
             * producto ya está en el carrito) no se cumple.
             * En otras palabras, si el producto no se encuentra en el carrito, se entra en el bloque else.
             * 
             * 2. Items.Add((producto, cantidad));: Items es una lista de tuplas que representa todos 
             * los productos en el carrito de compras. Cada elemento de la lista es una tupla 
             * (Producto Producto, int Cantidad).
             * Add() es un método de la lista Items que agrega un nuevo elemento a la lista.
             * producto es la instancia del producto que se está intentando agregar al carrito.
             * cantidad es el número de unidades de ese producto que se desea agregar al carrito.
             * 
             * 3. (producto, cantidad): 
             * Se está creando una tupla que contiene:
             * producto: El objeto Producto que contiene la información del producto que se está 
             * agregando (como su nombre, precio, etc.).
             * cantidad: Un valor entero que indica cuántas unidades del producto se están 
             * agregando al carrito.
             * Esta tupla se agrega a la lista Items, lo que representa que se está añadiendo el 
             * producto con su cantidad al carrito de compras.
             * 
             * Resumen de lo que hace:
             * Si el producto no se encuentra en el carrito (es decir, el bloque anterior no lo encontró),
             * el código agrega ese producto como un nuevo elemento en la lista Items del carrito, 
             * asociando el producto con la cantidad que se está agregando.
             */
            #endregion

            // Reduce el stock del producto en la cantidad que se ha agregado al carrito de compras.
            producto.Stock -= cantidad;
        }
        #region AgregarAlCarrito
        /* 1.producto.Stock: 
         * producto es una instancia del objeto Producto, que representa un artículo en el inventario 
         * de la tienda.
         * Stock es una propiedad de la clase Producto que indica cuántas unidades de ese producto 
         * están disponibles en el inventario.
         * 
         * 2.-= cantidad:
         * El operador -= es un operador de asignación compuesto que resta un valor a la variable y 
         * luego asigna el resultado a esa misma variable. En este caso, el valor de cantidad (que es el 
         * número de unidades que el usuario desea agregar al carrito) se resta al valor actual de Stock. 
         * Es decir, si había 10 unidades en stock y el usuario agregó 3 unidades al carrito, el stock se 
         * reducirá a 7.*/
        #endregion


        /// <summary>
        /// Muestra los productos del carrito con su cantidad y el precio total de cada uno.
        /// </summary>
        public void VerCarrito()
        {
            Console.WriteLine("\nCarrito de compras:");
            foreach (var item in Items)
            {
                Console.WriteLine($"{item.Producto.Nombre} x {item.Cantidad} - Total: {item.Producto.Precio * item.Cantidad}");
            }
        }
        #region VerCarrito
        /* 1.public void VerCarrito(): Es el encabezado del método.
         * public: Indica que este método es accesible desde cualquier parte del programa.
         * void: Significa que el método no devuelve ningún valor. Simplemente ejecuta una acción.
         * VerCarrito(): El nombre del método, que indica que su propósito es mostrar el contenido 
         * del carrito.
         * 
         * 2.Console.WriteLine("\nCarrito de compras:");:
         * Esta línea imprime en la consola el mensaje "Carrito de compras:", que sirve como encabezado 
         * antes de mostrar los productos en el carrito.
         * El \n al principio del mensaje es un salto de línea, lo que ayuda a que el mensaje se muestre 
         * con un espacio antes de la lista de productos.
         * 
         * 3.foreach (var item in Items):
         * foreach es un bucle que itera sobre todos los elementos de la lista Items (que contiene los 
         * productos y sus cantidades en el carrito).
         * var item es una variable local que representa cada elemento de la lista Items. En este caso, 
         * item será de tipo (Producto, int) porque Items es una lista de tuplas, donde cada tupla 
         * contiene un Producto y la cantidad de ese producto.
         * La línea dentro del foreach se ejecutará una vez por cada producto en el carrito.
         * 
         * 4.Console.WriteLine($"{item.Producto.Nombre} x {item.Cantidad} - Total: {item.Producto.Precio * item.Cantidad}");:
         * Esta línea imprime información sobre cada producto en el carrito.
         * {item.Producto.Nombre}: Muestra el nombre del producto que se encuentra dentro de la 
         * propiedad Producto de la tupla item.
         * x {item.Cantidad}: Muestra la cantidad del producto que se ha agregado al carrito 
         * (de nuevo, item.Cantidad).
         * - Total: {item.Producto.Precio * item.Cantidad}: Calcula el precio total de ese producto 
         * en el carrito. Se multiplica el precio del producto (item.Producto.Precio) por la cantidad 
         * (item.Cantidad), y se imprime el resultado.*/
        #endregion


        /// <summary>
        /// Guarda el carrito en un archivo de texto, por ejemplo, "carrito.txt".
        /// </summary>
        public void GuardarCarrito()
        {
            var lineas = new List<string>();
            foreach (var item in Items)
            {
                lineas.Add($"{item.Producto.Id},{item.Producto.Nombre},{item.Cantidad},{item.Producto.Precio}");
            }
            File.WriteAllLines("carrito.txt", lineas);
        }
        #region GuardarCarrito
        /* 1.var lineas = new List<string>();:
         * Declara una lista de cadenas (List<string>), llamada lineas, que se utilizará para almacenar 
         * las líneas de texto que representarán los productos en el carrito.
         * var: El compilador infiere el tipo de la variable, que en este caso será List<string>, ya que 
         * se está inicializando con un objeto de ese tipo.
         * 
         * 2.foreach (var item in Items):
         * foreach es un bucle que itera sobre todos los elementos de la lista Items, que contiene las 
         * tuplas (Producto, int) representando los productos y sus cantidades en el carrito.
         * En cada iteración, la variable item toma el valor de una tupla, donde item.Producto es el 
         * producto y item.Cantidad es la cantidad de ese producto.
         * 
         * 3.lineas.Add($"{item.Producto.Id},{item.Producto.Nombre},{item.Cantidad},{item.Producto.Precio}");:
         * En esta línea, se está agregando una cadena de texto (que representa un producto del carrito) 
         * a la lista lineas.
         * La cadena de texto contiene varios valores:
         * item.Producto.Id: El ID del producto.
         * item.Producto.Nombre: El nombre del producto.
         * item.Cantidad: La cantidad del producto en el carrito.
         * item.Producto.Precio: El precio del producto.
         * Los valores están separados por comas, lo que hace que el formato de cada línea sea similar 
         * a un archivo CSV (Comma Separated Values).*/
        #endregion


        /// <summary>
        /// Carga el carrito desde un archivo, por ejemplo, "carrito.txt".
        /// </summary>
        public void CargarCarrito()
        {
            if (File.Exists("carrito.txt"))
            {
                foreach (var linea in File.ReadAllLines("carrito.txt"))
                {
                    var datos = linea.Split(',');

                    // Cargar el producto desde la lista de productos disponibles
                    var producto = Producto.CargarProductos().FirstOrDefault(p => p.Id == int.Parse(datos[0]));
                    if (producto != null)
                    {
                        AgregarAlCarrito(producto, int.Parse(datos[2]));
                    }
                }
            }
        }
        #region CargarCarrito
        /* 1.if (File.Exists("carrito.txt")):
         * Se verifica si el archivo "carrito.txt" existe en el sistema.
         * File.Exists: Este es un método estático de la clase System.IO.File, que devuelve true si el archivo especificado existe, y false si no.
         * Si el archivo existe, se procede a leer su contenido.
         * 
         * 2.foreach (var linea in File.ReadAllLines("carrito.txt")):
         * File.ReadAllLines("carrito.txt"): Este método lee todas las líneas del archivo "carrito.txt" y 
         * devuelve un arreglo de cadenas, donde cada cadena es una línea del archivo.
         * foreach (var linea in ...): El bucle foreach itera sobre cada línea del archivo, y en cada 
         * iteración, linea toma el valor de la siguiente línea del archivo.
         * 
         * 3.var datos = linea.Split(',');:
         * linea.Split(','): La línea leída se divide en partes utilizando la coma (,) como delimitador. 
         * Esto convierte la cadena en un arreglo de cadenas (datos), donde cada elemento del arreglo 
         * corresponde a un valor separado por coma en la línea.
         * 
         * 4.var producto = Producto.CargarProductos().FirstOrDefault(p => p.Id == int.Parse(datos[0]));:
         * Producto.CargarProductos(): Este método carga la lista de productos disponibles (probablemente 
         * desde un archivo o base de datos). Devuelve una lista de objetos de tipo Producto.
         * .FirstOrDefault(p => p.Id == int.Parse(datos[0])): Busca el primer producto en la lista de 
         * productos cuyo Id coincide con el valor que se encuentra en datos[0] (el ID del producto que fue 
         * guardado en el archivo). int.Parse(datos[0]) convierte el valor de datos[0] de cadena a un entero.
         * Si encuentra un producto con ese ID, lo asigna a la variable producto.
         * Si no encuentra un producto, producto será null.
         * 
         * 5.if (producto != null):
         * Verifica si el producto fue encontrado en la lista de productos disponibles.
         * Si el producto existe (producto != null), se procede a agregarlo al carrito. Si el producto 
         * no existe, no hace nada.
         * 
         * 6.AgregarAlCarrito(producto, int.Parse(datos[2]));:
         * AgregarAlCarrito(producto, int.Parse(datos[2])): Llama al método AgregarAlCarrito para agregar 
         * producto: El producto que se cargó desde la lista de productos.
         * int.Parse(datos[2]): Convierte el valor de datos[2] (que es la cantidad del producto guardado 
         * en el archivo) a un número entero y lo pasa al método AgregarAlCarrito.
         * AgregarAlCarrito es el método que agrega un producto al carrito, ya sea sumando más cantidad 
         * si el producto ya está en el carrito, o agregando el producto si no existe.
         * El propósito de CargarCarrito() es restaurar el estado del carrito de compras desde un archivo 
         * previamente guardado. Este método permite que el carrito persista entre diferentes ejecuciones 
         * del programa, cargando los productos y sus cantidades desde el archivo "carrito.txt" cuando el 
         * programa se reinicia.
         */
        #endregion
    }
}




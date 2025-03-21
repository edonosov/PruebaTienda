using System.Collections.Generic;

namespace Tienda
{
    /// <summary>
    /// Representa un producto dentro del sistema de compras.
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// Identificador único del producto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Precio del producto.
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Cantidad disponible en stock.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Descripción adicional del producto.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Constructor que inicializa un producto con sus datos.
        /// </summary>
        /// <param name="id">Identificador único del producto.</param>
        /// <param name="nombre">Nombre del producto.</param>
        /// <param name="precio">Precio del producto.</param>
        /// <param name="stock">Cantidad de producto disponible en stock.</param>
        /// <param name="descripcion">Descripción del producto.</param>
        public Producto(int id, string nombre, decimal precio, int stock, string descripcion = "")
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            Descripcion = descripcion;
        }

        /// <summary>
        /// Convierte un producto a un formato de cadena para su visualización o almacenamiento.
        /// </summary>
        /// <returns>Una cadena representando al producto.</returns>
        public override string ToString()
        {
            return $"{Id}, {Nombre}, {Precio}, {Stock}, {Descripcion}";
        }

        /// <summary>
        /// Carga los productos desde un archivo y los devuelve como una lista.
        /// </summary>
        /// <returns>Lista de productos cargados desde el archivo.</returns>
        public static List<Producto> CargarProductos()  //El tipo de retorno del método es una lista de objetos de tipo Producto. Esto significa que CargarProductos() devolverá una lista que contiene varios objetos Producto.
        {
            var productos = new List<Producto>(); //Se crea una nueva lista vacía de objetos de tipo Producto. Esta lista almacenará todos los productos que se carguen desde el archivo.
            if (File.Exists("productos.txt"))  //Este método está verificando si el archivo "productos.txt" existe en el directorio actual (donde se ejecuta el programa). Si el archivo existe, la condición será verdadera y se ejecutará el bloque de código dentro del if.
            {
                foreach (var linea in File.ReadAllLines("productos.txt"))  //Este método lee todas las líneas del archivo "productos.txt" y devuelve un arreglo de cadenas (string[]), donde cada elemento del arreglo representa una línea del archivo.
                {
                    var datos = linea.Split(',');  //Aquí se está dividiendo la línea en partes separadas por comas. La función Split(',') divide la cadena linea en un arreglo de cadenas, utilizando la coma como delimitador.
                    productos.Add(new Producto(
                        int.Parse(datos[0]),
                        datos[1],
                        decimal.Parse(datos[2]),
                        int.Parse(datos[3]),
                        datos.Length > 4 ? datos[4] : "Sin descripción"
                    #region Explicacion
                    /*1. productos.Add(new Producto(...)): En cada iteración, se crea un nuevo objeto Producto
                     * utilizando los valores leídos del archivo y luego se agrega a la lista productos.
                     * new Producto(...): Aquí estamos creando un nuevo objeto de tipo Producto y pasando 
                     * los valores que se obtienen de las posiciones del arreglo datos[]:
                     * int.Parse(datos[0]): Convierte el primer valor (datos[0], que es el Id) en un número 
                     * entero (int).
                     * datos[1]: El segundo valor es el nombre del producto, que es un string (string).
                     * decimal.Parse(datos[2]): Convierte el tercer valor (datos[2], que es el Precio) 
                     * en un valor decimal (decimal).
                     * int.Parse(datos[3]): Convierte el cuarto valor (datos[3], que es el Stock) en un 
                     * número entero (int).
                     * datos.Length > 4 ? datos[4] : "Sin descripción": Este es un operador ternario. 
                     * Si el arreglo datos tiene más de 4 elementos (es decir, si hay una descripción en el 
                     * archivo), se usa el valor datos[4] como descripción. Si no hay descripción 
                     * (el arreglo tiene solo 4 elementos), se usa el valor "Sin descripción" como valor 
                     * predeterminado.
                     */
                    #endregion
                    ));
                }
            }
            return productos;
        }

        /// <summary>
        /// Guarda la lista de productos en el archivo "productos.txt".
        /// </summary>
        /// <param name="productos">Lista de productos que se desea guardar.</param>
        public static void GuardarProductos(List<Producto> productos)
        {
            File.WriteAllLines("productos.txt", productos.Select(p => p.ToString()));
        }
        #region GuardarProductos
        /* 1.File.WriteAllLines("productos.txt", ...): Este método de la clase File se utiliza para escribir
         * un conjunto de líneas en un archivo de texto. En este caso, se está escribiendo en el archivo
         * "productos.txt". Si el archivo ya existe, se sobrescribirá. Si no existe, se creará un nuevo 
         * archivo.
         * 
         * productos.Select(p => p.ToString()): Este fragmento de código convierte cada objeto Producto en 
         * una cadena que se puede escribir en el archivo.
         * productos: Es la lista de productos que se pasa al método GuardarProductos.
         * Select(p => p.ToString()): Este es un método de LINQ que proyecta (transforma) cada elemento de 
         * la lista productos a una cadena de texto. En este caso, para cada objeto Producto en la lista, 
         * se llama al método ToString() de Producto, que retorna una representación en formato de texto 
         * del objeto Producto.
         * 
         * p.ToString(): El método ToString() de la clase Producto está sobreescrito para devolver una 
         * cadena con el formato: "Id, Nombre, Precio, Stock, Descripción". De esta forma, se obtiene una 
         * representación de texto del producto, que puede ser fácilmente almacenada en el archivo.
         * 
         * El método GuardarProductos toma una lista de objetos Producto y guarda cada uno de ellos en un 
         * archivo de texto.
         * Utiliza el método ToString() de Producto para obtener una representación en cadena de cada 
         * objeto y luego guarda esas cadenas en el archivo "productos.txt".
         * Si el archivo ya existe, se sobrescribe con los nuevos datos. Si no existe, el archivo se crea 
         * automáticamente.
         */
        #endregion
    }
}


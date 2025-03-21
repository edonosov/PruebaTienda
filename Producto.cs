using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Representa un producto dentro del sistema de tienda.
/// Contiene propiedades como ID, nombre, precio, stock y descripción,
/// así como métodos estáticos para cargar y guardar productos desde/hacia un archivo.
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
    /// Descripción opcional del producto.
    /// </summary>
    public string Descripcion { get; set; } = " ";

    /// <summary>
    /// Ruta relativa al archivo donde se almacenan los productos (ubicado en la raíz del proyecto).
    /// </summary>
    private static readonly string RutaArchivo = Path.Combine(
        Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName,
        "productos.txt"
    );

    /// <summary>
    /// Devuelve una representación en texto del producto, en formato CSV.
    /// </summary>
    /// <returns>Cadena de texto con los datos del producto separados por comas.</returns>
    public override string ToString()
    {
        return $"{Id},{Nombre},{Precio},{Stock},{Descripcion}";
    }

    /// <summary>
    /// Carga los productos desde el archivo productos.txt.
    /// Si el archivo no existe, lo crea con productos de ejemplo.
    /// </summary>
    /// <returns>Lista de productos cargados desde el archivo.</returns>
    public static List<Producto> CargarProductos()
    {
        var productos = new List<Producto>();

        if (!File.Exists(RutaArchivo))
        {
            File.WriteAllLines(RutaArchivo, new[]
            {
                "101,Camisetas,10,5,Camisetas de lana",
                "102,Pantalones,25,30,Pantalones en tonos azules",
                "103,Vestidos,15,4,Vestidos glam",
                "105,Calcetines,3,364,Calcetines con dibujitos",
                "106,Pan,1.20,15,Hecho con masa madre",
                "104,Chocolate,2.50,10,Cultivado en nuestros propios terrenos"
            });
        }

        foreach (var linea in File.ReadAllLines(RutaArchivo))
        {
            var datos = linea.Split(',');
            if (datos.Length >= 5)
            {
                productos.Add(new Producto
                {
                    Id = int.Parse(datos[0]),
                    Nombre = datos[1],
                    Precio = decimal.Parse(datos[2]),
                    Stock = int.Parse(datos[3]),
                    Descripcion = datos[4]
                });
            }
        }

        return productos;
    }

    /// <summary>
    /// Guarda la lista completa de productos en el archivo productos.txt, sobrescribiéndolo.
    /// </summary>
    /// <param name="productos">Lista de productos a guardar.</param>
    public static void GuardarProductos(List<Producto> productos)
    {
        File.WriteAllLines(RutaArchivo, productos.Select(p => p.ToString()));
        Console.WriteLine($"Archivo guardado en: {RutaArchivo}");

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABORATORIO3
{
    public class Producto
    {
        public string NombreProducto {  get; set; }
        public double PrecioProducto { get; set; }

        public Producto(string nombreProducto, double precioProducto)
        {
            NombreProducto = nombreProducto;
            PrecioProducto = precioProducto;
        }
        public void MostrarProducto()
        {
            Console.WriteLine($"Nombre: {NombreProducto}");
            Console.WriteLine($"Precio: Q{PrecioProducto}");
        }
    }
}

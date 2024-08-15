using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABORATORIO3
{
    public class Pedido
    {
        static int contador = 0;
        public int IdPedido {  get; set; }
        public ICliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<Producto> Productos { get; set; }
        public double TotalPedido { get; set; }

        public Pedido(ICliente cliente, DateTime fecha, List<Producto> productos)
        {
            IdPedido = ++contador;
            Cliente = cliente;
            Fecha = fecha;
            Productos = productos;
            TotalPedido = CalcularTotal();
        }

        public void MostrarPedido()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Pedido #{IdPedido}"); Console.ResetColor();
            Console.WriteLine($"Nombre del cliente: {Cliente.Nombre}");
            Console.WriteLine($"Fecha: {Fecha}");
            Console.WriteLine("Lista de productos solicitados:");
            foreach(var producto in Productos)
            {
                producto.MostrarProducto();
            }
            Console.WriteLine($"Total Q{TotalPedido}");
        }
        public double CalcularTotal()
        {
            double total = Productos.Sum(p => p.PrecioProducto);
            if (Cliente is ClienteVip vipCliente)
            {
                total -= total * (vipCliente.DescuentoVip / 100.0);
            }else if (Cliente is ClienteCorporativo corpCliente)
            {
                total -= total * (corpCliente.DescuentoCorporativo / 100.0);
            }
            return total;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOpcion3
{
    public class Reserva
    {
        static int contador = 0;
        public int IdReserva { get; set; }
        public DateTime Fecha { get; set; }
        public ICliente Cliente { get; set; }
        public List<Plato> Platos { get; set; }
        public double TotalCalculado { get; set; }

        public Reserva(DateTime fecha, ICliente cliente, List<Plato> platos)
        {
            Fecha = fecha;
            IdReserva = ++contador; 
            Cliente = cliente;
            Platos = platos;
            TotalCalculado = CalcularTotal();
        }
        public void MostrarReserva()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Reserva #{IdReserva}"); Console.ResetColor();
            Console.WriteLine($"Nombre del cliente: {Cliente.Nombre}");
            Console.WriteLine($"Fecha y hora: {Fecha}");
            Console.WriteLine("Platos en la reserva: ");
            foreach(var plato in Platos)
            {
                plato.MostrarPlatos();
                
            }
            Console.WriteLine();
            Console.WriteLine($"Total de la reserva: Q{TotalCalculado}");
        }
        public double CalcularTotal()
        {
            double total = Platos.Sum(p => p.PrecioPlato);
            if (Cliente is ClienteVip vipCliente)
            {
                total -= total * (vipCliente.Descuento / 100.0);
            }
            return total;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABORATORIO3
{
    public class Vehiculo
    {
        public string Matricula {  get; set; }
        public string Modelo { get; set; }
        public string TipoDeCombustible { get; set; }
        public ICliente Cliente { get; set; }

        public Vehiculo(string matricula, string modelo, string tipoDeCombustible, ICliente cliente)
        {
            Matricula = matricula;
            Modelo = modelo;
            TipoDeCombustible = tipoDeCombustible;
            Cliente = cliente;
        }
        public virtual void MostrarVehiculos()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Matícula: {Matricula}"); Console.ResetColor();
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Tipo de combustible: {TipoDeCombustible}");
            Console.WriteLine($"Nombre del cliente: {Cliente.Nombre}");
        }
    }
}

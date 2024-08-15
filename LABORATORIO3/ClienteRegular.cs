using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABORATORIO3
{
    public class ClienteRegular: ICliente
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }

        public ClienteRegular(string nombre, string correo, string direccion)
        {
            Nombre = nombre;
            Correo = correo;
            Direccion = direccion;
        }
        public virtual void MostrarInformacion()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Nombre del cliente: {Nombre}"); Console.ResetColor();
            Console.WriteLine($"Correo: {Correo}");
            Console.WriteLine($"Dirección: {Direccion}");
        }
    }
}

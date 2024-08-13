using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOpcion3
{
    public class Cliente: ICliente
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int NumeroTelefonico { get; set; }

        public Cliente(string nombre, string correo, int numeroTelefonico)
        {
            Nombre = nombre;
            Correo = correo;
            NumeroTelefonico = numeroTelefonico;
        }

        public virtual void MostrarInformacion()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta; 
            Console.WriteLine($"Nombre del cliente: {Nombre}"); Console.ResetColor();
            Console.WriteLine($"Correo: {Correo}");
            Console.WriteLine($"Numero de telefono: {NumeroTelefonico}");
        }
    }
}

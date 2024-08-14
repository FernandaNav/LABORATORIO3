using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOpcion3
{
    public class Mensajes
    {
        public void MensajeDeError()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Error de formato. Intenta de nuevo.");
            Console.ResetColor();
        }
        public void MensajeContinuar()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Presiona ENTER para continuar...");
            Console.ResetColor(); Console.ReadKey(); Console.Clear();
        }
        public void MensajeDefault()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Esta opción no existe"); Console.ResetColor();
            MensajeContinuar();
        }

        public void MensajeClientes()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine("Aun no existen clientes...");
            Console.ReadKey(); Console.Clear();
        }
    }
}

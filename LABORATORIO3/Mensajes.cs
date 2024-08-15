using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABORATORIO3
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

        public void Menu()
        {
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine("-------------------------");
            Console.WriteLine("       BIENVENIDO");
            Console.WriteLine("-------------------------"); Console.ResetColor();
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Registrar vehículo");
            Console.WriteLine("3. Registrar Pedido");
            Console.WriteLine("4. Mostrar información");
            Console.WriteLine("5. Buscar información");
            Console.WriteLine("6. Salir");
            Console.WriteLine();
            Console.Write("Ingresa una opción: ");
        }

        public void Despedida()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("---------------------"); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   Adiós Usuario :)"); Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("---------------------"); Console.ResetColor();
        }
    }
}

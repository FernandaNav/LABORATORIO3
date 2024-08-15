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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-------------------------");
            Console.WriteLine("       BIENVENIDO");
            Console.WriteLine("-------------------------"); Console.ResetColor();
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Registrar vehículo");
            Console.WriteLine("3. Registrar pedido");
            Console.WriteLine("4. Mostrar clientes");
            Console.WriteLine("5. Mostrar vehículos");
            Console.WriteLine("6. Mostrar pedidos");
            Console.WriteLine("7. Buscar cliente");
            Console.WriteLine("8. Buscar vehículo");
            Console.WriteLine("9. Buscar pedido");
            Console.WriteLine("10. Salir");
            Console.WriteLine();
            Console.Write("Ingresa una opción: ");
        }

        public void MenuCliente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-------Registrar Cliente-------"); Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1. Cliente regular");
            Console.WriteLine("2. Cliente VIP");
            Console.WriteLine("3. Cliente Corporativo");
            Console.WriteLine("4. Regresar a menú principal"); Console.WriteLine();
            Console.Write("Ingresa la opción: ");
        }

        public void NoHayClientes()
        {
            Console.ForegroundColor= ConsoleColor.DarkGray;
            Console.WriteLine("Aún no hay clientes..."); Console.ReadKey(); Console.Clear();
        }
        public void NoHayVehiculos()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Aún no hay vehiculos..."); Console.ReadKey(); Console.Clear();
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

using LabOpcion3;
using System.Security.Cryptography;

class program
{
    static void Main(string[] args)
    {
        int opcion = 0;
        Mensajes mensaje = new Mensajes();
        List<Cliente> listaClientes = new List<Cliente>();
        do
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("------------------------");
            Console.WriteLine("      BIENVENIDO");
            Console.WriteLine("------------------------"); Console.ResetColor();
            Console.WriteLine("1. Registrar clientes");
            Console.WriteLine("2. Registrar reserva");
            Console.WriteLine("3. Mostrar clientes");
            Console.WriteLine("4. Mostrar reservas");
            Console.WriteLine("5. Buscar Cliente");
            Console.WriteLine("6. Buscar reserva");
            Console.WriteLine("7. Salir");
            Console.WriteLine();
            Console.Write("Ingresa la opción: ");
            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        int opcionCliente = 0, numeroTelefonico = 0; double descuento = 0;
                        string nombreCliente = "", correoCliente = "";
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("----Registrar Cliente-----"); Console.ResetColor();
                            Console.WriteLine();
                            Console.WriteLine("1. Cliente Regular");
                            Console.WriteLine("2. Cliente VIP");
                            Console.WriteLine("3. Regresar");
                            Console.WriteLine();
                            Console.Write("Ingresa la opcion: ");
                            try
                            {
                                opcionCliente = Convert.ToInt32(Console.ReadLine());
                                if (opcionCliente == 1 || opcionCliente == 2)
                                {
                                    Console.Clear(); bool validarTelefono = false;
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("--------Info Cliente---------"); Console.ResetColor();
                                    Console.WriteLine(); Console.Write("Ingresa el nombre del Cliente: ");
                                    nombreCliente = Console.ReadLine();
                                    Console.Write("Ingresa el correo del cliente: ");
                                    correoCliente = Console.ReadLine();
                                    do
                                    {
                                        Console.Write("Ingresa el número de teléfono: ");
                                        try
                                        {
                                            numeroTelefonico = Convert.ToInt32(Console.ReadLine());
                                            if (numeroTelefonico > 0)
                                            {
                                                validarTelefono = true;
                                                break;
                                            }
                                        }
                                        catch (FormatException)
                                        {
                                            mensaje.MensajeDeError(); Console.WriteLine();
                                        }
                                    } while (validarTelefono == false);
                                }
                                switch (opcionCliente)
                                {
                                    case 1:
                                        Cliente nuevoCliente = new Cliente(nombreCliente, correoCliente, numeroTelefonico);
                                        listaClientes.Add(nuevoCliente);
                                        mensaje.MensajeContinuar();
                                        break;
                                    case 2:
                                        bool validarDescuento = false;
                                        do
                                        {
                                            Console.Write("Ingresa la cantidad de porcentaje de desdcuento: %");
                                            try
                                            {
                                                descuento = Convert.ToDouble(Console.ReadLine());
                                                if (descuento > 0)
                                                {
                                                    validarDescuento = true;
                                                    ClienteVip nuevoClienteVip = new ClienteVip(nombreCliente, correoCliente, numeroTelefonico, descuento);
                                                    listaClientes.Add(nuevoClienteVip);
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("El descuento no puede ser menor o igual a 0"); Console.ResetColor(); Console.WriteLine();
                                                }
                                            }

                                            catch (FormatException)
                                            {
                                                mensaje.MensajeDeError();
                                            }
                                        } while (validarDescuento == false);
                                        mensaje.MensajeContinuar();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        break;
                                    default:
                                        mensaje.MensajeDefault();
                                        break;
                                }
                            }
                            catch (FormatException)
                            {
                                mensaje.MensajeDeError();
                                mensaje.MensajeContinuar();
                            }
                        } while (opcionCliente != 3);
                        break;
                    case 2:
                        Console.Clear();
                        foreach (var cliente in listaClientes)
                        {
                            cliente.MostrarInformacion(); //esto es solo para ver si se estaban guardando los clientes
                        }
                        mensaje.MensajeContinuar();
                        break;
                    case 3:
                        Console.Clear();
                        mensaje.MensajeContinuar();
                        break;
                    case 4:
                        Console.Clear();
                        mensaje.MensajeContinuar();
                        break;
                    case 5:
                        Console.Clear();
                        mensaje.MensajeContinuar();
                        break;
                    case 6:
                        Console.Clear();
                        mensaje.MensajeContinuar();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("--------------------");
                        Console.WriteLine("       ADIÓS");
                        Console.WriteLine("--------------------");
                        break;
                    default:
                        mensaje.MensajeDefault();
                        break;
                }
            }
            catch (FormatException)
            {
                mensaje.MensajeDeError();
            }
        } while (opcion != 7);
    }
}
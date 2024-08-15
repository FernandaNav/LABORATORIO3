using LABORATORIO3;

class Program
{
    static void Main(string[] args)
    {
        Mensajes mensaje = new Mensajes();
        List<ClienteRegular> listaClientes = new List<ClienteRegular>();
        List<Vehiculo> listaVehiculos = new List<Vehiculo>();
        int opcion = 0;
        do
        {
            mensaje.Menu();
            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        int opcionCliente = 0;
                        string nombreCliente="", correoCliente="", direccionCliente="";
                        do
                        {
                            mensaje.MenuCliente();
                            try
                            {
                                opcionCliente = Convert.ToInt32(Console.ReadLine());
                                if(opcionCliente==1||opcionCliente == 2 || opcionCliente == 3)
                                {
                                    Console.Clear(); Console.ForegroundColor= ConsoleColor.DarkCyan;
                                    Console.WriteLine("----------Información Cliente----------"); Console.ResetColor(); Console.WriteLine();
                                    Console.Write("Ingresa el nombre: ");
                                    nombreCliente = Console.ReadLine(); Console.WriteLine();
                                    Console.Write("Ingresa el correo: ");
                                    correoCliente = Console.ReadLine(); Console.WriteLine();
                                    Console.Write("Ingresa la dirección: ");
                                    direccionCliente = Console.ReadLine();
                                }
                                switch (opcionCliente)
                                {
                                    case 1:
                                        ClienteRegular nuevoClienteRegular = new ClienteRegular(nombreCliente, correoCliente, direccionCliente);
                                        listaClientes.Add(nuevoClienteRegular);
                                        mensaje.MensajeContinuar();
                                        break;
                                    case 2:
                                        ClienteVip nuevoClienteVip = new ClienteVip(nombreCliente, correoCliente, direccionCliente);
                                        listaClientes.Add(nuevoClienteVip);
                                        mensaje.MensajeContinuar();
                                        break;
                                    case 3:
                                        ClienteCorporativo nuevoClienteCorporativo = new ClienteCorporativo(nombreCliente, correoCliente, direccionCliente);
                                        listaClientes.Add(nuevoClienteCorporativo);
                                        mensaje.MensajeContinuar();
                                        break;
                                    case 4:
                                        Console.Clear();
                                        break;
                                    default:
                                        mensaje.MensajeDefault();
                                        break;
                                }
                            }
                            catch (FormatException)
                            {
                                mensaje.MensajeDeError(); mensaje.MensajeContinuar();
                            }
                        } while (opcionCliente != 4);
                        break;
                    case 2:
                        ICliente clienteSeleccionado; int numeroCliente = 0, matricula = 0; bool validarNumCliente = false, validarMatricula = false;
                        if (listaClientes.Count == 0)
                        {
                            mensaje.NoHayClientes(); break;
                        }
                        do
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("----------Registrar Vehículo----------"); Console.ResetColor();
                            Console.WriteLine("¿A nombre de quién estará el vehículo?:");
                            for (int i = 0; i < listaClientes.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {listaClientes[i].Nombre}");
                            }
                            Console.WriteLine(); Console.Write("Escribe el numero del cliente: ");
                            try
                            {
                                numeroCliente = Convert.ToInt32(Console.ReadLine());
                                if (numeroCliente > 0 && numeroCliente <= listaClientes.Count)
                                {
                                    validarNumCliente = true;
                                    clienteSeleccionado = listaClientes[numeroCliente - 1];
                                }
                            }
                            catch (FormatException) { }
                        } while (!validarNumCliente); Console.WriteLine();
                        do
                        {
                            Console.Write("Ingresa el número de matrícula: ");
                            try
                            {
                                matricula = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                mensaje.MensajeDeError();
                            }
                        } while (!validarMatricula);
                        mensaje.MensajeContinuar();
                        break;
                    case 3:
                        Console.Clear();
                        mensaje.MensajeContinuar();
                        break;
                    case 4:
                        if (listaClientes.Count == 0)
                        {
                            mensaje.NoHayClientes(); break;
                        }
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("----------Mostrar Clientes----------"); Console.ResetColor(); Console.WriteLine();
                        foreach(var cliente in listaClientes)
                        {
                            cliente.MostrarInformacion(); Console.WriteLine();
                        }
                        mensaje.MensajeContinuar();
                        break;
                    case 5:
                        if (listaClientes.Count == 0)
                        {
                            mensaje.NoHayClientes(); break;
                        }
                        Console.Clear();
                        mensaje.MensajeContinuar();
                        break;
                    case 6:
                        Console.Clear();
                        mensaje.MensajeContinuar();
                        break;
                    case 7:
                        if (listaClientes.Count == 0)
                        {
                            mensaje.NoHayClientes(); break;
                        }
                        Console.Clear(); bool nombreEncontrado = false;
                        Console.ForegroundColor= ConsoleColor.Cyan;
                        Console.WriteLine("----------Buscar Cliente----------"); Console.ResetColor(); Console.WriteLine();
                        Console.Write("Ingresa el nombre que quieras buscar: ");
                        string nombreBuscar = Console.ReadLine(); Console.WriteLine();
                        foreach(var cliente in listaClientes)
                        {
                            if (nombreBuscar.ToLower() == cliente.Nombre.ToLower())
                            {
                                cliente.MostrarInformacion(); nombreEncontrado = true;
                            }
                        }
                        if (!nombreEncontrado)
                        {
                            Console.ForegroundColor=ConsoleColor.DarkRed;
                            Console.WriteLine("Este cliente no existe..."); Console.ResetColor();
                        }
                        mensaje.MensajeContinuar();
                        break;
                    case 8:
                        Console.Clear();
                        mensaje.MensajeContinuar();
                        break;
                    case 9:
                        if (listaClientes.Count == 0)
                        {
                            mensaje.NoHayClientes(); break;
                        }
                        Console.Clear();
                        mensaje.MensajeContinuar();
                        break;
                    case 10:
                        Console.Clear();
                        mensaje.Despedida();
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                //mensaje de error
            }
        } while (opcion != 10);
    }
}

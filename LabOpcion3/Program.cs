using LabOpcion3;
using System.Security.Cryptography;

class program
{
    static void Main(string[] args)
    {
        int opcion = 0;
        Mensajes mensaje = new Mensajes();
        List<Cliente> listaClientes = new List<Cliente>();
        List<Reserva> listaReservas = new List<Reserva>();
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
                        int numeroCliente = 0, anio = 0, mes=0, dia=0, hora=0, minuto=0; bool validarNumCliente=false; ICliente clienteSeleccionado;
                        if (listaClientes.Count == 0)   
                        {
                            mensaje.MensajeClientes(); break;
                        }
                        do
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("----Registrar Reserva-----"); Console.ResetColor();
                            Console.WriteLine("¿A nombre de quién estará la reserva?:");
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
                                }
                            }
                            catch (FormatException) { }
                            clienteSeleccionado = listaClientes[numeroCliente - 1];
                        } while (validarNumCliente == false); Console.WriteLine();

                        bool validarAnio = false, validarMes = false, validarDia = false, validarHora = false, validarMinuto = false;
                        Console.WriteLine("--Fecha de la reserva--");
                        do
                        {
                            Console.Write("Ingresa el año: ");
                            try
                            {
                                anio = Convert.ToInt32(Console.ReadLine());
                                if (anio > 0)
                                    validarAnio = true;
                            }
                            catch
                            {
                                mensaje.MensajeDeError(); Console.WriteLine();
                            }
                        }while(validarAnio==false);
                        do
                        {
                            Console.Write("Ingresa el mes: ");
                            try
                            {
                                mes = Convert.ToInt32(Console.ReadLine());
                                if(mes > 0 && mes <=12)
                                    validarMes = true;
                            }
                            catch
                            {
                                mensaje.MensajeDeError(); Console.WriteLine();
                            }
                        } while (validarMes == false);
                        do
                        {
                            Console.Write("Ingresa el dia: ");
                            try
                            {
                                dia = Convert.ToInt32(Console.ReadLine());
                                if(dia > 0 && dia <=31)
                                    validarDia = true;
                            }
                            catch
                            {
                                mensaje.MensajeDeError(); Console.WriteLine();
                            }
                        } while (validarDia == false); Console.WriteLine();
                        Console.WriteLine("--Hora de la reserva--");
                        do
                        {
                            Console.Write("Ingresa la hora (formato 24hrs): ");
                            try
                            {
                                hora = Convert.ToInt32(Console.ReadLine());
                                if (hora > 0 && hora<=23)
                                    validarHora = true;
                            }
                            catch
                            {
                                mensaje.MensajeDeError(); Console.WriteLine();
                            }
                        } while (validarHora == false);
                        do
                        {
                            Console.Write("Ingresa los minutos: ");
                            try
                            {
                                minuto = Convert.ToInt32(Console.ReadLine());
                                if (minuto > 0 && minuto < 60)
                                    validarMinuto = true;
                            }
                            catch
                            {
                                mensaje.MensajeDeError(); Console.WriteLine();
                            }
                        } while (validarMinuto == false);
                        DateTime fechaHora = new DateTime(anio, mes, dia, hora, minuto, 0); Console.WriteLine();

                        List<Plato> platos = new List<Plato>();
                        bool validarPlatillo = false, validarPrecio = false; int cantidadPlatillos = 0, precioPlatillo = 0; string nombrePlatillo = "";
                        Console.WriteLine("--Platillos--");
                        do
                        {
                            Console.Write("Ingresa la cantidad de platillos para la reserva: ");
                            try
                            {
                                cantidadPlatillos = Convert.ToInt32(Console.ReadLine());
                                if (cantidadPlatillos > 0)
                                    validarPlatillo = true;
                            }
                            catch
                            {
                                mensaje.MensajeDeError(); Console.WriteLine();
                            }
                        }while(validarPlatillo == false);
                        for(int i = 1; i <= cantidadPlatillos; i++)
                        {
                            Console.Write($"Ingresa el nombre del platillo {i}: ");
                            nombrePlatillo = Console.ReadLine();
                            do
                            {
                                Console.Write($"Ingresa el precio del platillo {i}: Q");
                                try
                                {
                                    precioPlatillo = Convert.ToInt32(Console.ReadLine());
                                    if(precioPlatillo > 0)
                                    {
                                        validarPrecio = true;
                                        Plato nuevoPlato = new Plato(nombrePlatillo, precioPlatillo);
                                        platos.Add(nuevoPlato);
                                    }
                                }
                                catch (FormatException)
                                {
                                    mensaje.MensajeDeError(); Console.WriteLine();
                                }
                            } while (validarPrecio == false);
                        }
                        Reserva nuevaReserva = new Reserva(fechaHora, clienteSeleccionado, platos);
                        listaReservas.Add(nuevaReserva);
                        mensaje.MensajeContinuar();
                        break;
                    case 3:
                        if (listaClientes.Count == 0)
                        {
                            mensaje.MensajeClientes(); break;
                        }
                        Console.Clear();
                        mensaje.MensajeContinuar();
                        break;
                    case 4:
                        if (listaClientes.Count == 0)
                        {
                            mensaje.MensajeClientes(); break;
                        }
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("--------Info Cliente---------"); Console.ResetColor();
                        mensaje.MensajeContinuar();
                        break;
                    case 5:
                        if (listaClientes.Count == 0)
                        {
                            mensaje.MensajeClientes(); break;
                        }
                        Console.Clear();
                        mensaje.MensajeContinuar();
                        break;
                    case 6:
                        if (listaClientes.Count == 0)
                        {
                            mensaje.MensajeClientes(); break;
                        }
                        Console.Clear();
                        mensaje.MensajeContinuar();
                        break;
                    case 7:
                        Console.Clear(); Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("--------------------");
                        Console.WriteLine("       ADIÓS");
                        Console.WriteLine("--------------------"); Console.ResetColor();
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
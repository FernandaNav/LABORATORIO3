using LABORATORIO3;
using System;
using System.Net.Http.Json;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Mensajes mensaje = new Mensajes();
        List<ClienteRegular> listaClientes = new List<ClienteRegular>();
        List<Vehiculo> listaVehiculos = new List<Vehiculo>();
        List<Pedido> listaPedidos = new List<Pedido>();
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
                        string nombreCliente = "", correoCliente = "", direccionCliente = "";
                        do
                        {
                            mensaje.MenuCliente();
                            try
                            {
                                opcionCliente = Convert.ToInt32(Console.ReadLine());
                                if (opcionCliente == 1 || opcionCliente == 2 || opcionCliente == 3)
                                {
                                    Console.Clear(); Console.ForegroundColor = ConsoleColor.DarkCyan;
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
                        ICliente clienteSeleccionado = null; int numeroCliente = 0, opcionVehiculo = 0; bool validarNumCliente = false, validarMatricula; string matricula = "", modelo = "", tipoDeCombustible = "";
                        if (listaClientes.Count == 0)
                        {
                            mensaje.NoHayClientes(); break;
                        }
                        do
                        {
                            mensaje.MenuVehiculos();
                            try
                            {
                                opcionVehiculo = Convert.ToInt32(Console.ReadLine());
                                if (opcionVehiculo == 1 || opcionVehiculo == 2)
                                {
                                    mensaje.MensajeContinuar();
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("----------información Vehículo----------"); Console.ResetColor(); Console.WriteLine();
                                    do
                                    {
                                        validarMatricula = true;
                                        Console.Write("Ingresa la matricula: ");
                                        matricula = Console.ReadLine(); Console.WriteLine();
                                        foreach(var vehiculo1 in listaVehiculos)
                                        {
                                            if (matricula.ToLower() == vehiculo1.Matricula.ToLower())
                                            {
                                                validarMatricula = false;
                                                break;
                                            }
                                        }
                                        if (!validarMatricula)
                                        {
                                            Console.ForegroundColor= ConsoleColor.DarkRed;
                                            Console.WriteLine("Matrícula existente, por favor intenta de nuevo."); Console.WriteLine(); Console.ResetColor();
                                        }
                                    } while (!validarMatricula);
                                    Console.Write("Ingresa el modelo: ");
                                    modelo = Console.ReadLine(); Console.WriteLine();
                                    Console.Write("Ingresa el tipo de combustible: ");
                                    tipoDeCombustible = Console.ReadLine(); Console.WriteLine();
                                    do
                                    {
                                        Console.WriteLine("¿A nombre de quién estará el vehículo?:");
                                        for (int i = 0; i < listaClientes.Count; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. {listaClientes[i].Nombre}");
                                        }
                                        Console.WriteLine(); Console.Write("Escribe el numero del cliente: ");
                                        string entradaCliente = Console.ReadLine();

                                        if (int.TryParse(entradaCliente, out numeroCliente) && numeroCliente > 0 && numeroCliente <= listaClientes.Count)
                                        {
                                            validarNumCliente = true;
                                            clienteSeleccionado = listaClientes[numeroCliente - 1];
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("Número de cliente inválido o fuera de rango."); Console.ResetColor();
                                        }
                                    } while (!validarNumCliente);
                                }
                                switch (opcionVehiculo)
                                {
                                    case 1:
                                        if (clienteSeleccionado is ClienteCorporativo)
                                        {
                                            VehiculoCorporativo nuevoVehiculoCorporativo = new VehiculoCorporativo(matricula, modelo, tipoDeCombustible, clienteSeleccionado);
                                            listaVehiculos.Add(nuevoVehiculoCorporativo); Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.WriteLine("Vehículo corporativo registrado correctamente");
                                        }
                                        else if (clienteSeleccionado is ClienteRegular || clienteSeleccionado is ClienteVip)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("El cliente seleccionado no es corporativo."); Console.ResetColor();
                                        }
                                        mensaje.MensajeContinuar();
                                        break;
                                    case 2:
                                        VehiculoPersonal nuevoVehiculoPersonal = new VehiculoPersonal(matricula, modelo, tipoDeCombustible, clienteSeleccionado);
                                        listaVehiculos.Add(nuevoVehiculoPersonal); Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("Vehículo personal registrado correctamente");
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
                            catch
                            {
                                mensaje.MensajeDeError(); mensaje.MensajeContinuar();
                            }
                        } while (opcionVehiculo != 3);
                        break;
                    case 3:
                        bool validarNumeroCliente = false; int numeroDeClienteEntero = 0, anio = 0, mes = 0, dia = 0; ICliente clienteElegido = null;
                        if (listaClientes.Count == 0)
                        {
                            mensaje.NoHayClientes(); break;
                        }
                        do
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("----------Registrar Pedidos----------"); Console.ResetColor(); Console.WriteLine();
                            Console.WriteLine("¿De quién es el pedido?");
                            for (int i = 0; i < listaClientes.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {listaClientes[i].Nombre}");
                            }
                            Console.WriteLine(); Console.Write("Escribe el número del cliente: ");
                            string numeroDeCliente = Console.ReadLine();

                            if (int.TryParse(numeroDeCliente, out numeroDeClienteEntero) && numeroDeClienteEntero > 0 && numeroDeClienteEntero <= listaClientes.Count)
                            {
                                validarNumeroCliente = true;
                                clienteElegido = listaClientes[numeroDeClienteEntero - 1];
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Número de cliente inválido o fuera de rango."); Console.ResetColor();
                            }
                        } while (!validarNumeroCliente); Console.WriteLine();
                        bool validarAnio = false, validarMes = false, validarDia = false;
                        Console.WriteLine("------Fecha------");
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
                        } while (validarAnio == false);
                        do
                        {
                            Console.Write("Ingresa el mes: ");
                            try
                            {
                                mes = Convert.ToInt32(Console.ReadLine());
                                if (mes > 0 && mes <= 12)
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
                                if (dia > 0 && dia <= 31)
                                    validarDia = true;
                            }
                            catch
                            {
                                mensaje.MensajeDeError(); Console.WriteLine();
                            }
                        } while (validarDia == false); Console.WriteLine();
                        DateTime fecha = new DateTime(anio, mes, dia);
                        List<Producto> listaProductos = new List<Producto>();
                        int cantidadProductos = 0; bool validarCantidad = false, validarPrecioProducto = false; string nombreProducto = ""; double precioProducto = 0;
                        Console.WriteLine("------Productos------");
                        do
                        {
                            Console.Write("Ingresa la cantidad de productos a comprar: ");
                            try
                            {
                                cantidadProductos = Convert.ToInt32(Console.ReadLine());
                                if (cantidadProductos > 0)
                                {
                                    validarCantidad = true;
                                }
                            }
                            catch (FormatException)
                            {
                                mensaje.MensajeDeError();
                            }
                        } while (!validarCantidad);
                        for (int i = 1; i <= cantidadProductos; i++)
                        {
                            Console.Write($"Ingresa el nombre del producto #{i}: ");
                            nombreProducto = Console.ReadLine();
                            do
                            {
                                Console.Write($"Ingresa el precio del producto #{i}: Q");
                                try
                                {
                                    precioProducto = Convert.ToDouble(Console.ReadLine());
                                    if (precioProducto > 0)
                                    {
                                        validarPrecioProducto = true;
                                        Producto nuevoProducto = new Producto(nombreProducto, precioProducto);
                                        listaProductos.Add(nuevoProducto);
                                    }
                                }
                                catch (FormatException)
                                {
                                    mensaje.MensajeDeError(); Console.WriteLine();
                                }
                            } while (!validarPrecioProducto);
                            Console.WriteLine();
                        }
                        Pedido nuevoPedido = new Pedido(clienteElegido, fecha, listaProductos);
                        listaPedidos.Add(nuevoPedido);
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
                        foreach (var cliente in listaClientes)
                        {
                            cliente.MostrarInformacion(); Console.WriteLine();
                        }
                        mensaje.MensajeContinuar();
                        break;
                    case 5:

                        if (listaVehiculos.Count == 0)
                        {
                            mensaje.NoHayVehiculos(); break;
                        }
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("----------Mostrar Vehículos----------"); Console.ResetColor(); Console.WriteLine();
                        foreach (var vehiculo in listaVehiculos)
                        {
                            vehiculo.MostrarVehiculos(); Console.WriteLine();
                        }
                        mensaje.MensajeContinuar();
                        break;
                    case 6:
                        if (listaPedidos.Count == 0)
                        {
                            mensaje.NoHayPedidos(); break;
                        }
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("----------Mostrar Pedidos----------"); Console.ResetColor(); Console.WriteLine();
                        foreach (var pedido in listaPedidos)
                        {
                            pedido.MostrarPedido(); Console.WriteLine();
                        }
                        mensaje.MensajeContinuar();
                        break;
                    case 7:
                        if (listaClientes.Count == 0)
                        {
                            mensaje.NoHayClientes(); break;
                        }
                        Console.Clear(); bool nombreEncontrado = false;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("----------Buscar Cliente----------"); Console.ResetColor(); Console.WriteLine();
                        Console.Write("Ingresa el nombre que quieras buscar: ");
                        string nombreBuscar = Console.ReadLine(); Console.WriteLine();
                        foreach (var cliente in listaClientes)
                        {
                            if (nombreBuscar.ToLower() == cliente.Nombre.ToLower())
                            {
                                cliente.MostrarInformacion(); nombreEncontrado = true;
                            }
                        }
                        if (!nombreEncontrado)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Cliente no encontrado..."); Console.ResetColor();
                        }
                        mensaje.MensajeContinuar();
                        break;
                    case 8:
                        if (listaVehiculos.Count == 0)
                        {
                            mensaje.NoHayVehiculos(); break;
                        }
                        Console.Clear(); bool vehiculoEncontrado = false;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("----------Buscar Vehiculo----------"); Console.ResetColor(); Console.WriteLine();
                        Console.Write("Ingresa la matricula del vehiculo que quieres buscar: ");
                        string buscarMatricula = Console.ReadLine(); Console.WriteLine();
                        foreach (var vehiculo in listaVehiculos)
                        {
                            if (buscarMatricula.ToLower() == vehiculo.Matricula.ToLower())
                            {
                                vehiculo.MostrarVehiculos(); vehiculoEncontrado = true;
                            }
                        }
                        if (!vehiculoEncontrado)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Vehiculo no encontrado..."); Console.ResetColor();
                        }
                        mensaje.MensajeContinuar();
                        break;
                    case 9:
                        if (listaPedidos.Count == 0)
                        {
                            mensaje.NoHayPedidos(); break;
                        }
                        Console.Clear();
                        Console.Clear(); bool pedidoEncontrado = false;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("----------Buscar Pedido----------"); Console.ResetColor(); Console.WriteLine();
                        Console.Write("Ingresa el número del pedido que quieres buscar: ");
                        string buscarId = Console.ReadLine(); Console.WriteLine();
                        int id = Convert.ToInt32(buscarId);
                        foreach(var pedido in listaPedidos)
                        {
                            if(id == pedido.IdPedido)
                            {
                                pedido.MostrarPedido();
                                pedidoEncontrado = true;
                            }
                        }
                        if (!pedidoEncontrado)
                        {
                            Console.ForegroundColor= ConsoleColor.DarkRed;
                            Console.WriteLine("Pedido no encontrado...");
                        }
                        mensaje.MensajeContinuar();
                        break;
                    case 10:
                        Console.Clear();
                        mensaje.Despedida();
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
        } while (opcion != 10);
    }
}

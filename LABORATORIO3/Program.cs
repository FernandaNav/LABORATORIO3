using LABORATORIO3;

class program
{
    static void Main(string[] args)
    {
        Mensajes mensaje = new Mensajes();
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
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("-------Registrar Cliente-------");
                            Console.WriteLine();
                            Console.WriteLine("1. Cliente regular");
                            Console.WriteLine("2. Cliente VIP");
                            Console.WriteLine("3. Cliente Corporativo");
                            Console.WriteLine("3. Regresar a menú principal"); Console.WriteLine();
                            Console.WriteLine("Ingresa la opción");
                            try
                            {
                                opcionCliente = Convert.ToInt32(Console.ReadLine());
                                switch (opcionCliente)
                                {
                                    case 1:
                                        mensaje.MensajeContinuar();
                                        break;
                                    case 2:
                                        mensaje.MensajeContinuar();
                                        break;
                                    case 3:
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
                        mensaje.MensajeContinuar();
                        break;
                    case 2:
                        Console.Clear();
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
        } while (opcion != 6);
    }
}

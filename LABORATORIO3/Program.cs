class program
{
    static void Main(string[] args)
    {
        int opcion = 0;
        do
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("       BIENVENIDO");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Registrar vehículo");
            Console.WriteLine("3. Registrar Pedido");
            Console.WriteLine("4. Mostrar información");
            Console.WriteLine("5. Buscar información");
            Console.WriteLine("6. Salir");
            Console.WriteLine();
            Console.Write("Ingresa una opción: ");
            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
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

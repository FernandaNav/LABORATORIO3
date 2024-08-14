using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOpcion3
{
    public class ClienteVip: Cliente
    {
        public double Descuento {  get; set; }
        public ClienteVip(string nombre, string correo, int numeroTelefonico, double descuento)
        : base(nombre, correo, numeroTelefonico)
        {
            Descuento = descuento;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Porcentaje de descuento: {Descuento}%");
        }
    }
}

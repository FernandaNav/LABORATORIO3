using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABORATORIO3
{
    public class ClienteCorporativo: ClienteRegular
    {
        public double DescuentoCorporativo {  get; set; }
        public ClienteCorporativo(string nombre, string correo, string direccion)
            : base(nombre, correo, direccion)
        {
            DescuentoCorporativo = 40;
        }
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Porcentaje de descuento: {DescuentoCorporativo}");
            Console.WriteLine("Detalles extras: Cliente Corporativo");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABORATORIO3
{
    public class ClienteVip: ClienteRegular
    {
        public double DescuentoVip {  get; set; }
        public ClienteVip(string nombre, string correo, string direccion)
            : base(nombre, correo, direccion)
        {
            DescuentoVip = 20;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Porcentaje de descuento: {DescuentoVip}");
        }
    }
}

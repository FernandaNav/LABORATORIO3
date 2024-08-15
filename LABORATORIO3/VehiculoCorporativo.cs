using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABORATORIO3
{
    public class VehiculoCorporativo: Vehiculo
    {
        public VehiculoCorporativo(string matricula, string modelo, string tipoDeCombustible, ICliente cliente)
            :base(matricula, modelo, tipoDeCombustible, cliente)
        {

        }
        public override void MostrarVehiculos()
        {
            base.MostrarVehiculos();
            Console.WriteLine("Tipo de vehículo: Corporativo");
        }
    }
}

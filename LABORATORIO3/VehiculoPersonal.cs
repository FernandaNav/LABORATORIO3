using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABORATORIO3
{
    public class VehiculoPersonal: Vehiculo
    {
        public VehiculoPersonal(string matricula, string modelo, string tipoDeCombustible, ICliente cliente)
            : base(matricula, modelo, tipoDeCombustible, cliente)
        {

        }
    }
}

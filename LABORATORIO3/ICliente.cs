using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LABORATORIO3
{
    public interface ICliente
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
}

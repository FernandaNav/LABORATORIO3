using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOpcion3
{
    public interface ICliente
    {
        string Nombre { get; set; }
        string Correo { get; set; }
        int NumeroTelefonico { get; set; }
    }
}

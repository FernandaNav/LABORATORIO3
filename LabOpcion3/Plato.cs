using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOpcion3
{
    public class Plato
    {
        public string NombrePlato {  get; set; }
        public double PrecioPlato { get; set; }

        public Plato(string nombrePlato, double precioPlato)
        {
            NombrePlato = nombrePlato;
            PrecioPlato = precioPlato;
        }

        public void MostrarPlatos()
        {
            Console.WriteLine($"Nombre del plato: {NombrePlato}");
            Console.WriteLine($"Precio: Q{PrecioPlato}");
        }
    }
}

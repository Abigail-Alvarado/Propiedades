using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedades
{
    class prop
    {
        string nombre, dpi, apellido;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Dpi { get => dpi; set => dpi = value; }
        public string Apellido { get => apellido; set => apellido = value; }
    }
}

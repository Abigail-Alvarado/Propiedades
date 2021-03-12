using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedades
{
    class Total
    {
        string nombre_apellido, numerocasa;
        float cuotamantenimiento;

        public string Nombre_apellido { get => nombre_apellido; set => nombre_apellido = value; }
        public string Numerocasa { get => numerocasa; set => numerocasa = value; }
        public float Cuotamantenimiento { get => cuotamantenimiento; set => cuotamantenimiento = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad01.Datos.Utils
{
    public class ParameterSQL
    {
        public object Valor { get; set; }
        public string Nombre { get; set; }

        public ParameterSQL(string nombre, object valor)
        {
            this.Nombre = nombre;
            this.Valor = valor;
        }
    }
}

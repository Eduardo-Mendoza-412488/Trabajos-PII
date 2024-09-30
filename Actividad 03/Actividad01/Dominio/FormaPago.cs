using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad01.Dominio
{
    public class FormaPago
    {
        public int IdFp { get; set; }
        public string FormPago { get; set; }

        public FormaPago()
        {

        }

        public override string? ToString()
        {
            return FormPago;
        }
    }
}

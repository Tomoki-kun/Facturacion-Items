using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionItems
{
    internal class CuitException:Exception
    {
        public CuitException():base("Error en el numero de CUIT") { }
        public CuitException(string msg):base(msg) { }
        public CuitException(string msg, Exception ex):base(msg, ex) { }
    }
}

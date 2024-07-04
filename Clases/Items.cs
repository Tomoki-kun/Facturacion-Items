using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionItems
{
    [Serializable]
    internal abstract class Items
    {
        public int Codigo { get; set; }

        public abstract string Descripcion();
        public abstract double Precio();
    }
}

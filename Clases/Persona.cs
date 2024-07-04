using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionItems
{
    [Serializable]
    internal class Persona
    {
        private string nombre;
        private long cuit;

        public Persona(string nombre, long cuit)
        {
            this.nombre = nombre;
            this.cuit = cuit;
        }

        public override string ToString()
        {
            return this.nombre + " " + this.cuit;
        }
    }
}

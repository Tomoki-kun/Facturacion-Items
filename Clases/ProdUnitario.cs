using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionItems
{
    [Serializable]
    internal class ProdUnitario : Items
    {
        private string nombre;
        private string unidadDeMedida;
        public double Cantidad {  get; set; }
        public double PrecioUnidad { get; set; }

        public ProdUnitario(int codigo, string nombre, string unidad)
        {
            this.Codigo = codigo;
            this.nombre = nombre;
            this.unidadDeMedida = unidad;
        }
        public override string Descripcion()
        {
            return this.nombre + "\t Unidad de medida: " + this.unidadDeMedida;
        }

        public override double Precio()
        {
            double precio = this.PrecioUnidad * Cantidad;
            precio = precio + precio * 0.07 ;
            return precio;
        }
    }
}

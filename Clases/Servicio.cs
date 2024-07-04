using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionItems
{
    [Serializable]
    internal class Servicio : Items
    {
        private string detalle;
        private double precioHora;

        public int Tiempo { get; set; }

        public Servicio(int codigo, string detalle, double precioHora)
        {
            this.Codigo = codigo;
            this.detalle = detalle;
            this.precioHora = precioHora;
        }
        public override string Descripcion()
        {
            return detalle + "\tPrecio x Hora: " + this.precioHora.ToString("C");
        }
        public override double Precio()
        {
            return precioHora * Tiempo;
        }
    }
}

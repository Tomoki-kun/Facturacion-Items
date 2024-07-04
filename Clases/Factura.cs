using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionItems
{
    [Serializable]
    internal class Factura
    {
        private Persona cliente;
        private DateTime fechaHora;
        
        public double Iva {  get; set; }
        public double precioTotal { get; set; }
        public int CantidadItems { get; set; }

        private static int NroFactura;
        private int nroFactura;
        List<Items> lstItems;

        public Factura(string nombre, long cuit)
        {
            cliente = new Persona(nombre, cuit);
            this.fechaHora = DateTime.Now;
            this.precioTotal = 0;
            this.CantidadItems = 0;
            this.nroFactura = NroFactura++;
            lstItems = new List<Items>();
            this.Iva = 0.21;
        }

        public void AgregarItems(Items linea)
        {
            if (linea != null)
            {
                this.lstItems.Add(linea);
                CantidadItems++;
                precioTotal += linea.Precio();
            }
        }
        public double PrecioSinIva()
        {
             return precioTotal - precioTotal*Iva;
        }

        public Items MostrarItems(int numero)
        {
            Items itemRet = null;
            int i = 0;
            int max = lstItems.Count;
            while (itemRet == null && i < max)
            {
                if (numero == lstItems[i].Codigo)
                {
                    itemRet = lstItems[i];
                }    
                i++;
            }
            return itemRet;
        }

        public override string ToString()
        {
            return this.nroFactura + ";" + cliente.ToString() + ";" + fechaHora.ToString("d") + ";" + fechaHora.ToString("t") + ";" + this.precioTotal;
        }
    }
}

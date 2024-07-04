using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionItems.Excepcion
{
    public partial class FAgregarItem : Form
    {
        public FAgregarItem()
        {
            InitializeComponent();
        }

        private void FAgregarItem_Load(object sender, EventArgs e)
        {
            num.Maximum = Decimal.MaxValue;
        }
    }
}

using FacturacionItems.Excepcion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionItems
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lstItems.Add(new ProdUnitario(1, "Soldador Lapiz 60W", "Unidad"));
            lstItems.Add(new ProdUnitario(2, "Estaño", "gr"));
            lstItems.Add(new ProdUnitario(3, "Resistencia", "Ohm"));
            lstItems.Add(new Servicio(4, "Reparacion celular", 2.4));
            lstItems.Add(new Servicio(5, "Service PC", 55.5));
            lstItems.Add(new Servicio(6, "Otros", 100));

            foreach (Items item in lstItems)
                lbItems.Items.Add(item.Descripcion());
        }

        string serUnser = Application.StartupPath + "\\Datos.dat";
        List<Factura> lstFacturas = new List<Factura>();
        List<Items> lstItems = new List<Items>();
        List<Items> lstCarrito = new List<Items>();
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(serUnser))
            {
                FileStream fs = new FileStream(serUnser, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    lstFacturas = (List<Factura>)bf.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { fs.Close(); }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (lstFacturas.Count > 0)
            {
                if (File.Exists(serUnser))
                {
                    File.Delete(serUnser);
                }
                FileStream fs = new FileStream(serUnser, FileMode.CreateNew, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    bf.Serialize(fs, lstFacturas);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { fs.Close(); }
            }
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            FAgregarItem vAgregarItem = new FAgregarItem();
            if (lbItems.SelectedIndex != -1)
            {
                bool esServicio = true;
                Items itemSeleccionado = lstItems[lbItems.SelectedIndex];
                if (itemSeleccionado is Servicio)
                {
                    vAgregarItem.label.Text = "Tiempo: ";
                    vAgregarItem.num.DecimalPlaces = 0;
                }
                if (itemSeleccionado is ProdUnitario)
                {
                    vAgregarItem.label.Text = "Cantidad: ";
                    vAgregarItem.num.DecimalPlaces = 3;
                    esServicio = false;
                }
                if (vAgregarItem.ShowDialog() == DialogResult.OK)
                {
                    if (esServicio)
                    {
                        ((Servicio)itemSeleccionado).Tiempo = (int)vAgregarItem.num.Value;
                    }
                    else
                        ((ProdUnitario)itemSeleccionado).Cantidad = (double)vAgregarItem.num.Value;
                    lstCarrito.Add(itemSeleccionado);
                }

            }
            else
                MessageBox.Show("Seleccione un item de la lista");
            vAgregarItem.Dispose();
        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {
            if (lstCarrito.Count > 0)
            {
                double total = 0;
                FVerCarrito vVerCarrito = new FVerCarrito();
                foreach (Items item in lstCarrito)
                {
                    vVerCarrito.lbLista.Items.Add(item.Descripcion() + item.Precio());
                    total += item.Precio();
                }
                vVerCarrito.lbLista.Items.Add("Total:\t\t\t"+total.ToString("C"));

                vVerCarrito.ShowDialog();
                vVerCarrito.Dispose();
            }
            else
            {
                MessageBox.Show("No hay items cargados en el carrito");
            }
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            if (lstCarrito.Count > 0)
            {
                FFactura vFactura = new FFactura();
                bool incorrecto = true;
                while (incorrecto && vFactura.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Factura nuevaFactura = new Factura(vFactura.txtNombre.Text, (long)vFactura.numCUIT.Value);
                        foreach(Items item in lstCarrito)   
                            nuevaFactura.AgregarItems(item);
                        lstFacturas.Add(nuevaFactura);
                        incorrecto = false;
                        lstCarrito.Clear();
                    }
                    catch (CuitException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                vFactura.Dispose();
            }
            else
            {
                MessageBox.Show("No hay items cargados en el carrito");
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            leerDialog.Filter = "Archivos CSV (*.csv) | *.csv";

            if (leerDialog.ShowDialog() == DialogResult.OK)
            {
                string archivito = leerDialog.FileName;
                if (File.Exists(archivito))
                {
                    lstCarrito.Clear();
                    FileStream fs = new FileStream(archivito, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    try
                    {
                        while (!sr.EndOfStream)
                        {
                            string[] renglon = sr.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            if (renglon.Length == 4)
                            {
                                try
                                {
                                    Items producto = new ProdUnitario(Convert.ToInt32(renglon[0]), renglon[1], renglon[2]);
                                    ((ProdUnitario)producto).PrecioUnidad = Convert.ToDouble(renglon[3]);
                                    lstItems.Add(producto);
                                    lbItems.Items.Add(producto.Descripcion());
                                }
                                catch (FormatException ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        sr.Close();
                        fs.Close();
                    }
                }
                else
                {
                    MessageBox.Show("El archivo ingresado no existe");
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            guardarDialog.Filter = "Archivos CSV (*.csv) | *.csv";
            if (lstFacturas.Count > 0)
            {
                if (guardarDialog.ShowDialog() == DialogResult.OK)
                {
                    string exportar = guardarDialog.FileName;
                    try
                    {
                        if (File.Exists(exportar)) { File.Delete(exportar); }
                        FileStream fs = new FileStream(exportar, FileMode.CreateNew, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs);
                        try
                        {
                            foreach (Factura factura in lstFacturas)
                            {
                                sw.WriteLine(factura.ToString());
                            }
                        }
                        catch
                        {

                        }
                        finally { sw.Close(); fs.Close(); }
                    }
                    catch (IOException ex) { MessageBox.Show(ex.Message); }
                }
            }

            else
                MessageBox.Show("No hay clientes para exportar");

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

        }
    }
}

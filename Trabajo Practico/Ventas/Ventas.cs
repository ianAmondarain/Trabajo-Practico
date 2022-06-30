using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_Practico
{
    public partial class Ventas : Form
    {

        public Ventas()
        {
            InitializeComponent();

        }
        BE.Ventas temp;
        BLL.Ventas_BLL gestor = new BLL.Ventas_BLL();
        BLL.Producto_BLL GestorProducto = new BLL.Producto_BLL();
        BLL.Cliente_BLL GestorCliente = new BLL.Cliente_BLL();
        private void Ventas_Load(object sender, EventArgs e)
        {
            listar();
            LlenarComboClientes();
            LlenarComboProductos();
            lblTotal.Text = gestor.TotalVentas().ToString();
        }

        void LlenarComboClientes()
        {
            List<BE.Cliente> Cliente = GestorCliente.Listar();

            for (int i = 0; i < Cliente.Count; i++)
            {
                cmbIDClientes.Items.Add(Cliente[i]._IDCLIENTE);
                cmbTotalVentas.Items.Add(Cliente[i]._IDCLIENTE);
            }

        }

        void LlenarComboProductos()
        {
            List<BE.Producto> Producto = GestorProducto.Listar();
            for (int i = 0; i < Producto.Count; i++)
            {
                cmbProducto.Items.Add(Producto[i]._Descripcion);
            }
        }
        void listar()
        {
            datagridVentas.DataSource = null;
            datagridVentas.DataSource = gestor.Listar();
        }
        void limpiartxt()
        {
            
            txtVentas.Clear();
            txtCantidad.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
        }
        void Agregar_Venta()
        {
            temp = new BE.Ventas();
            temp._IDVentas = int.Parse(txtVentas.Text);
            temp._IDClientes = int.Parse(cmbIDClientes.Text);
            temp._Descripcion = cmbProducto.Text;
            temp._Cantidad = int.Parse(txtCantidad.Text);
            temp._PrecioUnitario = float.Parse(txtPrecioCompra.Text);
            temp._PrecioVenta = float.Parse(txtPrecioVenta.Text);
            try
            {
                gestor.Agregar(temp);
                MessageBox.Show("Agregado Correctamente...");
                listar();
                txtVentas.Text = cmbIDClientes.Text = cmbProducto.Text = txtCantidad.Text = txtPrecioCompra.Text = txtPrecioVenta.Text = "";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            temp = new BE.Ventas();
            temp._IDVentas = int.Parse(txtVentas.Text);
            try
            {
                gestor.Eliminar(temp);
                MessageBox.Show("eliminado correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                temp = (BE.Ventas)datagridVentas.Rows[e.RowIndex].DataBoundItem;
                txtVentas.Text = temp._IDVentas.ToString();
                cmbIDClientes.Text = temp._IDClientes.ToString();
                cmbProducto.Text = temp._Descripcion;
                txtCantidad.Text = temp._Cantidad.ToString();
                txtPrecioCompra.Text = temp._PrecioUnitario.ToString();
                txtPrecioVenta.Text = temp._PrecioVenta.ToString();
            }
            catch 
            {
                
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            limpiartxt();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<BE.Producto> Producto = GestorProducto.Listar();
            txtPrecioCompra.Text = Producto[cmbProducto.SelectedIndex]._Precio_Compra.ToString();

        }

        private void cmbTotalVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<BE.Ventas> Venta = gestor.Listar();
                List<BE.Ventas> venta = gestor.ListarID(int.Parse(cmbTotalVentas.Text));
                datagridVentas.DataSource = null;
                datagridVentas.DataSource = gestor.ListarID(Venta[0]._IDClientes);
                txtVentas.Text = Venta[cmbTotalVentas.SelectedIndex]._IDClientes + "" + Venta[0]._IDClientes;
                for (int i = 0; i < venta.Count; i++)
                {
                    datagridVentas.DataSource = null;
                    datagridVentas.DataSource = gestor.ListarID(Venta[i]._IDClientes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Agregar_Venta();
                MessageBox.Show("Venta Agregada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            temp = new BE.Ventas();
            temp._IDVentas = 0;
            temp._IDClientes = int.Parse(cmbIDClientes.Text);
            temp._Descripcion = cmbProducto.Text;
            temp._Cantidad = int.Parse(txtCantidad.Text);
            temp._PrecioUnitario = int.Parse(txtPrecioCompra.Text);
            temp._PrecioVenta = int.Parse(txtVentas.Text);
            try
            {
                gestor.Modificar(temp);
                MessageBox.Show("Venta Modificada");
                listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

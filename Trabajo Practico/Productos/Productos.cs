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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }
        BE.Producto Prod;
        BLL.Producto_BLL gestor = new BLL.Producto_BLL();

        void Agregar_Producto()
        {
            Prod = new BE.Producto();
            Prod._ID = int.Parse(txtID.Text);
            Prod._Descripcion = txtDescripcion.Text;
            Prod._Stock = int.Parse(txtStock.Text);
            Prod._Precio_Compra = float.Parse(txtPrecioCompra.Text);
            Prod._Precio_Venta = float.Parse(txtVenta.Text);
            try
            {
                gestor.Agregar(Prod);
                MessageBox.Show("Agregado Correctamente...");
                Listar();
                txtID.Text = txtDescripcion.Text = txtStock.Text = txtPrecioCompra.Text = txtVenta.Text = "";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
  
        void Listar()
        {
            DataProductos.DataSource = null;
            DataProductos.DataSource = gestor.Listar();
        }
   
        private void Productos_Load(object sender, EventArgs e)
        {
            Listar();

        }

   
        void limpiartxt()
        {
            txtID.Clear();
            txtDescripcion.Clear();
            txtPrecioCompra.Clear();
            txtStock.Clear();
            txtVenta.Clear();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {

            try
            {
                Agregar_Producto();
                MessageBox.Show("producto agregado");

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Modificar_Click_1(object sender, EventArgs e)
        {
            Prod = new BE.Producto();
            Prod._ID = int.Parse(txtID.Text);
            Prod._Descripcion = txtDescripcion.Text;
            Prod._Stock = int.Parse(txtStock.Text);
            Prod._Precio_Compra = float.Parse(txtPrecioCompra.Text);
            Prod._Precio_Venta = float.Parse(txtVenta.Text);
            try
            {
                gestor.Modificar(Prod);
                MessageBox.Show("Producto modificado");
                Listar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            limpiartxt();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Prod = new BE.Producto();
            Prod._ID = int.Parse(txtID.Text);
            try
            {
                gestor.Eliminar(Prod);
                MessageBox.Show("producto eliminado");
                Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DataProductos_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Desea eliminar el producto ?", "Eliminando registros...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Prod = (BE.Producto)DataProductos.Rows[e.RowIndex].DataBoundItem;
                    gestor.Eliminar(Prod);
                    MessageBox.Show("producto eliminado....");
                    Listar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void DataProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Prod = (BE.Producto)DataProductos.Rows[e.RowIndex].DataBoundItem;
                txtID.Text = Prod._ID.ToString();
                txtDescripcion.Text = Prod._Descripcion;
                txtStock.Text = Prod._Stock.ToString();
                txtPrecioCompra.Text = Prod._Precio_Compra.ToString();
                txtVenta.Text = Prod._Precio_Venta.ToString();
            }
            catch
            {

            }
        }
    }
}


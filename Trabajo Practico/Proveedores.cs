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
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        BE.Proveedores temp;
        BLL.Proveedores_BLL gestor = new BLL.Proveedores_BLL();
        void Agregar_Proveedor()
        {
            temp = new BE.Proveedores();
            temp._IdProveedores = int.Parse(txtID.Text);
            temp._Nombre = txtNombre.Text;
            temp._Trayecto = txtTrayecto.Text;
            try
            {
                gestor.Agregar(temp);
                MessageBox.Show("Agregado Correctamente...");
                Listar();
                txtID.Text = txtNombre.Text = txtTrayecto.Text = "";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                Agregar_Proveedor();
                MessageBox.Show("proveedor agregado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
        }
        void limpiartxt()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtTrayecto.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temp = new BE.Proveedores();
            temp._IdProveedores = int.Parse(txtID.Text);
            temp._Nombre = txtNombre.Text;
            temp._Trayecto = txtTrayecto.Text;
            try
            {
                gestor.Modificar(temp);
                MessageBox.Show("proveedor modificado");
                Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            limpiartxt();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            Listar();
        }
        void Listar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gestor.Listar();
        }
    

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                temp = (BE.Proveedores)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                txtID.Text = temp._IdProveedores.ToString();
                txtNombre.Text = temp._Nombre;
                txtTrayecto.Text = temp._Trayecto;
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Trabajo_Practico
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }
        BE.Cliente Cliente;
        BLL.Cliente_BLL gestor = new BLL.Cliente_BLL();
        private void Clientes_Load(object sender, EventArgs e)
        {
            VerDatos();
        }
        void Agregar_Cliente()
        {
            Cliente = new BE.Cliente();
            Cliente._IDCLIENTE = int.Parse(txtID.Text);
            Cliente._Nombre = txtNombre.Text;
            Cliente._Apellido = txtApellido.Text;
            Cliente._CUIT = int.Parse(txtCuit.Text);
            Cliente._Telefono = int.Parse(txtTelefono.Text);
            try
            {
                gestor.Agregar(Cliente);
                MessageBox.Show("Agregado Correctamente...");
                VerDatos();
                txtID.Text = txtNombre.Text = txtApellido.Text = txtCuit.Text = txtTelefono.Text = "";
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
                Agregar_Cliente();
                MessageBox.Show("Cliente Agregado");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
         
        }
  

     

        void VerDatos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gestor.Listar();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Cliente = new BE.Cliente();
            Cliente._IDCLIENTE = int.Parse(txtID.Text);
            Cliente._Nombre = txtNombre.Text;
            Cliente._Apellido = txtApellido.Text;
            Cliente._CUIT = int.Parse(txtCuit.Text);
            Cliente._Telefono = int.Parse(txtTelefono.Text);
            try
            {
                gestor.Modificar(Cliente);
                MessageBox.Show("Modificado correctamente");
                VerDatos();
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
                Cliente = (BE.Cliente)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                txtID.Text = Cliente._IDCLIENTE.ToString();
                txtNombre.Text = Cliente._Nombre;
                txtApellido.Text = Cliente._Apellido;
                txtCuit.Text = Cliente._CUIT.ToString();
                txtTelefono.Text = Cliente._Telefono.ToString();
            }
            catch 
            {
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cliente = new BE.Cliente();
            Cliente._IDCLIENTE = int.Parse(txtID.Text);
            gestor.Eliminar(Cliente);
            MessageBox.Show("eliminado correctamente");
            VerDatos();
            
        }
    }
}
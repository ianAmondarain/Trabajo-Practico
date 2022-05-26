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
    public partial class Bienvenido_QA : Form
    {
        public Bienvenido_QA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Crear_Usuarios usuarios = new Crear_Usuarios();
            usuarios.Show();

        }

        private void Bienvenido_QA_Load(object sender, EventArgs e)
        {
            
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Productos productos = new Productos();
            productos.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.Show();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();
            ventas.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Proveedores proveedores = new Proveedores();
            proveedores.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            Rol.Roles roles = new Rol.Roles();
            roles.Show(); 
        }
    }
}

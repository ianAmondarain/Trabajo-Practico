using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Security.Cryptography;

namespace Trabajo_Practico
{
    public partial class Crear_Usuarios : Form
    {
        public Crear_Usuarios()
        {
            InitializeComponent();
        }
        
     
        BE.Usuario usuario;
        BLL.Usuario_BLL gestor = new BLL.Usuario_BLL();
        private void Crear_Usuarios_Load(object sender, EventArgs e)
        {
            VerDatos();
        }
        void Agregar_Usuario()
        {
            
            usuario = new BE.Usuario();
            usuario._Idusuario = int.Parse(txtID.Text);
            usuario._Login = txtUsuario.Text;
            usuario._Contraseña = txtContraseña.Text;
            
            try
            {
                gestor.Agregar(usuario);
                MessageBox.Show("Agregado Correctamente...");
                VerDatos();
                txtID.Text = txtUsuario.Text = txtContraseña.Text = "";
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
                Agregar_Usuario();
                MessageBox.Show("usuario agregado");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usuario = new BE.Usuario();
            usuario._Idusuario = int.Parse(txtID.Text);
            usuario._Login = txtUsuario.Text;
            usuario._Contraseña = txtContraseña.Text;
            try
            {
                gestor.Modificar(usuario);
                MessageBox.Show("Modificado correctamente");
                VerDatos();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        void VerDatos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gestor.Listar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                usuario = (BE.Usuario)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                txtID.Text = usuario._Idusuario.ToString();
                txtUsuario.Text = usuario._Login;
                txtContraseña.Text = usuario._Contraseña;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

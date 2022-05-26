using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;
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

       Usuario_DAL Gestor = new Usuario_DAL();
        Usuario Usuario = new Usuario();
        private void Crear_Usuarios_Load(object sender, EventArgs e)
        {
            VerDatos();
        }

        public void Agregar_Usuario()
        {

            Usuario = new BE.Usuario();
            Usuario._Idusuario = int.Parse(txtID.Text);
            Usuario.usuario = txtUsuario.Text;
            Usuario._Contraseña = txtContraseña.Text;
            Usuario._IdRol = txtRol.Text;
            try
            {
                Gestor.Agregar(Usuario);
                MessageBox.Show("Agregado Correctamente...");
                VerDatos();
                txtUsuario.Text = txtContraseña.Text = "";
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
            Usuario = new BE.Usuario();
            Usuario._Idusuario = int.Parse(txtID.Text);
            Usuario.usuario = txtUsuario.Text;
            Usuario._Contraseña = txtContraseña.Text;
            Usuario._IdRol = txtRol.Text;
            try
            {
                Gestor.Modificar(Usuario);
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
            Usuario = new BE.Usuario();
            Usuario._Idusuario = int.Parse(txtID.Text);
            try
            {
                Gestor.Eliminar(Usuario);
                MessageBox.Show("producto eliminado");
                VerDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void VerDatos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Gestor.Listar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Usuario = (Usuario)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                txtID.Text = Usuario._Idusuario.ToString();
                txtUsuario.Text = Usuario.usuario;
                txtContraseña.Text = Usuario._Contraseña;
                txtRol.Text = Usuario._IdRol;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try{ 
            //mdi_master mdi = new mdi_master();
            //mdi.Show();
            }
            catch{
                MessageBox.Show("usuario no encontrado");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

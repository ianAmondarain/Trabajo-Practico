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
        BE.Usuario usuario;
        BLL.Usuario_BLL gestor = new BLL.Usuario_BLL();

        public Crear_Usuarios()
        {
            InitializeComponent();
        }
        
        private void Crear_Usuarios_Load(object sender, EventArgs e)
        {
            VerDatos();
        }

        void Agregar_Usuario()
        {
            
            usuario = new BE.Usuario();
            usuario._Idusuario = int.Parse(txtID.Text);
            usuario.usuario = txtUsuario.Text;
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
            usuario.usuario = txtUsuario.Text;
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
            usuario = new BE.Usuario();
            usuario._Idusuario = int.Parse(txtID.Text);
            try
            {
                gestor.Eliminar(usuario);
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
            dataGridView1.DataSource = gestor.Listar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                usuario = (BE.Usuario)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                txtID.Text = usuario._Idusuario.ToString();
                txtUsuario.Text = usuario.usuario;
                txtContraseña.Text = usuario._Contraseña;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

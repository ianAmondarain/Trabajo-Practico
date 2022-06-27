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
            LlenarComboRol();
        }

        public static string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted =
            System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función "desencripta" la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptar(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted =
            Convert.FromBase64String(_cadenaAdesencriptar);
            //result = 
            System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        protected void Agregar_Usuario()
        {

            Usuario = new BE.Usuario();
     
            Usuario._Idusuario =int.Parse(txtID.Text);
            Usuario.usuario = txtUsuario.Text;
            Usuario._Contraseña = Encriptar(txtContraseña.Text);
            Usuario._IdRol = cmbRol.Text;
            try
            {
                Gestor.Agregar(Usuario);
                MessageBox.Show("Agregado Correctamente...");
                VerDatos();
                txtUsuario.Text = DesEncriptar(txtContraseña.Text = "");
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
            Usuario._Contraseña = DesEncriptar(txtContraseña.Text);
            Usuario._IdRol = cmbRol.Text;
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

        void LlenarComboRol()
        {
            List<BE.Usuario> Cliente = Gestor.Listar();

            for (int i = 0; i < Cliente.Count; i++)
            {
                cmbRol.Items.Add(Cliente[i]._IdRol);
                cmbRol.Items.Add(Cliente[i]._IdRol);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Usuario = (Usuario)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                txtID.Text = Usuario._Idusuario.ToString();
                txtUsuario.Text = Usuario.usuario;
                txtContraseña.Text = DesEncriptar(Usuario._Contraseña);
                cmbRol.Text = Usuario._IdRol;
               
            }
            catch 
            {
                
            }
        }
    }
}

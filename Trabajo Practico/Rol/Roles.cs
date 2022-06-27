using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_Practico.Rol
{
    public partial class Roles : Form
    {
        public Roles()
        {
            InitializeComponent();
        }
            BE.Rol temp;
            BLL.Rol_BLL gestor = new BLL.Rol_BLL();

        private void Roles_Load(object sender, EventArgs e)
        {
            Listar();
        }
        public void Agregar_Proveedor()
        {
                temp = new BE.Rol();
                temp._IDRol = int.Parse(txtID.Text);
                temp._Nombre = txtUsuario.Text;
                try
                {
                    gestor.Agregar(temp);
                    MessageBox.Show("Agregado Correctamente...");
                    Listar();
                    txtID.Text = txtUsuario.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        private void Agregar_Click(object sender, EventArgs e)
        {
            Agregar_Proveedor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temp = new BE.Rol();
            temp._IDRol = int.Parse(txtID.Text);
            temp._Nombre = txtUsuario.Text;
            try
            {
                gestor.Modificar(temp);
                MessageBox.Show("Producto modificado");
                Listar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            temp = new BE.Rol();
            temp._IDRol = int.Parse(txtID.Text);
            try
            {
                gestor.Eliminar(temp);
                MessageBox.Show("producto eliminado");
                Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void Listar()
        {
            dataRol.DataSource = null;
            dataRol.DataSource = gestor.Listar();
        }
    }
}

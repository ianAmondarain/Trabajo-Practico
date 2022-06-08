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
    public partial class Login : Form
    {
        Crear_Usuarios usuario = new Crear_Usuarios();

       
        public Login()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text =="")
            {
                errorProvider1.SetError(textBox1, "Ingrese el usuario");

                return;
            }
            else
            {
                errorProvider1.SetError(textBox1, "Ingrese el usuario");
                if (textBox2.Text == "")
                {
                    errorProvider1.SetError(textBox2, "Ingrese la contraseña");
                    return;
                }
                else
                {
                    errorProvider1.SetError(textBox2, "");
                    if (!DAL.Login_DAL.ExisteUsuario(textBox1.Text, textBox2.Text))
                    {
                        MessageBox.Show("Usuario y contraseña incorrrecto");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox1.Focus();
                        return;
                    }
                    else
                    {
                        Bienvenido_QA bienvenido = new Bienvenido_QA();
                        bienvenido.Show();
                        this.Hide();
                    }
                }
            }
        }

     
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

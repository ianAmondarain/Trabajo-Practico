﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Trabajo_Practico
{
    public partial class panel : Form
    {
        public panel()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BtnMaximizar.Visible = false;
            BtnRestaurar.Visible = true;
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            BtnRestaurar.Visible = false;
            BtnMaximizar.Visible = true;
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            Productos productos = new Productos();
            productos.Show();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg,int wParam, int LParam);

        private void BarraTexto_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012 , 0);
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.Show();
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();
            ventas.Show();
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            Proveedores proveedores = new Proveedores();
            proveedores.Show();
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            Crear_Usuarios usuarios = new Crear_Usuarios();
            usuarios.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Ventas
    {
        private int IDVentas;

        public int _IDVentas
        {
            get { return IDVentas; }
            set { IDVentas = value; }
        }

        private int IDClientes;

        public int _IDClientes
        {
            get { return IDClientes; }
            set { IDClientes = value; }
        }

        private int Cantidad;

        public int _Cantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }

        private float PrecioUnitario;

        public float _PrecioUnitario
        {
            get { return PrecioUnitario; }
            set { PrecioUnitario = value; }
        }
        private string Descripcion;

        public string _Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        private float PrecioVenta;

        public float _PrecioVenta
        {
            get { return PrecioVenta; }
            set { PrecioVenta = value; }
        }

    }
}

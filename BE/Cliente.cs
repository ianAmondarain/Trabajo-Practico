using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cliente
    {
        private int IDCliente;

        public int _IDCLIENTE
        {
            get { return IDCliente; }
            set { IDCliente = value; }
        }

        private string Nombre;

        public string _Nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        private string Apellido;

        public string _Apellido
        {
            get { return Apellido; }
            set { Apellido = value; }
        }
        private int CUIT;

        public int _CUIT
        {
            get { return CUIT; }
            set { CUIT = value; }
        }
        private int Telefono;

        public int _Telefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }



    }
}

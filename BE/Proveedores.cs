using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Proveedores
    {
        private int IdProveedores;

        public int _IdProveedores
        {
            get { return IdProveedores; }
            set { IdProveedores = value; }
        }

        private string NombreProveedor;

        public string _Nombre
        {
            get { return NombreProveedor; }
            set { NombreProveedor = value; }
        }

        private string Trayecto;

        public string _Trayecto
        {
            get { return Trayecto; }
            set { Trayecto = value; }
        }

    }
}

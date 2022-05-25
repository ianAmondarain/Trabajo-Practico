using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
        
        private int Idusuario;

        public int _Idusuario
        {
            get { return Idusuario; }
            set { Idusuario = value; }
        }

        private string Login;

        public string usuario
        {
            get { return Login; }
            set { Login = value; }
        }
        private string Contraseña;

        public string _Contraseña
        {
            get { return Contraseña; }
            set { Contraseña = value; }
        }

        private string IdRol;

        public string _IdRol
        {
            get { return IdRol; }
            set { IdRol = value; }
        }


    }
}

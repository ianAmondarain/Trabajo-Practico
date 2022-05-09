using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Receta
    {
        private string nombrecliente;

        public string _nombrecliente
        {
            get { return nombrecliente; }
            set { nombrecliente = value; }
        }

        private string tipomedico;

        public string _tipomedico
        {
            get { return tipomedico; }
            set { tipomedico = value; }
        }

        private string obrasocial;

        public string _obrasocial
        {
            get { return obrasocial; }
            set { obrasocial = value; }
        }

        private string descripcion;

        public string _descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private int fecha;

        public int _fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }




    }
}

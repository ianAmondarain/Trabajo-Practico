using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Producto
    {
        private int ID;

        public int _ID
        {
            get { return ID; }
            set { ID = value; }
        }
        private string Descripcion;

        public string _Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        private int Stock;

        public int _Stock
        {
            get { return Stock; }
            set { Stock = value; }
        }
        private float Precio_Compra;

        public float _Precio_Compra
        {
            get { return Precio_Compra; }
            set { Precio_Compra = value; }
        }

        private float Precio_Venta;

        public float _Precio_Venta
        {
            get { return Precio_Venta; }
            set { Precio_Venta = value; }
        }
     

        
    }
}

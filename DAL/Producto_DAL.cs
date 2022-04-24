using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Producto_DAL
    {
        Conexion conexiones = new Conexion();

        public string Agregar(BE.Producto P)
        {
            SqlParameter[] Parametro = new SqlParameter[5];

            Parametro[0] = new SqlParameter("@IDProducto", P._ID);
            Parametro[1] = new SqlParameter("@Descripcion", P._Descripcion);
            Parametro[2] = new SqlParameter("@Stock", P._Stock);
            Parametro[3] = new SqlParameter("@PrecioCompra", P._Precio_Compra);
            Parametro[4] = new SqlParameter("@PrecioVenta", P._Precio_Venta);
            return conexiones.Escribir("Ingresar_Productos", Parametro);
        }
        public string Modificar(BE.Producto P)
        {
            SqlParameter[] Parametro = new SqlParameter[5];

            Parametro[0] = new SqlParameter("@IDProducto", P._ID);
            Parametro[1] = new SqlParameter("@Descripcion", P._Descripcion);
            Parametro[2] = new SqlParameter("@Stock", P._Stock);
            Parametro[3] = new SqlParameter("@PrecioCompra", P._Precio_Compra);
            Parametro[4] = new SqlParameter("@PrecioVenta", P._Precio_Venta);
            return conexiones.Escribir("Editar_Producto", Parametro);
        }

        public string Eliminar(BE.Producto P)
        {
            SqlParameter[] Parametro = new SqlParameter[1];

            Parametro[0] = new SqlParameter("@IDProducto", P._ID);

            return conexiones.Escribir("Eliminar_Producto", Parametro);

        }
        public List<BE.Producto> Listar()
        {
            List<BE.Producto> LS = new List<BE.Producto>();
            DataTable Tabla = conexiones.Leer("Mostrar_Productos", null);
            foreach (DataRow Registro in Tabla.Rows)
            {
                BE.Producto pro = new BE.Producto();
                pro._ID = int.Parse(Registro["IDProducto"].ToString());
                pro._Descripcion = Registro["Descripcion"].ToString();
                pro._Stock = int.Parse(Registro["Stock"].ToString());
                pro._Precio_Compra = float.Parse(Registro["PrecioCompra"].ToString());
                pro._Precio_Venta = float.Parse(Registro["Venta"].ToString());
                LS.Add(pro);
            }
            return LS;


        }
    }
}

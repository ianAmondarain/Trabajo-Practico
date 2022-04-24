using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Proveedores_DAL
    {
        Conexion conexiones = new Conexion();

        public string Agregar(BE.Proveedores pro)
        {

            SqlParameter[] parametro = new SqlParameter[3];
            parametro[0] = new SqlParameter("@IDProveedores", pro._IdProveedores);
            parametro[1] = new SqlParameter("@NombreProveedor", pro._Nombre);
            parametro[2] = new SqlParameter("@Trayecto", pro._Trayecto);
            return conexiones.Escribir("Ingresar_Proveedores", parametro);
        }

        public string Modificar(BE.Proveedores pro)
        {
            SqlParameter[] parametro = new SqlParameter[3];
            parametro[0] = new SqlParameter("@IDProveedores", pro._IdProveedores);
            parametro[1] = new SqlParameter("@NombreProveedor", pro._Nombre);
            parametro[2] = new SqlParameter("@Trayecto", pro._Trayecto);
            return conexiones.Escribir("Editar_Proveedores", parametro);
        }
        public List<BE.Proveedores> Listar()
        {
            List<BE.Proveedores> ls = new List<BE.Proveedores>();
            DataTable tabla = conexiones.Leer("Mostrar_Proveedores", null);
            foreach (DataRow Registro in tabla.Rows)
            {
                BE.Proveedores pro = new BE.Proveedores();
                pro._IdProveedores = int.Parse(Registro["IDProveedores"].ToString());
                pro._Nombre = Registro["NombreProveedor"].ToString();
                pro._Trayecto = Registro["Trayecto"].ToString();
                ls.Add(pro);
            }
            return ls;
        }
    }
}

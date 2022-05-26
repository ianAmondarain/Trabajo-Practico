using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class Rol_DAL
    {
        Conexion conexiones = new Conexion();

        public string Agregar(Rol rol)
        {

            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@IdRol", rol._IDRol);
            parametro[1] = new SqlParameter("@Nombre", rol._Nombre);
            return conexiones.Escribir("Ingresar_Rol", parametro);
        }

        public string Modificar(Rol rol)
        {
            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@IdRol", rol._IDRol);
            parametro[1] = new SqlParameter("@Nombre", rol._Nombre);
            return conexiones.Escribir("Editar_Rol", parametro);
        }

        public string Eliminar(Rol rol)
        {
            SqlParameter[] Parametro = new SqlParameter[1];

            Parametro[0] = new SqlParameter("@Idusuario", rol._IDRol);

            return conexiones.Escribir("Eliminar_Rol", Parametro);
        }

        public List<Rol> Listar()
        {
            List<Rol> ls = new List<Rol>();
            DataTable tabla = conexiones.Leer("Mostrar_Rol", null);
            foreach (DataRow Registro in tabla.Rows)
            {
                Rol rol = new Rol();
                rol._IDRol = int.Parse(Registro["IdRol"].ToString());
                rol._Nombre = Registro["Nombre"].ToString();
                ls.Add(rol);
            }
            return ls;
        }
    }
}

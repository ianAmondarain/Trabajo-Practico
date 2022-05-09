using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Usuario_DAL
    {
        
        Conexion conexiones = new Conexion();

        public string Agregar(BE.Usuario usu)
        {

            SqlParameter[] parametro = new SqlParameter[3];
            parametro[0] = new SqlParameter("@ID", usu._Idusuario);
            parametro[1] = new SqlParameter("@Usuario", usu.usuario);
            parametro[2] = new SqlParameter("@Contraseña", usu._Contraseña);
            return conexiones.Escribir("Ingresar_Usuarios", parametro);
        }

        public string Modificar(BE.Usuario usu)
        {
            SqlParameter[] parametro = new SqlParameter[3];
            parametro[0] = new SqlParameter("@ID", usu._Idusuario);
            parametro[1] = new SqlParameter("@Usuario", usu.usuario);
            parametro[2] = new SqlParameter("@Contraseña", usu._Contraseña);
            return conexiones.Escribir("Editar_Usuarios", parametro);
        }

        public string Eliminar(BE.Usuario usu)
        {
            SqlParameter[] Parametro = new SqlParameter[1];

            Parametro[0] = new SqlParameter("@Idusuario", usu._Idusuario);

            return conexiones.Escribir("Eliminar_Usuario", Parametro);
        }

        public List<BE.Usuario> Listar()
        {
            List<BE.Usuario> ls = new List<BE.Usuario>();
            DataTable tabla = conexiones.Leer("Mostrar_Usuario", null);
            foreach (DataRow Registro in tabla.Rows)
            {
                BE.Usuario usu = new BE.Usuario();
                usu._Idusuario = int.Parse(Registro["ID"].ToString());
                usu.usuario = Registro["Usuario"].ToString();
                usu._Contraseña = Registro["Contraseña"].ToString();
                ls.Add(usu);
            }
            return ls;
        }
    }
}
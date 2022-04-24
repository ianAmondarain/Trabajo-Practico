using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Cliente_DAL
    {
        Conexion conexiones = new Conexion();

        public string Agregar(BE.Cliente C)
        {
            SqlParameter[] Parametro = new SqlParameter[5];

            Parametro[0] = new SqlParameter("@IDCliente", C._IDCLIENTE);
            Parametro[1] = new SqlParameter("@Nombre", C._Nombre);
            Parametro[2] = new SqlParameter("@Apellido", C._Apellido);
            Parametro[3] = new SqlParameter("@Cuit", C._CUIT);
            Parametro[4] = new SqlParameter("@Telefono", C._Telefono);
            return conexiones.Escribir("Ingresar_Clientes", Parametro);
        }
        public string Modificar(BE.Cliente C)
        {
            SqlParameter[] Parametro = new SqlParameter[5];

            Parametro[0] = new SqlParameter("@IDCliente", C._IDCLIENTE);
            Parametro[1] = new SqlParameter("@Nombre", C._Nombre);
            Parametro[2] = new SqlParameter("@Apellido", C._Apellido);
            Parametro[3] = new SqlParameter("@Cuit", C._CUIT);
            Parametro[4] = new SqlParameter("@Telefono", C._Telefono);
            return conexiones.Escribir("Editar_Cliente", Parametro);
        }

        public string Eliminar(BE.Cliente c)
        {
            SqlParameter[] Parametro = new SqlParameter[1];

            Parametro[0] = new SqlParameter("@IDCliente", c._IDCLIENTE);

            return conexiones.Escribir("Eliminar_Cliente", Parametro);

        }
        public List<BE.Cliente> Listar()
        {
            List<BE.Cliente> LS = new List<BE.Cliente>();
            DataTable Tabla = conexiones.Leer("Mostrar_Clientes", null);
            foreach (DataRow Registro in Tabla.Rows)
            {
                BE.Cliente Cliente = new BE.Cliente();
                Cliente._IDCLIENTE = int.Parse(Registro["IDCliente"].ToString());
                Cliente._Nombre = Registro["Nombre"].ToString();
                Cliente._Apellido = Registro["Apellido"].ToString();
                Cliente._CUIT = int.Parse(Registro["Cuit"].ToString());
                Cliente._Telefono = int.Parse(Registro["Telefono"].ToString());
                LS.Add(Cliente);
            }
            return LS;


        }

            
 }
}

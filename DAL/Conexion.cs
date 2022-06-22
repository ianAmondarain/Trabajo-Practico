using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Conexion
    {
        private static object _lock = new Object();
        private static SqlConnection conexion;
        //SqlConnection Conexiones = new SqlConnection();

        public static SqlConnection GetInstance
        {
            get
            {
                if (conexion == null) throw new Exception("Conexion establecida");

                return conexion;
            }
        } 

        public static SqlConnection Abrir()
        {
            lock(_lock)
            {
                if (conexion == null)
                {
                    conexion = new SqlConnection();
                    conexion.ConnectionString = @"Data Source=DESKTOP-63938MP\IAN;Initial Catalog=TPFinal;Integrated Security=True";
                    conexion.Open();
                    return conexion;
                }
                else
                {
                    throw new Exception("conexion ya establecida correctamente");
                }
            }
        }

        public static void Cerrar()
        {
            lock (_lock) { }
            if (conexion != null)
            {
                conexion.Close();
                conexion = null;
            }
            else
            {
                throw new Exception("conexion no establecida");
            }
        }
        

        SqlTransaction TR;

        void IniciarTR()
        {
            TR = conexion.BeginTransaction();
        }
        void ConfirmarTR()
        {
            TR.Commit();
        }
        void CancelarTR()
        {
            TR.Rollback();
        }

        public string Escribir(string st, SqlParameter[] Parametro)
        {

            Abrir();
            IniciarTR();
            SqlCommand CMD = new SqlCommand();
            CMD.Connection = conexion;
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.CommandText = st;
            CMD.Parameters.AddRange(Parametro);
            try
            {
                CMD.Transaction = TR;
                CMD.ExecuteNonQuery();
                ConfirmarTR();
            }
            catch
            {
                CancelarTR();
            }
            Cerrar();
            return "";
        }

        public DataTable Leer(string st, SqlParameter[] Parametro)
        {
            Abrir();
            DataTable Tabla = new DataTable();
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            Adaptador.SelectCommand = new SqlCommand();
            Adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
            Adaptador.SelectCommand.CommandText = st;
            if (Parametro != null)
            {
                Adaptador.SelectCommand.Parameters.AddRange(Parametro);
            }
            Adaptador.SelectCommand.Connection = conexion;
            Adaptador.Fill(Tabla);
            Cerrar();
            return Tabla;
        }
      
    }
}

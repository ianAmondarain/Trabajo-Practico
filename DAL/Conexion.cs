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
        SqlConnection Conexiones = new SqlConnection();

        void Abrir()
        {
            try
            {
                Conexiones.ConnectionString = @"Data Source=.;Initial Catalog=TPFinal;Integrated Security=True";
                Conexiones.Open();
            }
            catch(Exception)
            {

            }
        }
        
        void Cerrar()
        {
            Conexiones.Close();
        }

        SqlTransaction TR;

        void IniciarTR()
        {
            TR = Conexiones.BeginTransaction();
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
            CMD.Connection = Conexiones;
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
            Adaptador.SelectCommand.Connection = Conexiones;
            Adaptador.Fill(Tabla);
            Cerrar();
            return Tabla;
        }
      
    }
}

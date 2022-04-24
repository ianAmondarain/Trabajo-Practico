using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Ventas_DAL
    {
        Conexion conexiones = new Conexion();

        public string Agregar(BE.Ventas V)
        {
            SqlParameter[] Parametro = new SqlParameter[6];

            Parametro[0] = new SqlParameter("@IDVentas", V._IDVentas);
            Parametro[1] = new SqlParameter("@IDClientes", V._IDClientes);
            Parametro[2] = new SqlParameter("@Descripcion", V._Descripcion);
            Parametro[3] = new SqlParameter("@Cantidad", V._Cantidad);
            Parametro[4] = new SqlParameter("@PrecioCompra", V._PrecioUnitario);
            Parametro[5] = new SqlParameter("@Venta", V._PrecioVenta);
            return conexiones.Escribir("Ingresar_Ventas", Parametro);
        }
        public string  Modificar(BE.Ventas V)
        {
            SqlParameter[] Parametro = new SqlParameter[6];

            Parametro[0] = new SqlParameter("@IDVentas", V._IDVentas);
            Parametro[1] = new SqlParameter("@IDClientes", V._IDClientes);
            Parametro[2] = new SqlParameter("@Descripcion", V._Descripcion);
            Parametro[3] = new SqlParameter("@Cantidad", V._Cantidad);
            Parametro[4] = new SqlParameter("@PrecioCompra", V._PrecioUnitario);
            Parametro[5] = new SqlParameter("@Venta", V._PrecioVenta);
            return conexiones.Escribir("Editar_Ventas", Parametro);
        }

        public string Eliminar(BE.Ventas v)
        {
            SqlParameter[] Parametro = new SqlParameter[1];

            Parametro[0] = new SqlParameter("@IDVentas", v._IDVentas);

            return conexiones.Escribir("Eliminar_Venta", Parametro);

        }
        public List<BE.Ventas> Listar()
        {
            List<BE.Ventas> LS = new List<BE.Ventas>();
            DataTable Tabla = conexiones.Leer("Mostrar_Ventas", null);
            foreach (DataRow Registro in Tabla.Rows)
            {
                BE.Ventas ven = new BE.Ventas();
                ven._IDVentas = int.Parse(Registro["IDVentas"].ToString());
                ven._IDClientes = int.Parse(Registro["IDClientes"].ToString());
                ven._Descripcion = Registro["Descripcion"].ToString();
                ven._Cantidad = int.Parse(Registro["Cantidad"].ToString());
                ven._PrecioUnitario = int.Parse(Registro["PrecioCompra"].ToString());
                ven._PrecioVenta = int.Parse(Registro["Venta"].ToString());
                LS.Add(ven);
            }
            return LS;
        }
        public List<BE.Ventas> ListarxIDCliente(int ID)
        {
            List<BE.Ventas> LS = new List<BE.Ventas>();
            SqlParameter[] Parametro = new SqlParameter[1];
            Parametro[0] = new SqlParameter("@ID", ID);
            DataTable Tabla = conexiones.Leer("ListarxIDCliente", Parametro);
            foreach (DataRow Registro in Tabla.Rows)
            {
                BE.Ventas Ventas = new BE.Ventas();
                Ventas._IDVentas = int.Parse(Registro["IDVentas"].ToString());
                Ventas._IDClientes = int.Parse(Registro["IDClientes"].ToString());
                Ventas._Descripcion = Registro["Descripcion"].ToString();
                Ventas._Cantidad = int.Parse(Registro["Cantidad"].ToString());
                Ventas._PrecioUnitario = int.Parse(Registro["PrecioCompra"].ToString());
                Ventas._PrecioVenta = int.Parse(Registro["Venta"].ToString());
                LS.Add(Ventas);
            }
            return LS;
        }
        public float Sumar_Total()
        {
           
            List<BE.Ventas> LS = new List<BE.Ventas>();
            float Total = 0;
            DataTable Tabla = conexiones.Leer("Mostrar_Ventas", null);
            foreach (DataRow Registro in Tabla.Rows)
            {
                BE.Ventas ven = new BE.Ventas();
        ven._IDVentas = int.Parse(Registro["IDVentas"].ToString());
                ven._IDClientes = int.Parse(Registro["IDClientes"].ToString());
                ven._Descripcion = Registro["Descripcion"].ToString();
        ven._Cantidad = int.Parse(Registro["Cantidad"].ToString());
                ven._PrecioUnitario = int.Parse(Registro["PrecioCompra"].ToString());
                ven._PrecioVenta = int.Parse(Registro["Venta"].ToString());
                LS.Add(ven);
            }  
            for(int i = 0; i < LS.Count; i++)
            {
                Total += LS[i]._Cantidad * LS[i]._PrecioVenta;
            }
            return Total;
  } 
 }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Ventas_BLL
    {
        DAL.Ventas_DAL mapper = new DAL.Ventas_DAL();

        public string Agregar(BE.Ventas VL)
        {
            return mapper.Agregar(VL);
        }

        public string Modificar(BE.Ventas VL)
        {
            return mapper.Modificar(VL);
        }
        public string Eliminar(BE.Ventas VL)
        {
            return mapper.Eliminar(VL);
        }

        public List<BE.Ventas> Listar()
        {
            List<BE.Ventas> ventas = mapper.Listar();
            return ventas;
        }
        public List<BE.Ventas> ListarID(int ID)
        {
            List<BE.Ventas> ventas = mapper.ListarxIDCliente(ID);
            return ventas;
        }

        public float TotalVentas()
        {
            return mapper.Sumar_Total();
        }
    }
}

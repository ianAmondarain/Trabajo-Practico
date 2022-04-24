using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Producto_BLL
    {
        DAL.Producto_DAL mapper = new DAL.Producto_DAL();

        public string Agregar(BE.Producto PL)
        {
            return mapper.Agregar(PL);
        }

        public string Modificar(BE.Producto PL)
        {
            return mapper.Modificar(PL);
        }
        public string Eliminar(BE.Producto PL)
        {
            return mapper.Eliminar(PL);
        }
        public List<BE.Producto> Listar()
        {
            List<BE.Producto> PRODUCTOS = mapper.Listar();
            return PRODUCTOS;
        }

    }
}

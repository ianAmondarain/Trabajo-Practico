using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Proveedores_BLL
    {
        DAL.Proveedores_DAL mapper = new DAL.Proveedores_DAL();

        public string Agregar(BE.Proveedores PR)
        {
            return mapper.Agregar(PR);
        }

        public string Modificar(BE.Proveedores PR)
        {
            return mapper.Modificar(PR);
        }
    
        public List<BE.Proveedores> Listar()
        {
            List<BE.Proveedores> proveedores = mapper.Listar();
            return proveedores;
        }

    }
}

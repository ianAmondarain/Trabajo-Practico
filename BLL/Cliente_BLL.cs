using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Cliente_BLL
    {
        DAL.Cliente_DAL mapper = new DAL.Cliente_DAL();

        public string Agregar(BE.Cliente CL)
        {
            return mapper.Agregar(CL);
        }

        public string Modificar(BE.Cliente CL)
        {
            return mapper.Modificar(CL);
        }
        public string Eliminar(BE.Cliente CL)
        {
            return mapper.Eliminar(CL);
        }
        public List<BE.Cliente> Listar()
        {
            List<BE.Cliente> clientes = mapper.Listar();
            return clientes;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Usuario_BLL
    {
        DAL.Usuario_DAL mapper = new DAL.Usuario_DAL();
        

        public string Agregar(BE.Usuario US)
        {
            return mapper.Agregar(US);
        }

        public string Modificar(BE.Usuario US)
        {
            return mapper.Modificar(US);
        }

        public string Eliminar(BE.Usuario US)
        {
            return mapper.Eliminar(US);
        }


        public List<BE.Usuario> Listar()
        {
            List<BE.Usuario> Usuario = mapper.Listar();
            return Usuario;
        }
    }
}

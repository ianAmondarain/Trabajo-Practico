using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Rol_BLL
    {
        Rol_DAL mapper = new Rol_DAL();

        public string Agregar(BE.Rol RL)
        {
            return mapper.Agregar(RL);
        }

        public string Modificar(BE.Rol RL)
        {
            return mapper.Modificar(RL);
        }
        public string Eliminar(BE.Rol RL)
        {
            return mapper.Eliminar(RL);
        }
        public List<BE.Rol> Listar()
        {
            List<BE.Rol> Rol = mapper.Listar();
            return Rol;
        }
    }
}

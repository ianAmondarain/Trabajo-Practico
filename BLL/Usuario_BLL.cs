using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public static class Usuario_BLL
    {
        static Usuario_DAL mapper = new Usuario_DAL();


        public static string Agregar(Usuario US)
        {
            return mapper.Agregar(US);
        }

        public static string Modificar(Usuario US)
        {
            return mapper.Modificar(US);
        }

        public static string Eliminar(Usuario US)
        {
            return mapper.Eliminar(US);
        }

        public static bool Login(string login, string Contraseña)
        {
            return mapper.Login(login, Contraseña);
        }

        public static List<Usuario> Listar()
        {
            return mapper.Listar();

        }

       
    }
}


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
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(US._Contraseña));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            string passHash = builder.ToString();
            US._Contraseña = passHash;
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
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Contraseña));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            string passHash = builder.ToString();

            if (mapper.Login(login, passHash))
            {
                Usuario usuario = new Usuario();
                usuario._Contraseña = passHash;
                SessionManager.login(usuario);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Usuario> Listar()
        {
            return mapper.Listar();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSet1TableAdapters;


namespace DAL
{
    public class Login_DAL
    {
        

        Usuario_DAL usuario = new Usuario_DAL();
        private static UsuarioTableAdapter adaptador = new UsuarioTableAdapter();
        
        public static bool ExisteUsuario( string Usuario,string Contraseña)
        {
            
            if
            (adaptador.ExisteUsuario(Usuario, Contraseña)  == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}

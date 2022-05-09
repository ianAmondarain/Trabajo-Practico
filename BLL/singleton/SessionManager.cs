using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class SessionManager
    {
        public static object _lock = new object();
        private static SessionManager _Session;
        public Usuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }


        public static SessionManager GetInstance
        {
            get
            {
                if (_Session == null) throw new Exception("no iniciada");
                return _Session;
            }
        }

        public static void login(Usuario usuario)
        {
            lock (_lock)
            {
                if (_Session == null)
                {
                    _Session = new SessionManager();
                    _Session.Usuario = usuario;
                    _Session.FechaInicio = DateTime.Now;
                }
                else
                {
                    throw new Exception("sesion iniciada");
                }
            }


        }
        public static void logout()
        {
            lock (_lock)
            {
                if (_Session != null)
                {
                    _Session = null;
                }
                else
                {
                    throw new Exception("hubo un problema con la session");
                }
            }
        }
        private SessionManager()
        {

        }
    }
}

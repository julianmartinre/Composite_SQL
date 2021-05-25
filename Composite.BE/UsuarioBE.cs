using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.BE
{
    public class UsuarioBE
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        private List<PermisoBaseBE> _listaPermisos;

        public List<PermisoBaseBE> ListaPermisos
        {
            get { return _listaPermisos; }
            set { _listaPermisos = value; }
        }

        public UsuarioBE()
        {
            _listaPermisos = new List<PermisoBaseBE>();
        }

    }
}

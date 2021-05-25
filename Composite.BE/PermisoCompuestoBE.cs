using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.BE
{
    public class PermisoCompuestoBE : PermisoBaseBE
    {
        private List<PermisoBaseBE> _listaPermisos;

        public List<PermisoBaseBE> ListaPermisos
        {
            get { return _listaPermisos; }
            set { _listaPermisos = value; }
        }

        public void AgregarPermiso(PermisoBaseBE p)
        {
            if (!this.ListaPermisos.Contains(p))
                ListaPermisos.Add(p);
        }

        public void QuitarPermiso(PermisoBaseBE p)
        {
            if (this.ListaPermisos.Contains(p))
                ListaPermisos.Add(p);
        }

        public PermisoCompuestoBE()
        {
            _listaPermisos = new List<PermisoBaseBE>();
        }

    }
}

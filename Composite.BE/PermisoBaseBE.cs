using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.BE
{
    public abstract class PermisoBaseBE : Entity
    {
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private bool _es_patente;

        public bool Es_patente
        {
            get { return _es_patente; }
            set { _es_patente = value; }
        }

        public PermisoBaseBE()
        {

        }
    }
}

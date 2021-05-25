using Composite.BE;
using Composite.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.BLL
{
    public class PermisoBLL
    {
        public List<PermisoBaseBE> cargarPermisosUsuario(string username)
        {
            try
            {
                PermisoDAL pDAL = new PermisoDAL();
                return pDAL.cargarPermisosUsuario(username);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }
    }
}

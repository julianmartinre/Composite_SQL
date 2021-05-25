using Composite.BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Composite.DAL
{
    public class PermisoDAL
    {
        string cs = @"Data Source=DESKTOP-A33HBAH\SQLEXPRESS19;Initial Catalog=Composite;Integrated Security=True";
        public List<PermisoBaseBE> cargarPermisosUsuario(string username)
        {
            SqlConnection connection = new SqlConnection(cs);
            List<PermisoBaseBE> listaDePermisos = new List<PermisoBaseBE>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Parameters.AddWithValue("username", username);
                command.CommandText = "select Permiso_Usuario.idPermiso, Permiso.descripcion, Permiso.es_patente from Permiso_Usuario, Permiso where Permiso_Usuario.username = @username and Permiso.id = Permiso_Usuario.idPermiso";
                command.CommandType = System.Data.CommandType.Text;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToBoolean(reader["es_patente"].ToString()) == true)
                    {
                        PermisoCompuestoBE pc = new PermisoCompuestoBE();
                        pc.Id = Convert.ToInt32(reader["idPermiso"]);
                        pc.Descripcion = reader["descripcion"].ToString();
                        pc.Es_patente = Convert.ToBoolean(reader["es_patente"].ToString());
                        pc.ListaPermisos = obtenerHijos(pc.Id);
                        listaDePermisos.Add(pc);
                    }
                    else
                    {
                        PermisoSimpleBE ps = new PermisoSimpleBE();
                        ps.Id = Convert.ToInt32(reader["idPermiso"]);
                        ps.Descripcion = reader["descripcion"].ToString();
                        ps.Es_patente = Convert.ToBoolean(reader["es_patente"].ToString());
                        listaDePermisos.Add(ps);
                    }
                }
                reader.Close();
                return listaDePermisos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PermisoBaseBE> obtenerHijos(int idPermiso)
        {
            SqlConnection connection = new SqlConnection(cs);
            List<PermisoBaseBE> listaDePermisos = new List<PermisoBaseBE>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Parameters.AddWithValue("idPermiso", idPermiso);
                command.CommandText = "select Permiso_Permiso.id_permiso_hijo, Permiso.descripcion, Permiso.es_patente from Permiso_Permiso, Permiso where Permiso_Permiso.id_permiso_padre = @idPermiso and Permiso_Permiso.id_permiso_hijo = Permiso.id";
                command.CommandType = System.Data.CommandType.Text;
                var reader1 = command.ExecuteReader();
                while (reader1.Read())
                {
                    if (Convert.ToBoolean(reader1["es_patente"].ToString()) == true)
                    {
                        PermisoCompuestoBE pc = new PermisoCompuestoBE();
                        pc. Id = Convert.ToInt32(reader1["id_permiso_hijo"]);
                        pc.Descripcion = reader1["descripcion"].ToString();
                        pc.Es_patente = Convert.ToBoolean(reader1["es_patente"].ToString());
                        pc.ListaPermisos = obtenerHijos(pc.Id);
                        listaDePermisos.Add(pc);
                    }
                    else
                    {
                        PermisoSimpleBE ps = new PermisoSimpleBE();
                        ps.Id = Convert.ToInt32(reader1["id_permiso_hijo"].ToString());
                        ps.Descripcion = reader1["descripcion"].ToString();
                        ps.Es_patente = Convert.ToBoolean(reader1["es_patente"].ToString());
                        listaDePermisos.Add(ps);
                    }
                }
                reader1.Close();
                return listaDePermisos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

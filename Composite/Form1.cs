using Composite.BE;
using Composite.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Composite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UsuarioBE user = new UsuarioBE() { Username = "test" };

            PermisoBLL pBLL = new PermisoBLL();
            
            user.ListaPermisos = pBLL.cargarPermisosUsuario("test");

            TreeNode nodoRaiz = new TreeNode() { Name = "Raiz", Text = "Raiz" };

            foreach (var item in user.ListaPermisos)
            {
                if (item.Es_patente)
                {
                    TreeNode result = new TreeNode();
                    result = buscarHijos((PermisoCompuestoBE)item);
                    listaNodos.Add(result);
                }
                else
                {
                    TreeNode result = new TreeNode();
                    result.Name = item.Descripcion;
                    result.Text = item.Descripcion;
                    listaNodos.Add(result);
                }
            }

            foreach (var item in listaNodos)
            {
                nodoRaiz.Nodes.Add(item);
            }

            treePermisos.Nodes.Add(nodoRaiz);
        }

        List<TreeNode> listaNodos = new List<TreeNode>();

        public TreeNode buscarHijos(PermisoCompuestoBE p)
        {
            try
            {
                TreeNode familia = new TreeNode() { Name = p.Descripcion, Text = p.Descripcion };

                foreach (var item in p.ListaPermisos)
                {
                    TreeNode hijo = new TreeNode();
                    if (item.Es_patente)
                    {
                        hijo.Name = item.Descripcion;
                        hijo.Text = item.Descripcion;
                        familia.Nodes.Add(buscarHijos((PermisoCompuestoBE)item));
                    }
                    else
                    {
                        hijo.Name = item.Descripcion;
                        hijo.Text = item.Descripcion;
                        familia.Nodes.Add(hijo);
                    }
                }

                return familia;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }
    }
}

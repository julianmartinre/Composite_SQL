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
        }
    }
}

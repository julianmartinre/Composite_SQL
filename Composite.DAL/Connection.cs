using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.DAL
{
    public abstract class Connection
    {
        private static string cs = @"Data Source=DESKTOP-A33HBAH\SQLEXPRESS19;Initial Catalog=Composite;Integrated Security=True";

        public string ConnectionString()
        {
            return cs;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Database
    {

        public static SqlConnection GetConnection()
        {
            string connect = "Data Source=DESKTOP-ES2IR65\\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
            return new SqlConnection(connect);
        }
    }
}

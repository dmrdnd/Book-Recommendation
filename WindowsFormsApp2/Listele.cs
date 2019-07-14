using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Listele
    {

        public string conString = "Data Source=DESKTOP-ES2IR65\\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";

        

        public DataTable DbListele(string sorgu)
        {
            SqlConnection con = new SqlConnection(conString);
            // SqlConnection con = new SqlConnection(conString);
            con.Open();
           
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand komut = new SqlCommand(sorgu, con);
                SqlDataReader veriyukle = komut.ExecuteReader();
                DataTable tablo = new DataTable();
                tablo.Load(veriyukle);
               
              //  dataGridView1.DataSource = tablo;            
          
            return tablo;
        }
        public void DbSil(string sorgu)
        {
            SqlConnection con = new SqlConnection(conString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            
            SqlCommand komut = new SqlCommand(sorgu, con);
            
            komut.ExecuteNonQuery();
            con.Close();

        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=DESKTOP-ES2IR65\\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
        public static List<String> ortoy = new List<string>();

        public static int issayi ;
        Dictionary<double, double> ortalamalar = new Dictionary<double, double>();
        Dictionary<double, double> ort = new Dictionary<double, double>();
        Dictionary<double, int> rating = new Dictionary<double, int>();
        KitapArşiv kitap;
        KitapOku pdf;
        ArrayList isbn = new ArrayList();       
        ArrayList ratingisbn = new ArrayList();
        ArrayList enyeni = new ArrayList();
        ArrayList oisbn = new ArrayList();
        public ArrayList sisbn = new ArrayList();
        string path = "C:\\Users\\Döndü Demir\\Desktop\\kitap.pdf";
        //double[] isbn;
        private void MainPage_Load(object sender, EventArgs e)
        {

            Eniyiler();
            Populer();
            EnYeniler();
            
        }  
        public void Toplam (int i )
        {
            SqlConnection con = new SqlConnection(conString);
            if (con.State == ConnectionState.Closed)
                con.Open();
           
            SqlCommand komut2 = new SqlCommand("SELECT AVG(BookRating) FROM BookRatings where ISBN='" + isbn[i] + "'", con);
            SqlDataReader rating = komut2.ExecuteReader();
            while (rating.Read())
            {
                if (rating.GetValue(0) != DBNull.Value)
                {

                    ortalamalar.Add(Convert.ToDouble(isbn[i]), Convert.ToDouble(rating.GetValue(0)));
                }                             
            }
                   
            con.Close();
           // return toplam;           
        }  
      

        private void KitapGetir(double isbn, ListView list)
        {
           // DataTable[] tablo = new DataTable[10];
            SqlConnection con = new SqlConnection(conString);
            //con.Open();
          
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                //MessageBox.Show(list.ToString());
                //MessageBox.Show("sisbn içindekiler: " + isbn);

                SqlCommand komut = new SqlCommand("SELECT [ISBN],[BookTitle],[BookAuthor],[YearOfPublication],[Publisher] ,[ImageURLM] FROM Books where ISBN='"+isbn+"'", con);
                SqlDataReader veriyukle = komut.ExecuteReader();
                string isb;
                string title;
                string aut;
                string year;
                string publs;
                string img;
                list.MultiSelect=true;
                while (veriyukle.Read())
                {
                    isb = veriyukle.GetValue(0).ToString();
                    title = veriyukle.GetValue(1).ToString();
                    aut= veriyukle.GetValue(2).ToString();
                    year= veriyukle.GetValue(3).ToString();
                    publs= veriyukle.GetValue(4).ToString();
                    img = veriyukle.GetValue(5).ToString();
                    string[] bilgiler = { isb, title,aut,year,publs,img };
                    // listView1.Columns.
                    list.Items.Add(new ListViewItem(bilgiler));
                }
             //   textBox1.Text = "refffff";
                veriyukle.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu: " + hata.Message);
            }                  

            con.Close();
        }
      

        private void Eniyiler()
        {
            BookIsbns();
            for (int i = 0; i < isbn.Count/8 ; i++)
            {
                Toplam(i);             
            }
                    
            double maxvalue=0;
            double maxvalueofkey=0;

            for (int i = 0; i < 10; i++)
            {
                 maxvalue=ortalamalar.Values.Max();
                 maxvalueofkey = ortalamalar.Aggregate((x, y) => x.Value > y.Value ?x: y).Key;
               // var ortlm = EnBuyukOrt(enbuyuk);

                ort.Add(maxvalueofkey, maxvalue);
                ortalamalar.Remove(maxvalueofkey);            
                
            }
          /*  foreach (KeyValuePair<double, double> ortl in ort)
            {
                listBox3.Items.Add(ortl.Key);
                listBox3.Items.Add(ortl.Value);
            }
            */
          
            foreach (KeyValuePair<double, double> ortl in ort)
            {
               // KitapGetir(ortl.Key,listView1);
                KitapGetir(ortl.Key,listView1);
            }         

        }
        private void BookIsbns()
        {
            SqlConnection con = new SqlConnection(conString);

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand komut = new SqlCommand("SELECT [ISBN] FROM Books", con);
            SqlDataReader veriyukle = komut.ExecuteReader();
           // int sayac = 0;

            while (veriyukle.Read())
            {
               isbn.Add(Convert.ToDouble(veriyukle.GetValue(0)));
                // listBox1.Items.Add(veriyukle.GetValue(0));
               // sayac++;
            }
         

            veriyukle.Close();
            con.Close();
        }
        private void RatingIsbns()
        {
            SqlConnection con = new SqlConnection(conString);

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand komut = new SqlCommand("select top 10 * from (select ISBN, COUNT(*) as sayi from dbo.BookRatings group by ISBN) tbl where sayi > 1 order by sayi desc ", con);
            SqlDataReader veriyukle = komut.ExecuteReader();
           

            while (veriyukle.Read())
            {
               ratingisbn.Add(Convert.ToDouble(veriyukle.GetValue(0)));
                           
            }
         
            veriyukle.Close();
            con.Close();
        }
        private void YenilerIsbn()
        {
            SqlConnection con = new SqlConnection(conString);

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand komut = new SqlCommand("select top 5 *from dbo.Books  order by YearOfPublication desc ", con);
            SqlDataReader veriyukle = komut.ExecuteReader();


            while (veriyukle.Read())
            {
                //  KitapGetir(Convert.ToDouble(veriyukle.GetValue(0)), listView3);
                enyeni.Add(Convert.ToDouble(veriyukle.GetValue(0)));
                // listBox1.Items.Add(veriyukle.GetValue(0));              
            }
     
            veriyukle.Close();
            con.Close();
        }

        private void Populer()
        {         
            RatingIsbns();
          
            foreach (double rat in ratingisbn)
            {
                KitapGetir(rat,listView2);
            }            

        }
        private void EnYeniler()
        {
            YenilerIsbn();
            foreach (double yeni in enyeni)
            {
                //MessageBox.Show(yeni.ToString());
                KitapGetir(yeni, listView3);
            }
        }
         
       
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

            pdf = new KitapOku();
          
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem item = listView2.SelectedItems[0];
                pictureBox2.ImageLocation = item.SubItems[5].Text;
                pdf.Kitapoku(path);
                pdf.Show();
            }
           
         
        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            UserEnter userenter = new UserEnter();
            this.Hide();
            userenter.Show();
            
          //  axAcroPDF1.LoadFile("C:\\Users\\Döndü Demir\\Desktop\\kitap.pdf");
        }

     
        private void button2_Click(object sender, EventArgs e)
        {
            string name = UserEnter.name;
            if (name == null)
            {
                name = UserSave.name;
            }
            else if (name == null)
            {
                name = ManagerEnter.ad;
            }
            Oneriler1(name);
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pdf = new KitapOku();
          
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                pictureBox1.ImageLocation = item.SubItems[5].Text;
                pdf.Kitapoku(path);
                pdf.Show();
            }
           
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            pdf = new KitapOku();
          
            if (listView3.SelectedItems.Count > 0)
            {
                ListViewItem item = listView3.SelectedItems[0];
                pictureBox3.ImageLocation = item.SubItems[5].Text;
                pdf.Kitapoku(path);
                pdf.Show();
            }
           
        }
       
        
       

                  
        private void GOneriler1()
        {

                var connection = Database.GetConnection();
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

            foreach (double isb in oisbn)
            {
              //  MessageBox.Show("gisbn sayısı " + isb1);
                SqlCommand cmd = new SqlCommand("select top 10 ISBN from dbo.BookRatings where UsId in( select UsId from dbo.BookRatings where ISBN='" + isb + "' ) order by BookRating desc", connection);
                SqlDataReader veriyukle1 = cmd.ExecuteReader();


                while (veriyukle1.Read())
                {
                    sisbn.Add(veriyukle1.GetValue(0));
                }
                veriyukle1.Close();
            }
            foreach (double isb in sisbn)
            {
                // KitapGetir(ortl.Key,listView1);
                KitapGetir(isb, listView4);
            }

            // veriyukle1.Close();
           // MessageBox.Show("gisbn sayısı " + sisbn.Count.ToString());
            //textBox1.Text = "regrgergteeg";

            connection.Close();                         
        }

        private void Oneriler1(string username)
        {
            //MessageBox.Show("isim ve id kontrolu");
            var connection = Database.GetConnection();
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            String id = "";


            SqlCommand cmd = new SqlCommand("SELECT*FROM Users WHERE UsName='" + username + "'", connection);


            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    id = dr.GetValue(2).ToString();
                }

            }

            cmd.Dispose();
            SqlCommand cmd1 = new SqlCommand("select ISBN from BookRatings where UsId='" + id + "'", connection);
            SqlDataReader veriyukle = cmd1.ExecuteReader();

            while (veriyukle.Read())
            {
                oisbn.Add(veriyukle.GetValue(0));
            }

            connection.Close();

            /* foreach (double isb in oisbn)
             {
                 GOneriler1(isb);
             }*/
            GOneriler1();
        //    MessageBox.Show("s isbn sayısı   " + sisbn.Count);                      
          
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
           pdf = new KitapOku();

            if (listView4.SelectedItems.Count > 0)
            {
                ListViewItem item = listView4.SelectedItems[0];
                pictureBox4.ImageLocation = item.SubItems[5].Text;
                tisbn.Text = item.SubItems[0].Text;
                tbooktitle.Text = item.SubItems[1].Text;
                tbookauther.Text = item.SubItems[2].Text;
                tyearpublic.Text = item.SubItems[3].Text;
                tpublisher.Text = item.SubItems[4].Text;
                pdf.Kitapoku(path);
                pdf.Show();
            }
          

        }


        /*  private void Oneriler(double isb)
          {

              var connection = Database.GetConnection();
              if (connection.State == ConnectionState.Closed)
                  connection.Open();


              SqlCommand cmd = new SqlCommand("select top 10 ISBN from dbo.BookRatings where UsId in( select UsId from dbo.BookRatings where ISBN='" + isb + "' ) order by BookRating desc", connection);
              SqlDataReader veriyukle = cmd.ExecuteReader();


              while (veriyukle.Read())
              {
                  sisbn.Add(veriyukle.GetValue(0));
              }

              //   mpage.Araci(sisbn);

          }*/
    }
    }

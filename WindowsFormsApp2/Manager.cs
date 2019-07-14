using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp2
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=DESKTOP-ES2IR65\\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
        Listele listele=null;

        private void button1_Click(object sender, EventArgs e)
        {
            //yeni kayıt                                  

            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;            
            groupBox3.Visible = false;
          
        }
        DataTable table;
            string sorgu;
           
     

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void button5_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(conString);


          //  MessageBox.Show(textBox11.Text);
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string kayit = "insert into Books(ISBN,BookTitle,BookAuthor,YearOfPublication,Publisher,ImageURLM) VALUES (@ISBN,@BookTitle,@BookAuthor,@YearOfPublication,@Publisher,@ImageURLM)";
                SqlCommand komut = new SqlCommand(kayit, con);

                komut.Parameters.AddWithValue("@ISBN", textBox1.Text);
                komut.Parameters.AddWithValue("@BookTitle", textBox2.Text);
                komut.Parameters.AddWithValue("@BookAuthor", textBox3.Text);
                komut.Parameters.AddWithValue("@YearOfPublication", textBox4.Text);
                komut.Parameters.AddWithValue("@Publisher", textBox5.Text);
                komut.Parameters.AddWithValue("@ImageURLM", textBox11.Text);
                komut.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kitap Bilgileri Eklendi");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox11.Text = "";
            }

            
            //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.

            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
           // SqlConnection con = new SqlConnection(conString);

            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            String imageway = openFileDialog1.FileName;
            textBox11.Text = imageway;
           // MessageBox.Show(imageway);


          /*  if (con.State == ConnectionState.Closed)
                con.Open();
            string kayit = "insert into Books(ImageURLS) VALUES (@ImageURLS)";
            SqlCommand komut = new SqlCommand(kayit, con);

            komut.Parameters.AddWithValue("@ImageURLS", textBox11.Text);
            komut.ExecuteNonQuery();
            con.Close();*/
          //  MessageBox.Show(textBox11.Text);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele = new Listele();
            SqlConnection con = new SqlConnection(conString);
            string sorgu;
            sorgu = " Delete from Books where ISBN = '" + textBox6.Text + "' and BookTitle = '" + textBox7.Text + "' and Publisher='" + textBox8.Text + "'";
            listele.DbSil(sorgu);
            MessageBox.Show(textBox6.Text + ",  " + textBox7.Text + ", " + textBox8.Text + " kitabı silindi");
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listele = new Listele();
            SqlConnection con = new SqlConnection(conString);
            string sorgu;
            sorgu = " Delete from Users where UseId = '" + textBox9.Text + "' and UsName = '" + textBox10.Text + "'";
            listele.DbSil(sorgu);
            MessageBox.Show(textBox9.Text + ",  " + textBox10.Text +  " kişi silindi");
            textBox9.Text = "";
            textBox10.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserEnter userenter = new UserEnter();
            this.Hide();
            userenter.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listele = new Listele();
            //kitap listele
            groupBox3.Visible = true;
            groupBox2.Visible = true;
            groupBox1.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;


            sorgu = "SELECT [ISBN],[BookTitle],[BookAuthor],[YearOfPublication],[Publisher] ,[ImageURLM] FROM Books";
            table = listele.DbListele(sorgu);
            dataGridView1.DataSource = table; ;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox3.Visible = false;


            sorgu = "SELECT [UsLocation],[UsAge],[UseId],[UsName] ,[UsPass] FROM Users";
            table = listele.DbListele(sorgu);
            dataGridView1.DataSource = table; ;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //kullanıcı sil
            groupBox4.Visible = false;
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            groupBox5.Visible = true;

            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //kitap sil
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = true;
            groupBox5.Visible = false;

           
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            pictureBox1.ImageLocation = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MainPage mpage = new MainPage();
            this.Hide();
            mpage.Show();
        }
    }
}


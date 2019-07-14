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
    public partial class KitapArşiv : Form
    {
        public KitapArşiv()
        {
            InitializeComponent();
        }
        ArrayList oisbn = new ArrayList();


        public ArrayList sisbn = new ArrayList();
        User user = new User();

        MainPage mpage;
        // UserEnter fr1 = new UserEnter();
        public string conString = "Data Source=DESKTOP-ES2IR65\\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
        private void KitapArşiv_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand komut = new SqlCommand("SELECT [ISBN],[BookTitle],[BookAuthor],[YearOfPublication],[Publisher] ,[ImageURLM] FROM Books", con);
                SqlDataReader veriyukle = komut.ExecuteReader();
                DataTable tablo = new DataTable();
                tablo.Load(veriyukle);
                dataGridView1.DataSource = tablo;

            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu: " + hata.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            tisbn.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            tbooktitle.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            tbookauther.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            tpublisher.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            tyearpublic.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string username = UserSave.name;
            // MessageBox.Show("username  :" + username);

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
                //  MessageBox.Show(id);
            }

            cmd.Dispose();
            connection.Close();
            string kayit = "insert into BookRatings(UsId,ISBN,BookRating) Values (@UsId,@ISBN,@BookRating)";

            connection.Open();
            SqlCommand komut1 = new SqlCommand(kayit, connection);
            komut1.Parameters.AddWithValue("@UsId", id);
            komut1.Parameters.AddWithValue("@ISBN", tisbn.Text);
            komut1.Parameters.AddWithValue("@BookRating", txtpuan);
            //  oisbn.Add(tisbn.Text);

            if (komut1.ExecuteNonQuery() != -1)
            {
                MessageBox.Show("Puan Eklendi");
                sayac++;
            }
            if (sayac > 10)
            {
                button2.Visible = true;
            }
            connection.Close();

        }
        public string txtpuan;
        int sayac = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "1":
                    txtpuan = "1";
                    break;
                case "2":
                    txtpuan = "2";
                    break;
                case "3":
                    txtpuan = "3";
                    break;
                case "4":
                    txtpuan = "4";
                    break;
                case "5":
                    txtpuan = "5";
                    break;
                case "6":
                    txtpuan = "6";
                    break;
                case "7":
                    txtpuan = "7";
                    break;
                case "8":
                    txtpuan = "8";
                    break;
                case "9":
                    txtpuan = "9";
                    break;
                case "10":
                    txtpuan = "10";
                    break;

            }
        }
        //  KitapArşiv kitapas = new KitapArşiv();
        private void button2_Click(object sender, EventArgs e)
        {
            string name = UserSave.name;
            MainPage mp = new MainPage();
            this.Hide();
            mp.Show();
            //  mp.Oneriler1(name);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}






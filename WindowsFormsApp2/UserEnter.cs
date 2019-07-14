using System;
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
    public partial class UserEnter : Form
    {
        public  UserEnter()
        {
            InitializeComponent();
        }
          public static string name;
          public static string pass ;
        KitapArşiv kitapas;
        MainPage mpage;
        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            pass = textBox2.Text;       

            User user = null;
            try
            {

                using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT *FROM Users WHERE UsName='" + name + "' and UsPass='" + pass + "'");
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new User();
                        user.Name = reader.GetString(3);   //name
                        user.Password = reader.GetString(4);  //password
                    }
                }
                connection.Close();
            }


            }
            catch (Exception hata)
            {
                MessageBox.Show("işlem sırasında hata oluştu: " + hata.Message);
            }
           
            

            if (user != null)
            {
                try
                {

                    MainPage mp = new MainPage();
                    this.Hide();
                    mp.Show();  //MessageBox.Show("burda");
                }
                catch(Exception hata)
                {
                    MessageBox.Show("işlem sırasında hata oluştu: " + hata.Message);
                }
               
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı ya da şifre Yanlış!");
            }
            // kitapas = new KitapArşiv();
            // kitapas.Oneriler1(name);
          /*  mpage = new MainPage();
            mpage.Oneriler1(name);
            MessageBox.Show("burda");*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserSave frm2 = new UserSave();
            this.Hide();
            frm2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManagerEnter frm3 = new ManagerEnter();
            this.Hide();
            frm3.Show();
        }

       
    }
}

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
    public partial class UserSave : Form
    {
        public UserSave()
        {
            InitializeComponent();
        }

         public string conString = "Data Source=DESKTOP-ES2IR65\\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
       //  public UserControl usercontrol;
         User user = new User();
        public  static string name;
        private void button1_Click(object sender, EventArgs e)
        {
            user.Name = textBox1.Text;
            user.Location = textBox2.Text;
            user.Age = textBox3.Text;
            user.Password = textBox4.Text;
            name = textBox1.Text;
            bool result = false;
            using (var connection = Database.GetConnection())
            {
              //  var command = new SqlCommand("SELECT *FROM Users WHERE UsName='" + user.Name + "'");
                var command = new SqlCommand("SELECT *FROM Users WHERE UsName='" + user.Name + "' and UsPass='" + user.Password + "'");
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = true;
                    }
                }
                connection.Close();
            }
          
            using (var connection = Database.GetConnection())
            {               
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                   // usercontrol = new UserControl();
                 
                    if (!result)
                    {
                       // MessageBox.Show("fdfwefwefwe");
                        string kayit = "insert into Users(UsName,UsLocation,UsAge,UsPass) Values (@UsName,@UsLocation,@UsAge,@UsPass)";

                        SqlCommand komut = new SqlCommand(kayit, connection);
                        komut.Parameters.AddWithValue("@UsName", user.Name);
                        komut.Parameters.AddWithValue("@UsLocation", user.Location);
                        komut.Parameters.AddWithValue("@UsAge", user.Age);
                        komut.Parameters.AddWithValue("@UsPass", user.Password);

                        if (komut.ExecuteNonQuery() != -1)
                        {
                            MessageBox.Show("Kullanıcı Eklendi");
                        }
                     
                        //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                        connection.Close();
                        KitapArşiv f1 = new KitapArşiv();
                        this.Hide();
                        f1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Bu Kullanıcı adı var!");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }

                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserEnter f1 = new UserEnter();
            this.Hide();
            f1.Show();
        }

        private void UserSave_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class ManagerEnter : Form
    {
        public ManagerEnter()
        {
            InitializeComponent();
        }
        public static string ad, sifre;
        private void button1_Click(object sender, EventArgs e)
        {
           
            ad = textBox1.Text;
            sifre = textBox2.Text;
            if(ad == "ayse" & sifre == "1")
            {
                Manager frm4 = new Manager();
                this.Hide();
                frm4.Show();
            }
            else
            {
                MessageBox.Show("Yanlış kullanıcı adı veya şifre!!!");
            }                                  

        }

        private void ManagerEnter_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserEnter us = new UserEnter();
            this.Hide();
            us.Show();
        }
    }
}


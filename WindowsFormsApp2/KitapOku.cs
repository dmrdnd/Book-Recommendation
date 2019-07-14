using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class KitapOku : Form
    {
        public KitapOku()
        {
            InitializeComponent();
        }

        private void KitapOku_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile("C:\\Users\\Döndü Demir\\Desktop\\kitap.pdf");
        }
        public void Kitapoku(string path)
        {
           // MessageBox.Show("rggrge");
            axAcroPDF1.LoadFile(path);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

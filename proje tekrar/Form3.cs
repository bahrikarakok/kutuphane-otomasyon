using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje_tekrar
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( kullanıcıadı.Text  == "admin")
            {
                MessageBox.Show("Yanlış seçenek  2 hakkınız kaldı");
            }
            else
            {
                MessageBox.Show("Kullanıcı adınız yanlış girilmiştir");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kullanıcıadı.Text == "admin")
            {
                MessageBox.Show("Yanlış seçenek oturum sonlandırılıyor");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Kullanıcı adınız yanlış girilmiştir");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kullanıcıadı.Text == "admin")
            {
                MessageBox.Show("Yanlış seçenek oturum sonlandırılıyor");
                Application.Exit();
            }
           
                
            else
            {
                MessageBox.Show("Kullanıcı adınız yanlış girilmiştir");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (kullanıcıadı.Text == "admin")
            {
                MessageBox.Show("Yeni Şifrenizi giriniz");

            }
            else
            {
                MessageBox.Show("Kullanıcı adınız yanlış girilmiştir");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (kullanıcıadı.Text == "admin")
            {
                MessageBox.Show("Yanlış seçenek oturum sonlandırılıyor");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Kullanıcı adınız yanlış girilmiştir");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (kullanıcıadı.Text == "admin")
            {
                MessageBox.Show("Yanlış seçenek oturum sonlandırılıyor");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Kullanıcı adınız yanlış girilmiştir");
            }
        }
    }
}

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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "123456")
            {
                MessageBox.Show("Giriş Başarılı HOŞGELDİNİZ");
                Form2 fr = new Form2();
                fr.Show();
                this.Hide();
  
            }
            else if (textBox1.Text == "admin" && textBox2.Text != "123456")
            {
                MessageBox.Show("Şifre Yanlış Tekrar deneyiniz");
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifreyi tekrar deneyiniz");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

    }
}

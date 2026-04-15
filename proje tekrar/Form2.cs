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
using System.Data.OleDb;

namespace proje_tekrar
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-B60LFM8;Initial Catalog=kütüphaneproje;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        DataSet ds;
        DataTable tablo = new DataTable();
        DataTable tablo2 = new DataTable();
        void griddoldur()
        {
            da = new SqlDataAdapter("Select * from Kitaplar",con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Kitaplar");
            dataGridView1.DataSource = ds.Tables["Kitaplar"];
            con.Close();
        }
        
        void griddd()
        {
            da = new SqlDataAdapter("Select * from Anasayfa where DATEDIFF(day, GETDATE(), Teslimtarihi) <= 2", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Anasayfa");
            dataGridView6.DataSource = ds.Tables["Anasayfa"];
            con.Close();
        }
        void grid()
        {
            da = new SqlDataAdapter("Select * from Alıcılar", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Alıcılar");
            dataGridView2.DataSource = ds.Tables["Alıcılar"];
            con.Close();
        }
        void grid3()
        {
            da = new SqlDataAdapter("Select * from  Anasayfa", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Anasayfa");
            dataGridView3.DataSource = ds.Tables["Anasayfa"];
            con.Close();
        }
        void grid4()
        {
            da = new SqlDataAdapter("Select * from Alıcılar", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Alıcılar");
            dataGridView5.DataSource = ds.Tables["Alıcılar"];
            con.Close();
        }
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            griddoldur();
            grid();
            grid3();
            griddd();
            Form1 fr = new Form1();
            fr.Close();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtad.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txtposta.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            maskedTextBox1.Text = Convert.ToString(dataGridView2.CurrentRow.Cells[5].Value.ToString());
            comboBox1.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            kitapid.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtad.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txtposta.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            maskedTextBox1.Text = Convert.ToString(dataGridView2.CurrentRow.Cells[5].Value.ToString());
            comboBox1.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            con.Open();
            SqlCommand komut = new SqlCommand("insert into kitaplar (KitapAdı,Yayınevi,SayfaSayısı,Yazaradı) values (@p1,@p2,@p3,@p4)", con);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
            komut.Parameters.AddWithValue("@p4", textBox4.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kitap Eklendi");
            
            con.Close();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            komut = new SqlCommand("Delete from Kitaplar where KitapID = @kitapid", con);
            komut.Parameters.AddWithValue("@kitapid", int.Parse(kitapid.Text));
            komut.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kitap Silindi");
            griddoldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            komut = new SqlCommand("Update  Kitaplar set KitapAdı=@p1,Yayınevi=@p2,SayfaSayısı= @p3,Yazaradı=@p4 where KitapID = @p0", con);
            komut.Parameters.AddWithValue("@p0", int.Parse(kitapid.Text));
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
            komut.Parameters.AddWithValue("@p4", textBox4.Text);
            komut.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Bilgiler güncellendi");
            griddoldur();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            grid();
            con.Open();
           SqlCommand command  = new SqlCommand("INSERT INTO Alıcılar (İsim, Soyisim, eposta, dogumtarihi, telefonnumara, cinsiyet) " +
                                   "VALUES (@isim, @soyisim, @eposta, @dogumtarihi, @telefonnumara, @cinsiyet)", con);

            command.Parameters.AddWithValue("@isim", txtad.Text);
            command.Parameters.AddWithValue("@soyisim", txtsoyad.Text);
            command.Parameters.AddWithValue("@eposta", txtposta.Text);
            command.Parameters.AddWithValue("@dogumtarihi", dateTimePicker1.Value);
            command.Parameters.AddWithValue("@telefonnumara", maskedTextBox1.Text);
            command.Parameters.AddWithValue("@cinsiyet", comboBox1.SelectedItem.ToString());
            int sonuc = command.ExecuteNonQuery();
            if (sonuc > 0)
            {

            }
            else
            {
                MessageBox.Show("EKLENEMEDİ");
            }
            con.Close();
            MessageBox.Show("Alıcı Eklendi");
            grid();






        }

        private void button7_Click(object sender, EventArgs e)
        {
            grid();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            komut = new SqlCommand("Delete from Alıcılar where AlıcıID = @Alıcıid", con);
            komut.Parameters.AddWithValue("@alıcıid", int.Parse(textBox5.Text));
            komut.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Alıcı Silindi");
            grid(); 
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            grid();
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void karanlıkEkranModuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Gray;
            textBox2.BackColor = Color.Gray;
            textBox3.BackColor = Color.Gray;
            textBox4.BackColor = Color.Gray;
            textBox5.BackColor = Color.Gray;
            textBox6.BackColor = Color.Gray;
            txtposta.BackColor = Color.Gray;
            txtad.BackColor = Color.Gray;
            txtsoyad.BackColor = Color.Gray;
            maskedTextBox1.BackColor = Color.Gray;
            groupBox1.BackColor = Color.Black;
            groupBox2.BackColor = Color.Black;
            groupBox3.BackColor = Color.Black;
            dataGridView1.BackgroundColor = Color.Black;
            dataGridView2.BackgroundColor = Color.Black;
            dataGridView3.BackgroundColor = Color.Black;
            tabPage1.BackColor = Color.Black;
            tabPage2.BackColor = Color.Black;
            tabPage3.BackColor = Color.Black;
            label1.BackColor = Color.LightGray;
            label2.BackColor = Color.LightGray;
            label3.BackColor = Color.LightGray;
            label4.BackColor = Color.LightGray;
            label5.BackColor = Color.LightGray;
            label6.BackColor = Color.LightGray;
            label7.BackColor = Color.LightGray;
            label8.BackColor = Color.LightGray;
            label9.BackColor = Color.LightGray;
            label10.BackColor = Color.LightGray;
            label11.BackColor = Color.LightGray;
            label12.BackColor = Color.LightGray;
            label13.BackColor = Color.LightGray;
            label14.BackColor = Color.LightGray;
            groupBox1.ForeColor = Color.Gray;
            groupBox2.ForeColor = Color.Gray;
            groupBox3.ForeColor = Color.Gray;
        }

        private void hakkımızdaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hakkımızda hk = new hakkımızda();
            hk.Show();
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            tablo.Clear();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Alıcılar where İsim like '%" + textBox6.Text+ "%'", con);
            adtr.Fill(tablo);
            dataGridView5.DataSource = tablo;
            con.Close();

        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Alıcılar where Soyisim like '%" + textBox7.Text + "%'", con);
            adtr.Fill(tablo);
            dataGridView5.DataSource = tablo;
            con.Close();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            tablo2.Clear();
            con.Open();
            if (textBox7.Text == "")
            {
                SqlDataAdapter adtr = new SqlDataAdapter("select * from Kitaplar", con);
                adtr.Fill(tablo2);
                dataGridView4.DataSource = tablo2;
                con.Close();
            }
            else 
            {
                SqlDataAdapter adtr = new SqlDataAdapter("select * from Kitaplar where Kitapadı like '%" + textBox7.Text + "%'", con);
                adtr.Fill(tablo2);
                dataGridView4.DataSource = tablo2;
                con.Close();
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            
            tablo.Clear();
            con.Open();
            if (textBox9.Text == "")
            {
                SqlDataAdapter adtr = new SqlDataAdapter("select * from Alıcılar", con);
                adtr.Fill(tablo);
                dataGridView5.DataSource = tablo;
                con.Close();
            }
            else
            {
                int a = int.Parse(textBox9.Text);
                SqlDataAdapter adtr = new SqlDataAdapter("select * from Alıcılar where AlıcıID like '%" + a + "%'", con);
                adtr.Fill(tablo);
                dataGridView5.DataSource = tablo;
                con.Close();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            tablo2.Clear();
            con.Open();
            if (textBox10.Text == "")
            {
                SqlDataAdapter adtr = new SqlDataAdapter("select * from Kitaplar", con);
                adtr.Fill(tablo2);
                dataGridView4.DataSource = tablo2;
                con.Close();
                
            }
            else
            {
                int a = int.Parse(textBox10.Text);
                SqlDataAdapter adtr = new SqlDataAdapter("select * from Kitaplar where KitapID like '%" + a + "%'", con);
                adtr.Fill(tablo2);
                dataGridView4.DataSource = tablo2;
                con.Close();
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
            textBox8.Text = dataGridView5.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox10.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            textBox7.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Anasayfa (AlanID,Alanismi,Alansoyismi,KitapID, Kitapadı,Aldığıtarih,Teslimtarihi) " +
                                  "VALUES (@alanid, @alanisim, @alansoyisim,@KitapID,@Kitapadı,@aldığıtarihi, @teslimtarihi)", con);

            command.Parameters.AddWithValue("@alanid", int.Parse(textBox9.Text));
            command.Parameters.AddWithValue("@alanisim", textBox6.Text);
            command.Parameters.AddWithValue("@alansoyisim", textBox8.Text);
            command.Parameters.AddWithValue("@KitapID", int.Parse(textBox10.Text));
            command.Parameters.AddWithValue("@Kitapadı", textBox7.Text);
            command.Parameters.AddWithValue("@aldığıtarihi",dateTimePicker2.Value);
            command.Parameters.AddWithValue("@teslimtarihi", dateTimePicker3.Value);
            int sonuc = command.ExecuteNonQuery();
            if (sonuc > 0)
            {
                MessageBox.Show("Kayıt Eklendi");
            }
            else
            {
                MessageBox.Show("EKLENEMEDİ");
            }
            con.Close();
            grid3();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            con.Open();
            komut = new SqlCommand("Update  Anasayfa set Alanismi=@p1,Alansoyismi= @p2,KitapID=@p3,Kitapadı= @p4,Aldığıtarih=@p5 , Teslimtarihi=@p6  where AlanID = @p0", con);
            komut.Parameters.AddWithValue("@p0", int.Parse(textBox9.Text));
            komut.Parameters.AddWithValue("@p1", textBox6.Text);
            komut.Parameters.AddWithValue("@p2", textBox8.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(textBox10.Text));
            komut.Parameters.AddWithValue("@p4", textBox7.Text);
            komut.Parameters.AddWithValue("@p5", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("@p6", dateTimePicker3.Value);
            komut.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Bilgiler güncellendi");
            grid3();
        }

       
        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox11.Text = Convert.ToString(dataGridView3.CurrentRow.Cells[0].Value.ToString());
            textBox9.Text = Convert.ToString (dataGridView3.CurrentRow.Cells[1].Value.ToString());
            textBox6.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            textBox8.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            textBox10.Text = Convert.ToString(dataGridView3.CurrentRow.Cells[4].Value.ToString());
            textBox7.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker2.Value = Convert.ToDateTime( dataGridView3.CurrentRow.Cells[7].Value.ToString());
            dateTimePicker3.Value = Convert.ToDateTime(dataGridView3.CurrentRow.Cells[6].Value.ToString());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            con.Open();
            komut = new SqlCommand("Delete from Anasayfa where AlımID = @z1", con);
            komut.Parameters.AddWithValue("@z1", int.Parse(textBox11.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silindi");
            con.Close();
            grid3();
        }
        
        private void tabPage3_Click(object sender, EventArgs e)
        {
           
        }
    }
}

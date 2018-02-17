using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Media;

namespace WindowsFormsApplication6
{
    public partial class Form5 : Form
    {

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.jet.Oledb.4.0;Data Source=vt1.mdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataReader rd;

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Random yeni = new Random();
            int a = yeni.Next(1, 10);
            int b = yeni.Next(1, 10);
            int c = yeni.Next(1, 10);
            int d = yeni.Next(1, 10);
            label14.Text = a.ToString();
            label15.Text = b.ToString();
            label16.Text = c.ToString();
            label17.Text = d.ToString();

            baglan.Open();
            OleDbCommand komut = new OleDbCommand("Select * from SORU", baglan);
            rd = komut.ExecuteReader();
            while(rd.Read()==true)
            {
                comboBox1.Items.Add(rd[1].ToString());

            }
            baglan.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-09.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            
            
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-20.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            
            
            
            string isim, soyisim, kullanici, şifre;
            isim = textBox1.Text;
            soyisim = textBox2.Text;
            kullanici = isim + soyisim;
            şifre = textBox5.Text;


            string text1 = textBox3.Text;
            string text2 = textBox4.Text;
            string text3 = textBox5.Text;
            string text4 = textBox6.Text;
            string kod = label14.Text + label15.Text + label16.Text + label17.Text;
            if (textBox11.Text != kod | textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox5.Text == "" | textBox7.Text == "" | textBox11.Text == "" | text1 != text2 | text3 != text4)
            {
                MessageBox.Show("Hatalı doğrulama");
                  MessageBox.Show("Girilmesi Zorunlu Alanları Doldurunuz");
                  MessageBox.Show("E-posta veya Şifrenizde Uyuşmazlık Tespit Edilmiştir!");
                  textBox4.Clear();
                  textBox6.Clear();
                Random yeni = new Random();
                int a = yeni.Next(1, 10);
                int b = yeni.Next(1, 10);
                int c = yeni.Next(1, 10);
                int d = yeni.Next(1, 10);
                label14.Text = a.ToString();
                label15.Text = b.ToString();
                label16.Text = c.ToString();
                label17.Text = d.ToString();

            }
            else
            {

                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = ("INSERT INTO KAYIT(İsim,Soyisim,E_posta,Şifre,Gizli_Soru,Cevap,Cep_No,İş_Ev_No,Adres,KullanıcıAdı) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + comboBox1.SelectedItem + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','"+kullanici+"')");
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kullanıcı Adınız : " + kullanici + "\n" + "Şifreniz : " + şifre);

                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = ("INSERT INTO GİRİŞ(KullanıcıAdı,Şifre) Values('" + kullanici + "','" + şifre + "')");
                komut.ExecuteNonQuery();
                baglan.Close();
                
                Close();
            
            }
           

            
              
           
           



            


        }
    }
}
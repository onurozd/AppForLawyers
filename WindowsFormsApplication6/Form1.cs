using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Data.OleDb;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.jet.Oledb.4.0;Data Source=vt1.mdb");
        
        
        OleDbCommand komut = new OleDbCommand();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             
                SoundPlayer ses = new SoundPlayer();
                string dizin = Application.StartupPath + "\\button-20.wav";
                ses.SoundLocation = dizin;
                ses.Play();


                progressBar1.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100000;
                progressBar1.Step = 1;
                for (int i = 0; i <= 100000; i++)
                {
                    progressBar1.Value = i;

                }
                MessageBox.Show("Kontroller Yapılmıştır!");


            OleDbDataReader rd;
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = ("Select ID,KullanıcıAdı,Şifre From GİRİŞ Where KullanıcıAdı='" + textBox2.Text + "' and Şifre='" + textBox3.Text + "'");
            rd = komut.ExecuteReader();
            if (rd.Read() == true)
            {


                Form2 form = new Form2();
                form.ikinciform = Convert.ToInt32(rd[0]);
                form.ShowDialog();




            }
            else
            {
                MessageBox.Show("Hatalı giriş");
            }
            baglan.Close();

            textBox2.Clear();
            textBox3.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-09.wav";
            ses.SoundLocation = dizin;
            ses.Play();



            Close();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\web.wav";
            ses.SoundLocation = dizin;
            ses.Play();


            System.Diagnostics.Process.Start("https://www.facebook.com/groups/428470507326258/");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\web.wav";
            ses.SoundLocation = dizin;
            ses.Play();


            Form6 frm6 = new Form6();
            frm6.ShowDialog();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
       
        
        
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                SoundPlayer ses = new SoundPlayer();
                string dizin = Application.StartupPath + "\\button-20.wav";
                ses.SoundLocation = dizin;
                ses.Play();


                progressBar1.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100000;
                progressBar1.Step = 1;
                for (int i = 0; i <= 100000; i++)
                {
                    progressBar1.Value = i;

                }
                MessageBox.Show("Kontroller Yapılmıştır!");


                OleDbDataReader rd;
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = ("Select ID,KullanıcıAdı,Şifre From GİRİŞ Where KullanıcıAdı='" + textBox2.Text + "' and Şifre='" + textBox3.Text + "'");
                rd = komut.ExecuteReader();
                if (rd.Read() == true)
                {


                    Form2 form = new Form2();
                    form.ikinciform = Convert.ToInt32(rd[0]);
                    form.ShowDialog();




                }
                else
                {
                    MessageBox.Show("Hatalı giriş");
                }
                baglan.Close();

                textBox2.Clear();
                textBox3.Clear();


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
             OleDbDataReader rd;
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = ("Select ID,KullanıcıAdı,Şifre From GİRİŞ Where KullanıcıAdı='" + textBox2.Text + "' and Şifre='" + textBox3.Text + "'");
                rd = komut.ExecuteReader();
                if (rd.Read() == true)
                {
            Form7 frm7 = new Form7();
            frm7.yedinciform = Convert.ToInt32(rd[0]);
            frm7.Show();
                }
                baglan.Close();
        }

       
    }
}
    


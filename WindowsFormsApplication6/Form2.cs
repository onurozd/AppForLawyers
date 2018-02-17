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
    public partial class Form2 : Form
    {
        public int ikinciform;
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.jet.Oledb.4.0;Data Source=vt1.mdb");
        OleDbCommand komut = new OleDbCommand();
        DataSet ds = new DataSet();
        OleDbDataReader dr;
        

        public void verilerigöster(string veriler)
        {
            OleDbDataAdapter da = new OleDbDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }


        public Form2()
        {
            InitializeComponent();
        }

        private void Ekle_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-20.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            
            
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            Ekle.BackColor = Color.ForestGreen;
            Sil.BackColor = Color.WhiteSmoke;
            Güncelle.BackColor = Color.WhiteSmoke;
           
        }

        private void Sil_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-20.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            
            
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            Sil.BackColor = Color.ForestGreen;
            Güncelle.BackColor = Color.WhiteSmoke;
            Ekle.BackColor = Color.WhiteSmoke;
        }

        private void Güncelle_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-20.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            
            
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            Güncelle.BackColor = Color.ForestGreen;
            Ekle.BackColor = Color.WhiteSmoke;
            Sil.BackColor = Color.WhiteSmoke;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-09.wav";
            ses.SoundLocation = dizin;
            ses.Play();

            int a = Convert.ToInt32(textBox6.Text);
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "UPDATE DAVA SET Vekil_Adi='" + textBox4.Text + "',Soyadi='" + textBox14.Text + "',Dava_Nedeni='" + textBox5.Text + "',Mahk_Tarihi='" + dateTimePicker2.Text + "', Dava_Yeri='" + textBox17.Text + "' WHERE Dava_No='" + a + "' ";
            komut.ExecuteNonQuery();
            verilerigöster("select * from DAVA WHERE ID="+ikinciform);
            baglan.Close();

            textBox4.Clear();
            textBox17.Clear();
           
            textBox6.Clear();
            textBox14.Clear();
            textBox5.Clear();
            dateTimePicker2.Text = DateTime.Now.ToLongDateString();
            textBox6.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tarih = dateTimePicker1.Text;
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-09.wav";
            ses.SoundLocation = dizin;
            ses.Play();

            if (textBox13.Text.Length < 11 || textBox13.Text.Length > 11  || Convert.ToInt32(textBox13.Text[10]) % 2 == 1)
            {
                 
               
                MessageBox.Show("T.C. Kimlik Numarası Yanlış!");

            }
            else if( textBox2.Text == "")
                MessageBox.Show("Dava Numarasını Boş Olamaz !");
            else
            {
                int id = ikinciform;
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "INSERT INTO DAVA (Dava_No,ID,TCKNO,Vekil_Adi,Soyadi,Dava_Nedeni,Mahk_Tarihi,Dava_Yeri) VALUES ('" + textBox2.Text + "',"+id+",'" + textBox13.Text + "','" + textBox1.Text + "','" + textBox7.Text + "','" + textBox12.Text + "','" + tarih + "','" + textBox16.Text + "')";
                komut.ExecuteNonQuery();
                verilerigöster("select * from DAVA WHERE ID="+ikinciform);
                baglan.Close();
                
            }


            textBox13.Clear();
            textBox16.Clear();
            textBox7.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox12.Clear();
            dateTimePicker1.Text = DateTime.Now.ToLongDateString();
            textBox13.Focus();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-09.wav";
            ses.SoundLocation = dizin;
            ses.Play();


            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "DELETE from DAVA WHERE Dava_No='" + textBox3.Text + "'";
            komut.ExecuteNonQuery();
            verilerigöster("select * from DAVA WHERE ID=" + ikinciform);
            baglan.Close();
           

            textBox3.Clear();
            textBox3.Focus();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            Güncelle.BackColor = Color.WhiteSmoke;
            Ekle.BackColor = Color.WhiteSmoke;
            Sil.BackColor = Color.WhiteSmoke;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            verilerigöster("select Dava_No,ID,TCKNO,Vekil_Adi,Soyadi,Dava_Nedeni,Mahk_Tarihi,Dava_Yeri from DAVA where ID=" + ikinciform);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("select * from DAVA WHERE  Vekil_Adi like '%" + textBox10.Text + "%' and ID="+ikinciform, baglan);
            OleDbDataAdapter da = new OleDbDataAdapter(komut);
            DataSet ds= new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("select * from DAVA WHERE  Soyadi like '%" + textBox9.Text + "%' and ID="+ikinciform, baglan);
            OleDbDataAdapter da = new OleDbDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
           
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("select * from DAVA WHERE  Dava_Nedeni like '%" + textBox8.Text + "%' and ID="+ikinciform, baglan);
            OleDbDataAdapter da = new OleDbDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();
        }

        private void Ekle_MouseHover(object sender, EventArgs e)
        {
            Ekle.BackColor = Color.Red;
        }

        private void Sil_MouseHover(object sender, EventArgs e)
        {
            Sil.BackColor = Color.Red;
        }

        private void Güncelle_MouseHover(object sender, EventArgs e)
        {
            Güncelle.BackColor = Color.Red;
        }

        private void Güncelle_MouseLeave(object sender, EventArgs e)
        {
            Güncelle.BackColor = Color.White;
        }

        private void Sil_MouseLeave(object sender, EventArgs e)
        {
            Sil.BackColor = Color.White;
        }

        private void Ekle_MouseLeave(object sender, EventArgs e)
        {
            Ekle.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("select * from DAVA WHERE Dava_No='" + textBox6.Text + "'", baglan);
            dr = komut.ExecuteReader();
            while (dr.Read()==true)
            {
               
                textBox4.Text = dr[3].ToString();
                textBox14.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                dateTimePicker2.Text = dr[6].ToString();
                textBox17.Text = dr[7].ToString();
            }
            baglan.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            string tarih = dateTimePicker1.Text;
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("select * from DAVA WHERE Mahk_Tarihi like '%" + tarih + "%' and ID="+ikinciform, baglan);
            OleDbDataAdapter da = new OleDbDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglan.Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-20.wav";
            ses.SoundLocation = dizin;
            ses.Play();

            verilerigöster("select * from DAVA WHERE ID=" + ikinciform);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-09.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            
            
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void kayıtEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-20.wav";
            ses.SoundLocation = dizin;
            ses.Play();


            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void kayıtGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-20.wav";
            ses.SoundLocation = dizin;
            ses.Play();


            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void kayıtSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-20.wav";
            ses.SoundLocation = dizin;
            ses.Play();


            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void ismeGöreAraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-20.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            textBox10.Focus();
        }

        private void soyismeGöreAraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-20.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            textBox9.Focus();
        }

        private void davayaGöreAraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-20.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            textBox8.Focus();
        }

        private void tariheGöreAraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-20.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            dateTimePicker3.Focus();
        }

        private void geriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-20.wav";
            ses.SoundLocation = dizin;
            ses.Play();

            verilerigöster("select * from DAVA");
        }

        private void detaylarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-09.wav";
            ses.SoundLocation = dizin;
            ses.Play();


            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-09.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            Application.Exit();

             
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

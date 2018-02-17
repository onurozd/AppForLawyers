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
    public partial class Form6 : Form
    {
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.jet.Oledb.4.0;Data Source=vt1.mdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataReader rd;

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\key.wav";
            ses.SoundLocation = dizin;
            ses.Play();
            
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = ("SELECT Cevap,Şifre FROM KAYIT WHERE Cevap='" + textBox2.Text + "'");
            rd = komut.ExecuteReader();
            while (rd.Read() == true)
            {
                MessageBox.Show("Şifreniz : " + rd[1].ToString());
            }
            baglan.Close();
           
            Close();
            
            
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = ("Select Gizli_Soru,Cevap FROM KAYIT WHERE KullanıcıAdı='" + textBox1.Text + "'");
            rd = komut.ExecuteReader();
            while (rd.Read() == true)
            {
                comboBox1.Items.Add(rd[0].ToString());

            }
            baglan.Close();
        }
    }
}

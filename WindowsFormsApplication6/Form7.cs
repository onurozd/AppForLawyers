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

namespace WindowsFormsApplication6
{
    public partial class Form7 : Form
    {


        public int yedinciform;
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.jet.Oledb.4.0;Data Source=vt1.mdb");
        OleDbCommand komut = new OleDbCommand();
        public void Ekle()
        {
            string tarih = dateTimePicker1.Text;
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "INSERT INTO DAVA (Dava_No,ID,TCKNO,Vekil_Adi,Soyadi,Dava_Nedeni,Mahk_Tarihi,Dava_Yeri) VALUES ('" +Convert.ToInt32(textBox2.Text) +"'," + yedinciform + ",'" + textBox13.Text + "','" + textBox1.Text + "','" + textBox7.Text + "','" + textBox12.Text + "','" + tarih + "','" + textBox16.Text + "')";
            komut.ExecuteNonQuery();
            baglan.Close();
        }
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            Davalar dava = new Davalar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Davalar dava = new Davalar();
            

            dava.Dava_No = Convert.ToInt32(textBox2.Text);
            dava.ID = yedinciform;
            dava.TCKNO = textBox13.Text;
            dava.Vekil_Adi = textBox1.Text;
            dava.Soyadi = textBox7.Text;
            dava.Dava_Nedeni = textBox12.Text;
            dava.Dava_Yeri = textBox16.Text;
            dava.Mahk_Tarihi = dateTimePicker1.Text;
        }
    }
}

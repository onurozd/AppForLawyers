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
    public partial class Form3 : Form
    {
        public int ikinciform;
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.jet.Oledb.4.0;Data Source=vt1.mdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataReader rd;

        

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Visible = false;
            button1.Enabled = false;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-20.wav";
            ses.SoundLocation = dizin;
            ses.Play();


            
            
                baglan.Open();
                OleDbCommand komut = new OleDbCommand("select Dava_No,TCKNO,Vekil_Adi,Soyadi,Dava_Nedeni,Mahk_Tarihi,Dava_Yeri from DAVA WHERE Dava_No='" + textBox1.Text + "'", baglan);
                rd = komut.ExecuteReader();
                while (rd.Read() == true)
                {
                    label15.Text = rd[0].ToString();
                    
                    label12.Text = rd[1].ToString();
                    label3.Text = rd[2].ToString();
                    label14.Text = rd[3].ToString();
                    label8.Text = rd[4].ToString();
                    dateTimePicker1.Text = rd[5].ToString();
                    label17.Text = rd[6].ToString();
                }
                baglan.Close();
            
            
            dateTimePicker2.Text = DateTime.Now.ToLongDateString();
            DateTime ilkdeger = dateTimePicker2.Value;
            DateTime sondeger = dateTimePicker1.Value;
            System.TimeSpan gün;
            gün = sondeger.Subtract(ilkdeger);
            int toplamgün = Convert.ToInt32(gün.TotalDays);
           
            if (toplamgün == 0)
            {
                MessageBox.Show("MAHKEMENİZ BUGÜN GÖRÜLECEKTİR");
            }     
            else
            {
                MessageBox.Show("MAHKEME TARİHİNİZE " + toplamgün.ToString() + " GÜN " + " KALMIŞTIR ");
            }


           
            
        }
        Font baslik = new Font("Verdana",20,FontStyle.Bold);
        Font icerik = new Font("Verdana", 15);
        SolidBrush sb = new SolidBrush(Color.Black);
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat sformat = new StringFormat();
            sformat.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("HUKUK BÜROSU", baslik, sb, 300, 300);
            e.Graphics.DrawString("Dava Yeri : "+label17.Text+"\n" + "\n" + "T.C. Kimlik No : " + label12.Text + "\n" + "\n" + "Müvekkil Adı : " + label3.Text + "\n" + "\n" + "Müvekkil Soyadı : " + label14.Text + "\n" + "\n" + "Dava Nedeni : " + label8.Text + "\n" + "\n" + "Mahkeme Tarihi : " + dateTimePicker1.Text + "\n" + "\n", icerik, sb, 70, 400);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                button1.Enabled = false;
            }
            else button1.Enabled = true;
            label15.Text = "";
            
            label12.Text = "";
            label3.Text = "";
            label14.Text = "";
            label8.Text = "";
            label17.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToLongDateString();
            textBox1.Focus();
        }
    }
}

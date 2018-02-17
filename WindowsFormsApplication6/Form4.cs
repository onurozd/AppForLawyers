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

namespace WindowsFormsApplication6
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\button-09.wav";
            ses.SoundLocation = dizin;
            ses.Play();

            Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
           
        }

       
    }
}

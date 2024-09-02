using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApartmanAsistan
{
    public partial class Anasayfa : Form
    {
       
        //Kiracilar kiracilar = new Kiracilar();

        //Aidat aidat = new Aidat();

        public Anasayfa()
        {
            InitializeComponent();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Kiracilar Obj = new Kiracilar();
            Obj.Show();
            this.Hide();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Aidat Obj = new Aidat();
            Obj.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            bunifuThinButton21.IdleForecolor = Color.White;
        }

        private void Anasayfa_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void Anasayfa_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
    }
}

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

    public partial class Login : Form
    {
        

        private const string username = "admin";
        private const string password = "1234";

        
        
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.exit, "Kapat");
            //cleartextboxes();

            bunifuTextBox2.PasswordChar = '*';
        }
        private void cleartextboxes()
        {
            bunifuTextBox1.Text = "";
            bunifuTextBox2.Text = "";
        }
        

       

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            if (bunifuTextBox1.Text == username && bunifuTextBox2.Text == password)
            {
                anasayfa.Show();
                this.Hide();
            }
            else
            {
               MessageBox.Show("Kullanıcı adı veya şifre hatalı.!");
            }
                
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cleartextboxes();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }          

        private void button5_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox2.PasswordChar == '\0')
            {
                button3.BringToFront();
                bunifuTextBox2.PasswordChar = '*';
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (bunifuTextBox2.PasswordChar == '*')
            {
                button5.BringToFront();
                bunifuTextBox2.PasswordChar = '\0';
            }
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ApartmanAsistan
{
    public partial class UpdateAidat : Form
    {
        MySqlConnection myCconnection = new MySqlConnection("server=localhost;database=finalproje;uid=root;pwd=\"\";");

        public ListViewItem listItem;
        public UpdateAidat()
        {
            InitializeComponent();
        }

        private void UpdateAidat_Load(object sender, EventArgs e)
        {
            
            try
            {
                myCconnection.Open();
                //MessageBox.Show(listItem.Text);
                string sqlText = "Select Ocak,Subat,Mart,Nisan,Mays,Haziran,Temmuz,Agustos,Eylul,Ekim,Kasim,Aralik,Ad from aidatlar a JOIN sakinler s on(s.Id=a.KId) Where a.Id = '" + listItem.Text+"'";
                MySqlCommand command = new MySqlCommand(sqlText, myCconnection);
                MySqlDataReader rd = command.ExecuteReader();
                rd.Read();

                comboBox1.SelectedItem = rd["Ocak"].ToString();
                comboBox2.SelectedItem = rd["Subat"].ToString();
                comboBox3.SelectedItem = rd["Mart"].ToString();
                comboBox4.SelectedItem = rd["Nisan"].ToString();
                comboBox5.SelectedItem = rd["Mays"].ToString();
                comboBox6.SelectedItem = rd["Haziran"].ToString();
                comboBox7.SelectedItem = rd["Temmuz"].ToString();
                comboBox8.SelectedItem = rd["Agustos"].ToString();
                comboBox9.SelectedItem = rd["Eylul"].ToString();
                comboBox10.SelectedItem = rd["Ekim"].ToString();
                comboBox11.SelectedItem = rd["Kasim"].ToString();
                comboBox12.SelectedItem = rd["Aralik"].ToString();
                label13.Text = rd["Ad"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myCconnection.Close();
            }
            
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sqlUpdate = "UPDATE `aidatlar` SET `Ocak`='" + comboBox1.Text + "',`Subat`='" + comboBox2.Text + "',`Mart`='" + comboBox3.Text + "',`Nisan`='" + comboBox4.Text + "',`Mays`='" + comboBox5.Text + "',`Haziran`='" + comboBox6.Text + "',`Temmuz`='" + comboBox7.Text + "',`Agustos`='" + comboBox8.Text + "',`Eylul`='" + comboBox9.Text + "',`Ekim`='" + comboBox10.Text + "',`Kasim`='" + comboBox11.Text + "',`Aralik`='" + comboBox12.Text + "' WHERE Id = '" + listItem.Text + "'";
            //UPDATE `aidatlar` SET `Ocak`='[value-4]',`Subat`='[value-5]',`Mart`='[value-6]',`Nisan`='[value-7]',`Mays`='[value-8]',`Haziran`='[value-9]',`Temmuz`='[value-10]',`Agustos`='[value-11]',`Eylul`='[value-12]',`Ekim`='[value-13]',`Kasim`='[value-14]',`Aralik`='[value-15]' WHERE KAd = 
            try
            {
                myCconnection.Open();
                MySqlCommand command = new MySqlCommand(sqlUpdate, myCconnection);
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myCconnection.Close();
                Kiracilar kiracilar = new Kiracilar();
                kiracilar.showInformation();
                this.Hide();

            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label13_Click(object sender, EventArgs e)
        {

        }

       
        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

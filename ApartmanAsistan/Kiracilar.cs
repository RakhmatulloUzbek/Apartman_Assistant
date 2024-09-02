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

namespace ApartmanAsistan
{
    public partial class Kiracilar : Form
    {

        
        MySqlConnection myCconnection = new MySqlConnection("server=localhost;database=finalproje;uid=root;pwd=\"\";");

        public void showInformation()
        {
            listView1.Items.Clear();
            try
            {
                myCconnection.Open();
                MySqlCommand command = new MySqlCommand("Select Id,Ad,Soyad,Cep,Daire_No from sakinler order by Id", myCconnection);
                MySqlDataReader rd = command.ExecuteReader();
                
                while (rd.Read())
                {
                    ListViewItem addNew = new ListViewItem();
                    addNew.Text = rd["Id"].ToString();
                    addNew.SubItems.Add(rd["Ad"].ToString());
                    addNew.SubItems.Add(rd["Soyad"].ToString());
                    addNew.SubItems.Add(rd["Cep"].ToString());
                    addNew.SubItems.Add(rd["Daire_No"].ToString());
                    listView1.Items.Add(addNew);
                }
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
        private void deleteAidat()
        {
            try
            {
                myCconnection.Open();                 
                foreach (ListViewItem item in listView1.CheckedItems)
                {
                    string sqlAidat = "DELETE FROM `aidatlar` WHERE KId = '" + item.Text + "'";
                    MySqlCommand command = new MySqlCommand(sqlAidat, myCconnection);
                    command.ExecuteNonQuery();
                            
                }
                    
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
        private void deleteRecord()
        {
            try
            {
                if (listView1.CheckedItems.Count > 0)
                {
                    DialogResult dialog = MessageBox.Show("  Silmek istediğiniz kaitlar \nAidat tablosundan da silinecektir.!", "Deleting", MessageBoxButtons.YesNo);

                    if (dialog == DialogResult.Yes)
                    {
                        deleteAidat();
                        myCconnection.Open();
                        foreach (ListViewItem item in listView1.CheckedItems)
                        {
                            string sqlText = "DELETE FROM `sakinler` WHERE Id = '" + item.Text + "'";
                            MySqlCommand command = new MySqlCommand(sqlText, myCconnection);
                            command.ExecuteNonQuery();
                        }
                    }

                }
                else
                    MessageBox.Show("Lütfen silmek istediğiniz kaydı seçin.!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myCconnection.Close();
                showInformation();
            }
            
        }
        public Kiracilar()
        {
            InitializeComponent();
        }

        private void bunifuGradientPanel3_Click(object sender, EventArgs e)
        {

        }

        private void Kiracilar_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.pictureBox1, "Yenileme");
            showInformation();
            bunifuThinButton22.IdleForecolor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewRecord newRecord = new NewRecord();
            newRecord.ShowDialog();
            newRecord.Focus();
            newRecord = null;
            this.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteRecord();
        }

        private void Kiracilar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            showInformation();
        }


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Anasayfa Obj = new Anasayfa();
            Obj.Show();
            this.Hide();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Aidat Obj = new Aidat();
            Obj.Show();
            this.Hide();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
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

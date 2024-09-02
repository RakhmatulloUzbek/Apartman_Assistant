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
    public partial class Aidat : Form
    {
        
        //Anasayfa an = new Anasayfa();
       
        DateTime dt = DateTime.Now;
        MySqlConnection myCconnection = new MySqlConnection("server=localhost;database=finalproje;uid=root;pwd=\"\";");
       
        public Aidat()
        {
            InitializeComponent();
        }

        private void Aidat_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(this.pictureBox1, "Yenile");
            bunifuThinButton23.IdleForecolor = Color.White;
            string yil = dt.Year.ToString();
            if (!(comboBox1.Items.Contains("yil")))
                comboBox1.Items.Add(yil);
            comboBox1.SelectedItem = yil;
            showInformation();
        }
        public void showInformation()
        {
            label2.Text = comboBox1.SelectedItem.ToString();
            listView1.Items.Clear();
            try
            {
                myCconnection.Open();
                MySqlCommand command = new MySqlCommand("Select a.Id,Ad,Ocak,Subat,Mart,Nisan,Mays,Haziran,Temmuz,Agustos,Eylul,Ekim,Kasim,Aralik from aidatlar a JOIN sakinler s on(a.KId=s.Id) Where Tarih = '" + label2.Text+"'", myCconnection);
                MySqlDataReader rd = command.ExecuteReader();
                

                while (rd.Read())
                {

                    ListViewItem addNew = new ListViewItem();
                    addNew.UseItemStyleForSubItems = false;
                    addNew.Text = rd["Id"].ToString();
                    addNew.SubItems.Add(rd["Ad"].ToString());
                    addNew.SubItems.Add(rd["Ocak"].ToString());
                    addNew.SubItems.Add(rd["Subat"].ToString());
                    addNew.SubItems.Add(rd["Mart"].ToString());
                    addNew.SubItems.Add(rd["Nisan"].ToString());
                    addNew.SubItems.Add(rd["Mays"].ToString());
                    addNew.SubItems.Add(rd["Haziran"].ToString());
                    addNew.SubItems.Add(rd["Temmuz"].ToString());
                    addNew.SubItems.Add(rd["Agustos"].ToString());
                    addNew.SubItems.Add(rd["Eylul"].ToString());
                    addNew.SubItems.Add(rd["Ekim"].ToString());
                    addNew.SubItems.Add(rd["Kasim"].ToString());
                    addNew.SubItems.Add(rd["Aralik"].ToString());

                    //tablodaki kutucukları renklendirme
                    for (int i = 0; i < addNew.SubItems.Count; i++)
                    {

                        if (addNew.SubItems[i].Text == "Yes")
                        {
                            addNew.SubItems[i].BackColor = Color.Green;
                        }
                        else
                            addNew.SubItems[i].BackColor = Color.Red;
                    }
                    addNew.SubItems[0].ForeColor = Color.FromArgb(153, 180, 209);
                    addNew.SubItems[0].BackColor = Color.FromArgb(153, 180, 209);
                    addNew.SubItems[1].BackColor = Color.FromArgb(153, 180, 209);
                    
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            showInformation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateAidat updateAidat = new UpdateAidat();
            if (listView1.CheckedItems.Count < 1 || listView1.CheckedItems.Count > 1)
                MessageBox.Show("Lütfen bir tane kayıt seçin.!");
            else
            {
                updateAidat.listItem = listView1.CheckedItems[0];
                updateAidat.ShowDialog();
                updateAidat.Focus();
                this.Show();
            }
            showInformation();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Kiracilar Obj = new Kiracilar();
            Obj.Show();
            this.Hide();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            showInformation();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}

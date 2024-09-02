using MySql.Data.MySqlClient;
using System;
using System.Collections;
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

    public partial class NewRecord : Form
    {
        private string RecordId;
        MySqlConnection myConnection = new MySqlConnection("server=localhost;database=finalproje;uid=root;pwd=\"\";");
        DateTime dt = DateTime.Now;
        public NewRecord()
        {
            InitializeComponent();
        }
        private void reseting()
        {
            Ad.Clear();
            Soyad.Clear();
            Cep_Telefon.Clear();
            Mail.Clear();
            Daire_No.DropDownStyle = ComboBoxStyle.DropDown;
            Blok.DropDownStyle = ComboBoxStyle.DropDown;
            Sahiblik.DropDownStyle = ComboBoxStyle.DropDown;
            Daire_No.ResetText();
            Blok.ResetText();
            Sahiblik.ResetText();
            Daire_No.DropDownStyle = ComboBoxStyle.DropDownList;
            Blok.DropDownStyle = ComboBoxStyle.DropDownList;
            Sahiblik.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            reseting();
            this.Hide();
        }

        private void NewRecord_Load(object sender, EventArgs e)
        {
            
        }
        //bool CheckTextBox(var tb)
        //{
        //        if (string.IsNullOrEmpty(tb.Text))
        //        {
        //            MessageBox.Show(tb.Name + "doldurulması zorunlu.!");
        //            return false;
        //        }
        //    return true;
        //}
        private void getLastRecordId()
        {
            try
            {
                myConnection.Open();
                MySqlCommand command = new MySqlCommand("Select Id from sakinler order by Id DESC limit 1", myConnection);
                MySqlDataReader rd = command.ExecuteReader();
                rd.Read();
                RecordId = rd["Id"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }
         
        private void inserAidat()
        {
            try
            {
                getLastRecordId();
                myConnection.Open();
                string sqlAidat = "INSERT INTO `aidatlar`(`KId`, `Tarih`) VALUES ('" + RecordId + "','" + dt.Year.ToString() + "')";
                MySqlCommand command = new MySqlCommand(sqlAidat, myConnection);
                command.ExecuteNonQuery();
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }
        private void insertNewRecord()
        {
            if (Ad.Text != "" && Soyad.Text != "" && Cep_Telefon.Text != "" && Mail.Text != "" && Daire_No.Text != "" && Blok.Text != "" && Sahiblik.Text != "")
            {
                try
                {
                    myConnection.Open();
                    string sqlText = "INSERT INTO `sakinler`(`Ad`, `Soyad`, `Cep`, `Mail`, `Daire_No`,`APT_No`, `Blok`, `Sahiblik`) VALUES ('" + Ad.Text + "','" + Soyad.Text + "','" + Cep_Telefon.Text + "','" + Mail.Text + "','" + Daire_No.Text + "','" + APT_No.Text + "','" + Blok.Text + "','" + Sahiblik.Text + "')";
                    MySqlCommand command = new MySqlCommand(sqlText, myConnection);
                    command.ExecuteNonQuery();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    myConnection.Close();
                    reseting();
                    inserAidat();
                    Kiracilar k = new Kiracilar();
                    this.Hide();
                    k.showInformation();
                }
            }
            else
                MessageBox.Show("Kutucuklar boş olamaz.!");
            
            
            

        }
        private void button2_Click(object sender, EventArgs e)
        {
            insertNewRecord();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Ad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

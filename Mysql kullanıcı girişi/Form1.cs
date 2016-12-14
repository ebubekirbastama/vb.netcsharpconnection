using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Mysql_kullanıcı_girişi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=kutuphane;Uid=root;Pwd=Şifreyi gir");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                    MySqlCommand kmt = new MySqlCommand("kgirisi", con);
                    kmt.CommandType = CommandType.StoredProcedure;//Procedurumuzu tanıtıyoruz.
                    kmt.Parameters.AddWithValue("ytkl_ism", textBox1.Text);//Parametreleri giriyoruz.
                kmt.Parameters.AddWithValue("ytkl_sf", textBox2.Text);//Parametreleri giriyoruz.
                con.Open();
                int sonuc = (int)kmt.ExecuteScalar();
                con.Close();

                if (sonuc == 1)
                {
                    ANMENU anm = new ANMENU();
                    anm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Kullanıcı yanlış", "www.ebubekirbastama.com");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "www.ebubekirbastama.com");
            }
        }     
    }
}

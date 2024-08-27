using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_
{
    public partial class Form9 : Form
    {
        // Veritabanı bağlantı dizesi
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\frtgn\\OneDrive\\Masaüstü\\Kutuphane_\\Kutuphane_\\bin\\x64\\Debug\\kullanici.accdb;";

        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TextBox ve DateTimePicker'lardan veri al
            string uadi = textBox1.Text;
            string usoy = textBox2.Text;
            string uno = textBox3.Text;
            string kadi = textBox4.Text;
            string kno = textBox5.Text;
            DateTime kdate = dateTimePicker1.Value;

            // Veritabanına veri ekleme sorgusu
            string query = "INSERT INTO exit (uadi, usoy, uno, kadi, kno, kdate) VALUES (?, ?, ?, ?, ?, ?)";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@uadi", uadi);
                    command.Parameters.AddWithValue("@usoy", usoy);
                    command.Parameters.AddWithValue("@uno", uno);
                    command.Parameters.AddWithValue("@kadi", kadi);
                    command.Parameters.AddWithValue("@kno", kno);
                    command.Parameters.AddWithValue("@kdate", kdate);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Veriler başarıyla kaydedildi.");
                    }
                    else
                    {
                        MessageBox.Show("Veri kaydedilemedi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); // Form6'ü kapatır

        }
    }
}

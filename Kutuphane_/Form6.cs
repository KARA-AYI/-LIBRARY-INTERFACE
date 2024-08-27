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
    public partial class Form6 : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\frtgn\OneDrive\Masaüstü\Kutuphane_\Kutuphane_\bin\x64\Debug\kullanici.accdb";

        public Form6()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            // Veritabanı bağlantısı oluştur
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL sorgusu oluştur
                    string query = "INSERT INTO members (uadi, usoy, uyas, ucins, utc, utel , uno) VALUES (?, ?, ?, ?, ?, ?, ?)";

                    // Komut oluştur
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@uadi", textBox1.Text ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@usoy", textBox2.Text ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@uyas", textBox3.Text ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ucins", textBox4.Text ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@utc", textBox5.Text ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@utel", textBox6.Text ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@uno", textBox7.Text ?? (object)DBNull.Value);

                        // Komutu çalıştır
                        int result = command.ExecuteNonQuery();

                        // Başarı durumunu kontrol et
                        if (result > 0)
                        {
                            MessageBox.Show("Kayıt başarılı!");
                        }
                        else
                        {
                            MessageBox.Show("Kayıt başarısız!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            // Tüm TextBox'ların içeriğini temizle
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close(); // Form6'ü kapatır

        }
    }
}

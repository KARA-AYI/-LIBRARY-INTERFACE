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
    public partial class Form3 : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\frtgn\OneDrive\Masaüstü\Kutuphane_\Kutuphane_\bin\x64\Debug\kullanici.accdb";

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Veritabanı bağlantısı oluştur
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL sorgusu oluştur
                    string query = "INSERT INTO Books (kadi, ksayfa, kyazar, kbasim, kategori, kno) VALUES (?, ?, ?, ?, ?, ?)";

                    // Komut oluştur
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@kadi", textBox1.Text);
                        command.Parameters.AddWithValue("@ksayfa", textBox2.Text);
                        command.Parameters.AddWithValue("@kyazar", textBox3.Text);
                        command.Parameters.AddWithValue("@kbasim", textBox4.Text);
                        command.Parameters.AddWithValue("@kategori", textBox5.Text);
                        command.Parameters.AddWithValue("@kno", textBox6.Text);

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

        private void button2_Click(object sender, EventArgs e)
        {
            // Tüm TextBox'ların içeriğini temizle
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); // Form3'ü kapatır

        }
    }
}

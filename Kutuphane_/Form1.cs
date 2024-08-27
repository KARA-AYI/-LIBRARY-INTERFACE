using Kutuphane_;
using System;
using System.Data.OleDb;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kutuphane_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Access veritabanı bağlantı dizesi
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\frtgn\OneDrive\Masaüstü\Kutuphane_\Kutuphane_\bin\x64\Debug\kullanici.accdb";

            // Bağlantıyı açıyoruz

            try
            {
                // Bağlantıyı açıyoruz
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Kullanıcı adı ve şifreyi kontrol eden SQL sorgusu
                    string query = "SELECT COUNT(*) FROM Users  WHERE adi = ? AND sifre = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Sorguya parametreler ekliyoruz
                        command.Parameters.AddWithValue("@adi", textBox1.Text);
                        command.Parameters.AddWithValue("@sifre", textBox2.Text);

                        // Sorguyu çalıştırıp sonucu alıyoruz
                        int result = (int)command.ExecuteScalar();

                        // Sonuç 1 ise, bilgilerin doğru olduğunu kabul ediyoruz
                        if (result == 1)
                        {
                            // Form1'i gizleyip Form2'yi gösteriyoruz
                            this.Hide();
                            Form2 form2 = new Form2();
                            form2.Show();
                        }
                        else
                        {
                            // Yanlış bilgi girilirse hata mesajı gösteriyoruz
                            MessageBox.Show("Kullanıcı adı veya şifre yanlış.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Bağlantı sırasında bir hata olursa bunu yakalayıp mesaj gösteriyoruz
                MessageBox.Show("Veritabanı bağlantısı sırasında bir hata oluştu: " + ex.Message);
            }
        }
    }
}


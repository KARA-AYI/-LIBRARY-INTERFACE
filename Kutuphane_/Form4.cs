using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Kutuphane_
{
    public partial class Form4 : Form
    {
        // Veritabanı bağlantı dizesi - Veritabanı yolunu doğru bir şekilde belirtin.
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\frtgn\\OneDrive\\Masaüstü\\Kutuphane_\\Kutuphane_\\bin\\x64\\Debug\\kullanici.accdb;";

        public Form4()
        {
            InitializeComponent();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); // Form4'ü kapatır
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kadi = textBox1.Text;
            string ksayfa = textBox2.Text;
            string kyazar = textBox3.Text;
            string kbasim = textBox4.Text;
            string kategori = textBox5.Text;
            string kno = textBox6.Text;

            // SQL sorgusu hazırlama
            string query = "SELECT * FROM books WHERE " +
                           "kadi LIKE @kadi AND " +
                           "ksayfa LIKE @ksayfa AND " +
                           "kyazar LIKE @kyazar AND " +
                           "kbasim LIKE @kbasim AND " +
                           "kategori LIKE @kategori AND " +
                           "kno LIKE @kno";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@kadi", "%" + kadi + "%");
                command.Parameters.AddWithValue("@ksayfa", "%" + ksayfa + "%");
                command.Parameters.AddWithValue("@kyazar", "%" + kyazar + "%");
                command.Parameters.AddWithValue("@kbasim", "%" + kbasim + "%");
                command.Parameters.AddWithValue("@kategori", "%" + kategori + "%");
                command.Parameters.AddWithValue("@kno", "%" + kno + "%");

                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Seçili satırın olup olmadığını kontrol et
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçili satırı al
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string kno = selectedRow.Cells["kno"].Value.ToString();

                // Silme sorgusu
                string deleteQuery = "DELETE FROM books WHERE kno = @kno";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@kno", kno);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Silme başarılı!");
                            // Silme işleminden sonra DataGridView'i güncelle
                            button1_Click(sender, e); // button1_Click ile güncellenmiş verileri tekrar yükleyin
                        }
                        else
                        {
                            MessageBox.Show("Silme başarısız!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Önce bir satır seçin.");
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string kadi = textBox1.Text;
                string ksayfa = textBox2.Text;
                string kyazar = textBox3.Text;
                string kbasim = textBox4.Text;
                string kategori = textBox5.Text;
                string kno = textBox6.Text;

                // Güncelleme sorgusu
                string updateQuery = "UPDATE books SET " +
                                     "kadi = @kadi, " +
                                     "ksayfa = @ksayfa, " +
                                     "kyazar = @kyazar, " +
                                     "kbasim = @kbasim, " +
                                     "kategori = @kategori " +
                                     "WHERE kno = @kno";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@kadi", kadi);
                    command.Parameters.AddWithValue("@ksayfa", ksayfa);
                    command.Parameters.AddWithValue("@kyazar", kyazar);
                    command.Parameters.AddWithValue("@kbasim", kbasim);
                    command.Parameters.AddWithValue("@kategori", kategori);
                    command.Parameters.AddWithValue("@kno", kno);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Güncelleme başarılı!");
                            // Güncellenen bilgileri DataGridView'e yeniden yükleyin
                            button1_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme başarısız!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Önce bir satır seçin.");
            }
        }

      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["kadi"].Value.ToString();
                textBox2.Text = row.Cells["ksayfa"].Value.ToString();
                textBox3.Text = row.Cells["kyazar"].Value.ToString();
                textBox4.Text = row.Cells["kbasim"].Value.ToString();
                textBox5.Text = row.Cells["kategori"].Value.ToString();
                textBox6.Text = row.Cells["kno"].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Tüm TextBox'ların içeriğini temizle
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
}

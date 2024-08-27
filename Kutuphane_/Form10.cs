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
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kutuphane_
{
    public partial class Form10 : Form
    {
        // Veritabanı bağlantı dizesi - Veritabanı yolunu doğru bir şekilde belirtin.
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\frtgn\\OneDrive\\Masaüstü\\Kutuphane_\\Kutuphane_\\bin\\x64\\Debug\\kullanici.accdb;";

        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uadi = textBox1.Text;
            string usoy = textBox2.Text;
            string uno = textBox3.Text;
            string kadi = textBox4.Text;
            string kno = textBox5.Text;
            string kdate = dateTimePicker1.Text;

            // SQL sorgusu hazırlama
            string query = "SELECT * FROM exit WHERE " +
                           "uadi LIKE @uadi AND " +
                           "usoy LIKE @usoy AND " +
                           "uno LIKE @uno AND " +
                           "kadi LIKE @kadi AND " +
                           "kno LIKE @kno AND " +
                           "kdate LIKE @kdate";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@uadi", "%" + uadi + "%");
                command.Parameters.AddWithValue("@usoy", "%" + usoy + "%");
                command.Parameters.AddWithValue("@uno", "%" + uno + "%");
                command.Parameters.AddWithValue("@kadi", "%" + kadi + "%");
                command.Parameters.AddWithValue("@kno", "%" + kno + "%");
                command.Parameters.AddWithValue("@kdate", "%" + kdate + "%");

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

        private void button4_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string uadi = textBox1.Text;
                string usoy = textBox2.Text;
                string uno = textBox3.Text;
                string kadi = textBox4.Text;
                string kno = textBox5.Text;
                string kdate = dateTimePicker1.Text;
                // Güncelleme sorgusu
                string updateQuery = "UPDATE* FROM exit WHERE " +
                           "uadi LIKE @uadi AND " +
                           "usoy LIKE @usoy AND " +
                           "WHERE uno LIKE @uno AND " +
                           "kadi LIKE @kadi AND " +
                           "kno LIKE @kno AND " +
                           "kdate LIKE @kdate";
              

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@uadi", "%" + uadi + "%");
                    command.Parameters.AddWithValue("@usoy", "%" + usoy + "%");
                    command.Parameters.AddWithValue("@uno", "%" + uno + "%");
                    command.Parameters.AddWithValue("@kadi", "%" + kadi + "%");
                    command.Parameters.AddWithValue("@kno", "%" + kno + "%");
                    command.Parameters.AddWithValue("@kdate", "%" + kdate + "%");

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

        private void button5_Click(object sender, EventArgs e)
        {
            // Tüm TextBox'ların içeriğini temizle
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Text = "";
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
                string deleteQuery = "DELETE FROM exit WHERE uno = @uno";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@uno", kno);

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); // Form4'ü kapatır

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["uadi"].Value.ToString();
                textBox2.Text = row.Cells["usoy"].Value.ToString();
                textBox3.Text = row.Cells["uno"].Value.ToString();
                textBox4.Text = row.Cells["kadi"].Value.ToString();
                textBox5.Text = row.Cells["kno"].Value.ToString();
                dateTimePicker1.Text = row.Cells["kdate"].Value.ToString();
            }
        }
    }
    }

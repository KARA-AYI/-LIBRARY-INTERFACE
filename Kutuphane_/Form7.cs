using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Kutuphane_
{
    public partial class Form7 : Form
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\frtgn\\OneDrive\\Masaüstü\\Kutuphane_\\Kutuphane_\\bin\\x64\\Debug\\kullanici.accdb;";

        public Form7()
        {
            InitializeComponent();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uadi = textBox1.Text;
            string usoy = textBox2.Text;
            string uyas = textBox3.Text;
            string ucins = textBox4.Text;
            string utc = textBox5.Text;
            string utel = textBox6.Text;
            string uno = textBox7.Text;

            string query = "SELECT * FROM members WHERE " +
                           "uadi LIKE ? AND " +
                           "usoy LIKE ? AND " +
                           "uyas LIKE ? AND " +
                           "ucins LIKE ? AND " +
                           "utc LIKE ? AND " +
                           "utel LIKE ? AND " +
                           "uno LIKE ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("?", "%" + uadi + "%");
                command.Parameters.AddWithValue("?", "%" + usoy + "%");
                command.Parameters.AddWithValue("?", "%" + uyas + "%");
                command.Parameters.AddWithValue("?", "%" + ucins + "%");
                command.Parameters.AddWithValue("?", "%" + utc + "%");
                command.Parameters.AddWithValue("?", "%" + utel + "%");
                command.Parameters.AddWithValue("?", "%" + uno + "%");

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["uadi"].Value.ToString();
                textBox2.Text = row.Cells["usoy"].Value.ToString();
                textBox3.Text = row.Cells["uyas"].Value.ToString();
                textBox4.Text = row.Cells["ucins"].Value.ToString();
                textBox5.Text = row.Cells["utc"].Value.ToString();
                textBox6.Text = row.Cells["utel"].Value.ToString();
                textBox7.Text = row.Cells["uno"].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string uadi = selectedRow.Cells["uadi"].Value.ToString();

                string deleteQuery = "DELETE FROM members WHERE uadi = ?";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("?", uadi);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Silme başarılı!");
                            button1_Click(sender, e); // Güncellenmiş verileri tekrar yükleyin
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string uadi = textBox1.Text;
                string usoy = textBox2.Text;
                string uyas = textBox3.Text;
                string ucins = textBox4.Text;
                string utc = textBox5.Text;
                string utel = textBox6.Text;
                string uno = textBox7.Text;

                string updateQuery = "UPDATE members SET " +
                                     "usoy = ?, " +
                                     "uyas = ?, " +
                                     "ucins = ?, " +
                                     "utc = ?, " +
                                     "utel = ?, " +
                                     "uno = ? " +
                                     "WHERE uadi = ?";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("?", usoy);
                    command.Parameters.AddWithValue("?", uyas);
                    command.Parameters.AddWithValue("?", ucins);
                    command.Parameters.AddWithValue("?", utc);
                    command.Parameters.AddWithValue("?", utel);
                    command.Parameters.AddWithValue("?", uno);
                    command.Parameters.AddWithValue("?", uadi);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Güncelleme başarılı!");
                            button1_Click(sender, e); // Güncellenmiş verileri tekrar yükleyin
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close(); // Form7'yi kapatır
        }
    }
}

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
    public partial class Form11 : Form
    {
        // Veritabanı bağlantı dizesi - Veritabanı yolunu doğru bir şekilde belirtin.
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\frtgn\\OneDrive\\Masaüstü\\Kutuphane_\\Kutuphane_\\bin\\x64\\Debug\\kullanici.accdb;";

        public Form11()
        {
            InitializeComponent();
            LoadDataIntoDataGridView();
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }

        private void LoadDataIntoDataGridView()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT uadi, usoy, uno, kadi, kno, kdate FROM exit";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                    // kdate sütununu en başa taşı
                    dataGridView1.Columns["kdate"].DisplayIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "kdate") // Tarih kolonu
            {
                DateTime kdate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["kdate"].Value);
                TimeSpan timeSpan = DateTime.Now - kdate;

                if (timeSpan.Days > 15)
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red; // 15 günü geçtiyse kırmızı
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green; // 15 gün dolmadıysa yeşil
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); // Form6'ü kapatır

        }
    }
}

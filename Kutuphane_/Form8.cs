using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Kutuphane_
{
    public partial class Form8 : Form
    {
        // Veritabanı bağlantı dizesi
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\frtgn\\OneDrive\\Masaüstü\\Kutuphane_\\Kutuphane_\\bin\\x64\\Debug\\kullanici.accdb;";

        public Form8()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form8_Load);
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // ListView kolonlarını ayarla
            listView1.Columns.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            // ListView boyutunu ayarla veya ihtiyaç duyduğunuz gibi ayarlayın
            listView1.Size = new System.Drawing.Size(316, 418); // Genişliği ihtiyaçlarınıza göre ayarlayın

            listView1.Columns.Add("İSİM", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("SOYİSİM", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("YAŞI", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("CİNSİYET", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("TC. NO", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("TEL. NO", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("ÜYE NUMARASI", 50, HorizontalAlignment.Left);

            // Veritabanındaki verileri ListView'e yükle
            LoadDataIntoListView();
        }

        private void LoadDataIntoListView()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Members"; // Tablo adı "Members" olarak güncellendi.
                    OleDbCommand command = new OleDbCommand(query, connection);
                    OleDbDataReader reader = command.ExecuteReader();

                    listView1.Items.Clear(); // Önceki verileri temizle

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["uadi"].ToString());
                        item.SubItems.Add(reader["usoy"].ToString());
                        item.SubItems.Add(reader["uyas"].ToString());
                        item.SubItems.Add(reader["ucins"].ToString());
                        item.SubItems.Add(reader["utc"].ToString());
                        item.SubItems.Add(reader["utel"].ToString());
                        item.SubItems.Add(reader["uno"].ToString());

                        listView1.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                // Seçili öğedeki verileri kullanarak gerekli işlemleri yapabilirsiniz.
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); // Form8'i kapatır
        }
    }
}

using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Kutuphane_
{
    public partial class Form5 : Form
    {
        // Veritabanı bağlantı dizesi
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\frtgn\\OneDrive\\Masaüstü\\Kutuphane_\\Kutuphane_\\bin\\x64\\Debug\\kullanici.accdb;";

        public Form5()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form5_Load);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // ListView kolonlarını ayarla
            listView1.Columns.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Size = new System.Drawing.Size(316, 418);

            listView1.Columns.Add("KİTAP NO", 35, HorizontalAlignment.Left);
            listView1.Columns.Add("İSİM", 250, HorizontalAlignment.Left);
            listView1.Columns.Add("SAYFA", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("YAZAR", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("BASIMEVİ", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("KATEGORİ", 80, HorizontalAlignment.Left);

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
                    string query = "SELECT * FROM Books"; // Tablo adı "Books" olarak güncellendi.
                    OleDbCommand command = new OleDbCommand(query, connection);
                    OleDbDataReader reader = command.ExecuteReader();

                    listView1.Items.Clear(); // Önceki verileri temizle

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["kno"].ToString());
                        item.SubItems.Add(reader["kadi"].ToString());
                        item.SubItems.Add(reader["ksayfa"].ToString());
                        item.SubItems.Add(reader["kyazar"].ToString());
                        item.SubItems.Add(reader["kbasim"].ToString());
                        item.SubItems.Add(reader["kategori"].ToString());

                        listView1.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        // listView1_SelectedIndexChanged olayı için olay işleyicisi
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Bu olay işleyici, ListView'deki seçili öğe değiştiğinde çalışır.
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                // Seçili öğedeki verileri kullanarak gerekli işlemleri yapabilirsiniz.
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); // Form5 ü kapatır

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Form3'ü oluşturun
            Form3 form3 = new Form3();

            // Form3'ü MDI child olarak ayarlayın
            form3.MdiParent = this;

            // Form3'ün konumunu manuel olarak ayarlayın
            form3.StartPosition = FormStartPosition.Manual;

            // Form2 üzerinde Form3'ün konumunu ayarlayın (Örneğin, 100, 100)
            form3.Location = new Point(451, 6);

            // Form3'ü gösterin
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            Form4 form4 = new Form4();

             form4.MdiParent = this;

             form4.StartPosition = FormStartPosition.Manual;

             form4.Location = new Point(451, 6);

             form4.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();

            form5.MdiParent = this;

            form5.StartPosition = FormStartPosition.Manual;

            form5.Location = new Point(451, 6);

            form5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();

            form6.MdiParent = this;

            form6.StartPosition = FormStartPosition.Manual;

            form6.Location = new Point(451, 6);

            form6.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();

            form7.MdiParent = this;

            form7.StartPosition = FormStartPosition.Manual;

            form7.Location = new Point(451, 6);

            form7.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();

            form8.MdiParent = this;

            form8.StartPosition = FormStartPosition.Manual;

            form8.Location = new Point(451, 6);

            form8.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();

            form9.MdiParent = this;

            form9.StartPosition = FormStartPosition.Manual;

            form9.Location = new Point(451, 6);

            form9.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();

            form10.MdiParent = this;

            form10.StartPosition = FormStartPosition.Manual;

            form10.Location = new Point(451, 6);

            form10.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();

            form11.MdiParent = this;

            form11.StartPosition = FormStartPosition.Manual;

            form11.Location = new Point(451, 6);

            form11.Show();
        }
    }
}

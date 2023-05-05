using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRAKTIKA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1(this).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form3(this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form4(this).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form5(this).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form6(this).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form7(this).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form8(this).Show();
        }
    }
}

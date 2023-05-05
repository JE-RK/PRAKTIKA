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
    public partial class Form6 : Form
    {
        Form2 form2;
        public Form6(Form2 form2)
        {
            this.form2 = form2;
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].HeaderText = "Номер группы";
            dataGridView1.Columns[1].HeaderText = "Название группы";
            using (ApplicationContext db = new ApplicationContext())
            {

                var gruppa = db.Gruppa_medikamentov.ToList();
                dataGridView1.RowCount = gruppa.Count;
                int index = 0;
                foreach (var item in gruppa)
                {
                    dataGridView1.Rows[index].Cells[0].Value = item.nomer_gruppy;
                    dataGridView1.Rows[index].Cells[1].Value = item.nazvaniye_gruppy;
                    index++;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            form2.Show();
        }
    }
}

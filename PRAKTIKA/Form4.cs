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
    public partial class Form4 : Form
    {
        Form2 form2;
        public Form4(Form2 form2)
        {
            this.form2 = form2;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            form2.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderText = "Номер должности";
            dataGridView1.Columns[1].HeaderText = "Название";
            dataGridView1.Columns[2].HeaderText = "Оклад";
            using (ApplicationContext db = new ApplicationContext())
            {
                var punkty = db.Dolzhnosti.ToList();
                dataGridView1.RowCount = punkty.Count;
                int index = 0;
                foreach (var item in punkty)
                {
                    dataGridView1.Rows[index].Cells[0].Value = item.nomer_dolzhnosti;
                    dataGridView1.Rows[index].Cells[1].Value = item.nazvaniye;
                    dataGridView1.Rows[index].Cells[2].Value = item.oklad;
                    index++;
                }
            }
            Object o = new Dolzhnosti(32 ,"", 2);
            Dolzhnosti dolzhnosti = (Dolzhnosti)o;
            
        }
    }
}

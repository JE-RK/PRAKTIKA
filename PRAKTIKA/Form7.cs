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
    public partial class Form7 : Form
    {
        Form2 form2;
        public Form7(Form2 form2)
        {
            this.form2 = form2;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            form2.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].HeaderText = "Номер медикамента";
            dataGridView1.Columns[1].HeaderText = "Номер группы";
            dataGridView1.Columns[2].HeaderText = "Название медикамента";
            dataGridView1.Columns[3].HeaderText = "Форма упаковки";
            dataGridView1.Columns[4].HeaderText = "Противопоказания";
            dataGridView1.Columns[5].HeaderText = "Дозировка";
            dataGridView1.Columns[6].HeaderText = "Стоимость медикамента";

            using (ApplicationContext db = new ApplicationContext())
            {
                var ap = db.Medikamenty.ToList();               
                foreach (var item in ap)
                {
                    comboBox2.Items.Add(item.nomer_medikamenta);
                }
                var medikamenty = db.Medikamenty.ToList();
                dataGridView1.RowCount = medikamenty.Count;
                int index = 0;
                foreach (var item in medikamenty)
                {
                    dataGridView1.Rows[index].Cells[0].Value = item.nomer_medikamenta;
                    dataGridView1.Rows[index].Cells[1].Value = item.nomer_gruppy;
                    dataGridView1.Rows[index].Cells[2].Value = item.nazvaniye_medikamenta;
                    dataGridView1.Rows[index].Cells[3].Value = item.forma_upakovki;
                    dataGridView1.Rows[index].Cells[4].Value = item.protivopokazaniya;
                    dataGridView1.Rows[index].Cells[5].Value = item.dozirovka;
                    dataGridView1.Rows[index].Cells[6].Value = item.stoimost_medikamenta;
                    index++;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    dataGridView1.Rows.Clear();
                    Medikamenty m = new Medikamenty(Convert.ToInt32(textBox6.Text), (int)comboBox2.SelectedItem, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToInt32(textBox5.Text));

                    db.Medikamenty.Add(m);
                    db.SaveChanges();
                    var medikamenty = db.Medikamenty.ToList();
                    dataGridView1.RowCount = medikamenty.Count;
                    int index = 0;
                    foreach (var item in medikamenty)
                    {
                        dataGridView1.Rows[index].Cells[0].Value = item.nomer_medikamenta;
                        dataGridView1.Rows[index].Cells[1].Value = item.nomer_gruppy;
                        dataGridView1.Rows[index].Cells[2].Value = item.nazvaniye_medikamenta;
                        dataGridView1.Rows[index].Cells[3].Value = item.forma_upakovki;
                        dataGridView1.Rows[index].Cells[4].Value = item.protivopokazaniya;
                        dataGridView1.Rows[index].Cells[5].Value = item.dozirovka;
                        dataGridView1.Rows[index].Cells[6].Value = item.stoimost_medikamenta;
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "An error occurred while updating the entries. See the inner exception for details.")
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        dataGridView1.Rows.Clear();
                        var medikamenty = db.Medikamenty.ToList();
                        foreach (var item in medikamenty)
                        {
                            if (item.nomer_medikamenta == Convert.ToInt32(textBox6.Text))
                            {
                                item.nomer_gruppy = (int)comboBox2.SelectedItem;
                                item.nazvaniye_medikamenta = textBox1.Text;
                                item.forma_upakovki = textBox2.Text;
                                item.protivopokazaniya = textBox3.Text;
                                item.dozirovka = textBox4.Text;
                                item.stoimost_medikamenta = Convert.ToInt32(textBox5.Text);
                                db.Update(item);
                                db.SaveChanges();
                                break;
                            }
                        }
                        dataGridView1.RowCount = medikamenty.Count;
                        int index = 0;
                        foreach (var item in medikamenty)
                        {
                            dataGridView1.Rows[index].Cells[0].Value = item.nomer_medikamenta;
                            dataGridView1.Rows[index].Cells[1].Value = item.nomer_gruppy;
                            dataGridView1.Rows[index].Cells[2].Value = item.nazvaniye_medikamenta;
                            dataGridView1.Rows[index].Cells[3].Value = item.forma_upakovki;
                            dataGridView1.Rows[index].Cells[4].Value = item.protivopokazaniya;
                            dataGridView1.Rows[index].Cells[5].Value = item.dozirovka;
                            dataGridView1.Rows[index].Cells[6].Value = item.stoimost_medikamenta;
                            index++;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неправильный формат");
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var medikamenty = db.Medikamenty.ToList();
                        dataGridView1.RowCount = medikamenty.Count;
                        int index = 0;
                        foreach (var item in medikamenty)
                        {
                            dataGridView1.Rows[index].Cells[0].Value = item.nomer_medikamenta;
                            dataGridView1.Rows[index].Cells[1].Value = item.nomer_gruppy;
                            dataGridView1.Rows[index].Cells[2].Value = item.nazvaniye_medikamenta;
                            dataGridView1.Rows[index].Cells[3].Value = item.forma_upakovki;
                            dataGridView1.Rows[index].Cells[4].Value = item.protivopokazaniya;
                            dataGridView1.Rows[index].Cells[5].Value = item.dozirovka;
                            dataGridView1.Rows[index].Cells[6].Value = item.stoimost_medikamenta;
                            index++;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int str = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

            using (ApplicationContext db = new ApplicationContext())
            {
                dataGridView1.Rows.Clear();
                var medikamenty = db.Medikamenty.ToList();
                foreach (var item in medikamenty)
                {
                    if (item.nomer_medikamenta == str)
                    {
                        db.Medikamenty.Remove(item);
                        medikamenty.Remove(item);
                        db.SaveChanges();
                        break;
                    }
                }
                dataGridView1.RowCount = medikamenty.Count;
                int index = 0;
                foreach (var item in medikamenty)
                {
                    dataGridView1.Rows[index].Cells[0].Value = item.nomer_medikamenta;
                    dataGridView1.Rows[index].Cells[1].Value = item.nomer_gruppy;
                    dataGridView1.Rows[index].Cells[2].Value = item.nazvaniye_medikamenta;
                    dataGridView1.Rows[index].Cells[3].Value = item.forma_upakovki;
                    dataGridView1.Rows[index].Cells[4].Value = item.protivopokazaniya;
                    dataGridView1.Rows[index].Cells[5].Value = item.dozirovka;
                    dataGridView1.Rows[index].Cells[6].Value = item.stoimost_medikamenta;
                    index++;
                }
            }
        }
    }
}

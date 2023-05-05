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
    public partial class Form8 : Form
    {
        Form2 form2;
        public Form8(Form2 form2)
        {
            this.form2 = form2;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            form2.Show();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].HeaderText = "Номер продажи";
            dataGridView1.Columns[1].HeaderText = "Номер пункта";
            dataGridView1.Columns[2].HeaderText = "Номер медикамента";
            dataGridView1.Columns[3].HeaderText = "Количество";
            dataGridView1.Columns[4].HeaderText = "Номер клиента";
            dataGridView1.Columns[5].HeaderText = "Номер сотрудника";
            dataGridView1.Columns[6].HeaderText = "Дата продажи";
            dataGridView1.Columns[7].HeaderText = "Стоимость";

            

            using (ApplicationContext db = new ApplicationContext())
            {
                var ap = db.Aptechnyye_punkty.ToList();
                foreach (var item in ap)
                {
                    comboBox1.Items.Add(item.nomer_punkta);
                }

                var med = db.Medikamenty.ToList();
                foreach (var item in med)
                {
                    comboBox2.Items.Add(item.nomer_medikamenta);
                }

                var kliyenty = db.Kliyent.ToList();
                foreach (var item in med)
                {
                    comboBox3.Items.Add(item.nomer_medikamenta);
                }

                var sotr = db.Sotrudniki.ToList();
                foreach (var item in sotr)
                {
                    comboBox4.Items.Add(item.nomer_sotrudnika);
                }

                var p = db.Prodazha.ToList();
                dataGridView1.RowCount = p.Count;
                int index = 0;
                foreach (var item in p)
                {
                    dataGridView1.Rows[index].Cells[0].Value = item.nomer_prodazhi;
                    dataGridView1.Rows[index].Cells[1].Value = item.nomer_punkta;
                    dataGridView1.Rows[index].Cells[2].Value = item.nomer_medikamenta;
                    dataGridView1.Rows[index].Cells[3].Value = item.kolichestvo;
                    dataGridView1.Rows[index].Cells[4].Value = item.nomer_kliyenta;
                    dataGridView1.Rows[index].Cells[5].Value = item.nomer_sotrudnika;
                    dataGridView1.Rows[index].Cells[6].Value = item.data_prodazhi;
                    dataGridView1.Rows[index].Cells[7].Value = item.stoimost;
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
                    Prodazha p = new Prodazha(Convert.ToInt32(textBox1.Text), (int)comboBox1.SelectedItem, (int)comboBox2.SelectedItem, Convert.ToInt32(textBox2.Text), (int)comboBox3.SelectedItem, (int)comboBox4.SelectedItem, dateTimePicker1.Value, Convert.ToInt32(textBox3.Text));

                    db.Prodazha.Add(p);
                    db.SaveChanges();
                    var prod = db.Prodazha.ToList();
                    dataGridView1.RowCount = prod.Count;
                    int index = 0;
                    foreach (var item in prod)
                    {
                        dataGridView1.Rows[index].Cells[0].Value = item.nomer_prodazhi;
                        dataGridView1.Rows[index].Cells[1].Value = item.nomer_punkta;
                        dataGridView1.Rows[index].Cells[2].Value = item.nomer_medikamenta;
                        dataGridView1.Rows[index].Cells[3].Value = item.kolichestvo;
                        dataGridView1.Rows[index].Cells[4].Value = item.nomer_kliyenta;
                        dataGridView1.Rows[index].Cells[5].Value = item.nomer_sotrudnika;
                        dataGridView1.Rows[index].Cells[6].Value = item.data_prodazhi;
                        dataGridView1.Rows[index].Cells[7].Value = item.stoimost;
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
                        var prod = db.Prodazha.ToList();
                        foreach (var item in prod)
                        {
                            if (item.nomer_prodazhi == Convert.ToInt32(textBox1.Text))
                            {
                                item.nomer_punkta = (int)comboBox1.SelectedItem;
                                item.nomer_medikamenta = (int)comboBox2.SelectedItem;
                                item.kolichestvo = Convert.ToInt32(textBox2.Text);
                                item.nomer_kliyenta = (int)comboBox3.SelectedItem;
                                item.nomer_sotrudnika = (int)comboBox4.SelectedItem;
                                item.data_prodazhi = dateTimePicker1.Value;
                                item.stoimost = Convert.ToInt32(textBox3.Text);
                                db.Update(item);
                                db.SaveChanges();
                                break;
                            }
                        }
                        dataGridView1.RowCount = prod.Count;
                        int index = 0;
                        foreach (var item in prod)
                        {
                            dataGridView1.Rows[index].Cells[0].Value = item.nomer_prodazhi;
                            dataGridView1.Rows[index].Cells[1].Value = item.nomer_punkta;
                            dataGridView1.Rows[index].Cells[2].Value = item.nomer_medikamenta;
                            dataGridView1.Rows[index].Cells[3].Value = item.kolichestvo;
                            dataGridView1.Rows[index].Cells[4].Value = item.nomer_kliyenta;
                            dataGridView1.Rows[index].Cells[5].Value = item.nomer_sotrudnika;
                            dataGridView1.Rows[index].Cells[6].Value = item.data_prodazhi;
                            dataGridView1.Rows[index].Cells[7].Value = item.stoimost;
                            index++;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неправильный формат");
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var prod = db.Prodazha.ToList();
                        dataGridView1.RowCount = prod.Count;
                        int index = 0;
                        foreach (var item in prod)
                        {
                            dataGridView1.Rows[index].Cells[0].Value = item.nomer_prodazhi;
                            dataGridView1.Rows[index].Cells[1].Value = item.nomer_punkta;
                            dataGridView1.Rows[index].Cells[2].Value = item.nomer_medikamenta;
                            dataGridView1.Rows[index].Cells[3].Value = item.kolichestvo;
                            dataGridView1.Rows[index].Cells[4].Value = item.nomer_kliyenta;
                            dataGridView1.Rows[index].Cells[5].Value = item.nomer_sotrudnika;
                            dataGridView1.Rows[index].Cells[6].Value = item.data_prodazhi;
                            dataGridView1.Rows[index].Cells[7].Value = item.stoimost;
                            index++;
                        }
                    }
                }
            }
        }
    }
}

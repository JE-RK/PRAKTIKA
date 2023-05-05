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
    public partial class Form3 : Form
    {
        Form2 form2;
        public Form3(Form2 form2)
        {
            this.form2 = form2;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderText = "Номер пункта";
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Адрес";
            using (ApplicationContext db = new ApplicationContext())
            {
                var punkty = db.Aptechnyye_punkty.ToList();
                dataGridView1.RowCount = punkty.Count;
                int index = 0;
                foreach (var item in punkty)
                {
                    dataGridView1.Rows[index].Cells[0].Value = item.nomer_punkta;
                    dataGridView1.Rows[index].Cells[1].Value = item.naimenovaniye;
                    dataGridView1.Rows[index].Cells[2].Value = item.adres;
                    index++;
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    dataGridView1.Rows.Clear();
                    Aptechnyye_punkty ap = new Aptechnyye_punkty(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text);

                    db.Aptechnyye_punkty.Add(ap);
                    db.SaveChanges();
                    var punkty = db.Aptechnyye_punkty.ToList();
                    dataGridView1.RowCount = punkty.Count;
                    int index = 0;
                    foreach (var item in punkty)
                    {
                        dataGridView1.Rows[index].Cells[0].Value = item.nomer_punkta;
                        dataGridView1.Rows[index].Cells[1].Value = item.naimenovaniye;
                        dataGridView1.Rows[index].Cells[2].Value = item.adres;
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
                        var punkty = db.Aptechnyye_punkty.ToList();
                        foreach (var item in punkty)
                        {
                            if (item.nomer_punkta == Convert.ToInt32(textBox1.Text))
                            {
                                item.naimenovaniye = textBox2.Text;
                                item.adres = textBox3.Text;
                                db.Update(item);
                                db.SaveChanges();
                                break;
                            }
                        }
                        dataGridView1.RowCount = punkty.Count;
                        int index = 0;
                        foreach (var item in punkty)
                        {
                            dataGridView1.Rows[index].Cells[0].Value = item.nomer_punkta;
                            dataGridView1.Rows[index].Cells[1].Value = item.naimenovaniye;
                            dataGridView1.Rows[index].Cells[2].Value = item.adres;
                            index++;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неправильный формат");
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var punkty = db.Aptechnyye_punkty.ToList();
                        dataGridView1.RowCount = punkty.Count;
                        int index = 0;
                        foreach (var item in punkty)
                        {
                            dataGridView1.Rows[index].Cells[0].Value = item.nomer_punkta;
                            dataGridView1.Rows[index].Cells[1].Value = item.naimenovaniye;
                            dataGridView1.Rows[index].Cells[2].Value = item.adres;
                            index++;
                        }
                    }
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int str = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            textBox1.Text = str.ToString();
            
            using (ApplicationContext db = new ApplicationContext())
            {
                dataGridView1.Rows.Clear();
                var punkty = db.Aptechnyye_punkty.ToList();
                foreach (var item in punkty)
                {
                    if (item.nomer_punkta == str)
                    {
                        db.Aptechnyye_punkty.Remove(item);
                        punkty.Remove(item);
                        db.SaveChanges();
                        
                        break;
                    }
                }
                dataGridView1.RowCount = punkty.Count;
                int index = 0;
                foreach (var item in punkty)
                {
                    dataGridView1.Rows[index].Cells[0].Value = item.nomer_punkta;
                    dataGridView1.Rows[index].Cells[1].Value = item.naimenovaniye;
                    dataGridView1.Rows[index].Cells[2].Value = item.adres;
                    index++;
                }
            }
        }
    }
}

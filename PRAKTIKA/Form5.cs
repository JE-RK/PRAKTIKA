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
    public partial class Form5 : Form
    {
        Form2 form2;
        public Form5(Form2 form2)
        {
            this.form2 = form2;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            form2.Show();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].HeaderText = "Номер сотрудника";
            dataGridView1.Columns[1].HeaderText = "Номер пункта";
            dataGridView1.Columns[2].HeaderText = "Номер должности";
            dataGridView1.Columns[3].HeaderText = "ФИО";
            dataGridView1.Columns[4].HeaderText = "Дата рождения";
            dataGridView1.Columns[5].HeaderText = "Телефон";
            dataGridView1.Columns[6].HeaderText = "Адрес";
            using (ApplicationContext db = new ApplicationContext())
            {

                var ap = db.Aptechnyye_punkty.ToList();
                foreach (var item in ap)
                {
                    comboBox1.Items.Add(item.naimenovaniye);

                }
 
                var dol = db.Dolzhnosti.ToList();
                foreach (var item in dol)
                {
                    comboBox2.Items.Add(item.nazvaniye);
                    
                }
                
                var sotrudniki = db.Sotrudniki.ToList();
                dataGridView1.RowCount = sotrudniki.Count;

                int index = 0;
                foreach (var item in sotrudniki)
                {
                    dataGridView1.Rows[index].Cells[0].Value = item.nomer_sotrudnika;
                    
                    dataGridView1.Rows[index].Cells[1].Value = item.nomer_punkta;
                    dataGridView1.Rows[index].Cells[2].Value = item.nomer_dolzhnosti;
                    dataGridView1.Rows[index].Cells[3].Value = item.fio;
                    dataGridView1.Rows[index].Cells[4].Value = item.data_rozhdeniya;
                    dataGridView1.Rows[index].Cells[5].Value = item.telefon;
                    dataGridView1.Rows[index].Cells[6].Value = item.adres;
                    foreach (var item1 in ap)
                    {
                        if (item.nomer_punkta == item1.nomer_punkta)
                        {
                            dataGridView1.Rows[index].Cells[1].Value = item1.naimenovaniye;

                        }
                    }
                    foreach (var item2 in dol)
                    {
                        if (item.nomer_dolzhnosti == item2.nomer_dolzhnosti)
                        {
                            dataGridView1.Rows[index].Cells[2].Value = item2.nazvaniye;

                        }
                    }
                    index++;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox4.Text == null || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || textBox1.Text == null || textBox2.Text == null || textBox3.Text == null )
                {
                    throw new Exception();
                }
                using (ApplicationContext db = new ApplicationContext())
                {
                    string name = (string)comboBox1.SelectedItem;
                    string named = (string)comboBox2.SelectedItem;
                    var ap = db.Aptechnyye_punkty.ToList();
                    var dol = db.Dolzhnosti.ToList();
                    int id_p = 0;
                    int id_d = 0;
                    foreach (var item in ap)
                    {
                        if (name == item.naimenovaniye)
                        {
                            id_p = item.nomer_punkta;
                        }
                    }
                    foreach (var item in dol)
                    {
                        if (named == item.nazvaniye)
                        {
                            id_d = item.nomer_dolzhnosti;
                        }
                    }
                    dataGridView1.Rows.Clear();
                    Sotrudniki s = new Sotrudniki(Convert.ToInt32(textBox4.Text), id_p, id_d, textBox1.Text, dateTimePicker1.Value, textBox2.Text, textBox3.Text);

                    db.Sotrudniki.Add(s);
                    db.SaveChanges();
                    var sotr = db.Sotrudniki.ToList();
                    dataGridView1.RowCount = sotr.Count;
                    int index = 0;
                    foreach (var item in sotr)
                    {
                        dataGridView1.Rows[index].Cells[0].Value = item.nomer_sotrudnika;
                        dataGridView1.Rows[index].Cells[1].Value = item.nomer_punkta;
                        dataGridView1.Rows[index].Cells[2].Value = item.nomer_dolzhnosti;
                        dataGridView1.Rows[index].Cells[3].Value = item.fio;
                        dataGridView1.Rows[index].Cells[4].Value = item.data_rozhdeniya;
                        dataGridView1.Rows[index].Cells[5].Value = item.telefon;
                        dataGridView1.Rows[index].Cells[6].Value = item.adres;
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "An error occurred while updating the entries. See the inner exception for details.")
                {
                    MessageBox.Show("Объект с таким id уже существует");
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var sotrudniki = db.Sotrudniki.ToList();
                        dataGridView1.RowCount = sotrudniki.Count;
                        int index = 0;
                        foreach (var item in sotrudniki)
                        {
                            dataGridView1.Rows[index].Cells[0].Value = item.nomer_sotrudnika;
                            dataGridView1.Rows[index].Cells[1].Value = item.nomer_punkta;
                            dataGridView1.Rows[index].Cells[2].Value = item.nomer_dolzhnosti;
                            dataGridView1.Rows[index].Cells[3].Value = item.fio;
                            dataGridView1.Rows[index].Cells[4].Value = item.data_rozhdeniya;
                            dataGridView1.Rows[index].Cells[5].Value = item.telefon;
                            dataGridView1.Rows[index].Cells[6].Value = item.adres;
                            index++;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неправильный формат");
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var sotrudniki = db.Sotrudniki.ToList();
                        dataGridView1.RowCount = sotrudniki.Count;
                        int index = 0;
                        foreach (var item in sotrudniki)
                        {
                            dataGridView1.Rows[index].Cells[0].Value = item.nomer_sotrudnika;
                            dataGridView1.Rows[index].Cells[1].Value = item.nomer_punkta;
                            dataGridView1.Rows[index].Cells[2].Value = item.nomer_dolzhnosti;
                            dataGridView1.Rows[index].Cells[3].Value = item.fio;
                            dataGridView1.Rows[index].Cells[4].Value = item.data_rozhdeniya;
                            dataGridView1.Rows[index].Cells[5].Value = item.telefon;
                            dataGridView1.Rows[index].Cells[6].Value = item.adres;
                            index++;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int str = (int)dataGridView1.CurrentRow.Cells[0].Value;

            using (ApplicationContext db = new ApplicationContext())
            {
                dataGridView1.Rows.Clear();
                var sotr = db.Sotrudniki.ToList();
                foreach (var item in sotr)
                {
                    if (item.nomer_sotrudnika == str)
                    {
                        db.Sotrudniki.Remove(item);
                        sotr.Remove(item);
                        db.SaveChanges();
                        break;
                    }
                }
                dataGridView1.RowCount = sotr.Count;
                var sotrudniki = db.Sotrudniki.ToList();
                var ap = db.Aptechnyye_punkty.ToList();
                var dol = db.Dolzhnosti.ToList();
                int index = 0;
                foreach (var item in sotrudniki)
                {
                    dataGridView1.Rows[index].Cells[0].Value = item.nomer_sotrudnika;

                    dataGridView1.Rows[index].Cells[1].Value = item.nomer_punkta;
                    dataGridView1.Rows[index].Cells[2].Value = item.nomer_dolzhnosti;
                    dataGridView1.Rows[index].Cells[3].Value = item.fio;
                    dataGridView1.Rows[index].Cells[4].Value = item.data_rozhdeniya;
                    dataGridView1.Rows[index].Cells[5].Value = item.telefon;
                    dataGridView1.Rows[index].Cells[6].Value = item.adres;
                    foreach (var item1 in ap)
                    {
                        if (item.nomer_punkta == item1.nomer_punkta)
                        {
                            dataGridView1.Rows[index].Cells[1].Value = item1.naimenovaniye;

                        }
                    }
                    foreach (var item2 in dol)
                    {
                        if (item.nomer_dolzhnosti == item2.nomer_dolzhnosti)
                        {
                            dataGridView1.Rows[index].Cells[2].Value = item2.nazvaniye;

                        }
                    }
                    index++;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = (dataGridView1.CurrentRow.Cells[0].Value).ToString();
            comboBox1.Text = (dataGridView1.CurrentRow.Cells[1].Value).ToString();
            comboBox2.Text = (dataGridView1.CurrentRow.Cells[2].Value).ToString();
            textBox1.Text = (string)dataGridView1.CurrentRow.Cells[3].Value;
            dateTimePicker1.Value = Convert.ToDateTime( dataGridView1.CurrentRow.Cells[4].Value);
            textBox2.Text = (string)dataGridView1.CurrentRow.Cells[5].Value;
            textBox3.Text = (string)dataGridView1.CurrentRow.Cells[6].Value;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                string name = (string)comboBox1.SelectedItem;
                string named = (string)comboBox2.SelectedItem;
                var ap = db.Aptechnyye_punkty.ToList();
                var dol = db.Dolzhnosti.ToList();
                int id_p = 0;
                int id_d = 0;
                foreach (var item in ap)
                {
                    if (name == item.naimenovaniye)
                    {
                        id_p = item.nomer_punkta;
                    }
                }
                foreach (var item in dol)
                {
                    if (named == item.nazvaniye)
                    {
                        id_d = item.nomer_dolzhnosti;
                    }
                }
                dataGridView1.Rows.Clear();
                var sotr = db.Sotrudniki.ToList();
                foreach (var item in sotr)
                {
                    if (item.nomer_sotrudnika == Convert.ToInt32(textBox4.Text))
                    {
                        item.nomer_sotrudnika = Convert.ToInt32(textBox4.Text);
                        item.nomer_punkta = id_p;
                        item.nomer_dolzhnosti = id_d;
                        item.fio = textBox1.Text;
                        item.data_rozhdeniya = dateTimePicker1.Value;
                        item.telefon = textBox2.Text;
                        item.adres = textBox3.Text;
                        db.Update(item);
                        db.SaveChanges();
                        break;
                    }
                }
                dataGridView1.RowCount = sotr.Count;
                int index = 0;

                var sotrudniki = db.Sotrudniki.ToList();
                dataGridView1.RowCount = sotrudniki.Count;

                index = 0;
                foreach (var item in sotrudniki)
                {
                    dataGridView1.Rows[index].Cells[0].Value = item.nomer_sotrudnika;

                    dataGridView1.Rows[index].Cells[1].Value = item.nomer_punkta;
                    dataGridView1.Rows[index].Cells[2].Value = item.nomer_dolzhnosti;
                    dataGridView1.Rows[index].Cells[3].Value = item.fio;
                    dataGridView1.Rows[index].Cells[4].Value = item.data_rozhdeniya;
                    dataGridView1.Rows[index].Cells[5].Value = item.telefon;
                    dataGridView1.Rows[index].Cells[6].Value = item.adres;
                    foreach (var item1 in ap)
                    {
                        if (item.nomer_punkta == item1.nomer_punkta)
                        {
                            dataGridView1.Rows[index].Cells[1].Value = item1.naimenovaniye;

                        }
                    }
                    foreach (var item2 in dol)
                    {
                        if (item.nomer_dolzhnosti == item2.nomer_dolzhnosti)
                        {
                            dataGridView1.Rows[index].Cells[2].Value = item2.nazvaniye;

                        }
                    }
                    index++;
                }

            }
        }
    }
}

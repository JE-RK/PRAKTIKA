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
    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1(Form2 form2)
        {
            this.form2 = form2;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            using (ApplicationContext db = new ApplicationContext())
            {
                var kliyents = db.Kliyent.ToList();
                string str1 = (string)listBox1.SelectedItem;
                string[] str2 = str1.Split(' ');
                foreach (var item in kliyents)
                {
                    if (item.nomer_kliyenta == Convert.ToInt32(str2[0]))
                    {
                        db.Remove(item);
                        //listBox1.Items.Remove(item); //не робит
                        db.SaveChanges();
                    }
                }
                var kliyents1 = db.Kliyent.ToList(); //пришлось опять вытягивать список
                listBox1.Items.Clear();
                foreach (var u in kliyents1)
                {
                    listBox1.Items.Add($"{u.nomer_kliyenta} {u.dannyye_karty} {u.fio}");
                }

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            int index = listBox1.SelectedIndex + 1;
            string str1 = (string)listBox1.SelectedItem;
            string[] str2 = str1.Split(' ');
            using (ApplicationContext db = new ApplicationContext())
            {
                var kliyents = db.Kliyent.ToList();
                foreach (var item in kliyents)
                {
                    if (item.nomer_kliyenta == Convert.ToInt32(str2[0]))
                    {
                        textBox1.Text += item.nomer_kliyenta;
                        textBox2.Text += item.dannyye_karty;
                        textBox3.Text += item.fio;
                        break;
                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                // получаем объекты из бд и выводим на консоль
                var kliyents = db.Kliyent.ToList();
                Console.WriteLine("Users list:");
                foreach (Kliyent u in kliyents)
                {
                    listBox1.Items.Add($"{u.nomer_kliyenta} {u.dannyye_karty} {u.fio}");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Kliyent kliyent = new Kliyent(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text);
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Kliyent.Update(kliyent);
                db.SaveChanges();
                var kliyents = db.Kliyent.ToList();
                foreach (Kliyent u in kliyents)
                {
                    listBox1.Items.Add($"{u.nomer_kliyenta} {u.dannyye_karty} {u.fio}");
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Kliyent kliyent = new Kliyent(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text);
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Kliyent.Add(kliyent);
                db.SaveChanges();
                var kliyents = db.Kliyent.ToList();
                foreach (Kliyent u in kliyents)
                {
                    listBox1.Items.Add($"{u.nomer_kliyenta} {u.dannyye_karty} {u.fio}");
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

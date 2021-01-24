using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace courseWork
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        string URI = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\DarkGolly\\Desktop\\Учёба\\Техналогия программирования" +
            "\\курсач\\код\\coursework-TP\\courseWork\\courseWork\\main\\Database1.mdf\";Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите название программы передач!");
                return;
            }
            Search_results search = new Search_results(textBox1.Text);
            search.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(URI);

            sqlConnection.Open();

            string query = Utils.building_request(comboBox1.Text, comboBox2.Text, comboBox3.Text, textBox1.Text, tabControl1.SelectedTab.Text);
            
            SqlCommand command = new SqlCommand(query, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();
            
            List<string[]> data = new List<string[]>();

            data = Utils.reared_to_data(reader, data, 5);
            if (data.Count == 0)
                MessageBox.Show("По вашему запросу ничего не найдено!");
            reader.Close();

            sqlConnection.Close();

            display_dataGrid(sender, e, data);   
        }

        public void display_dataGrid(object sender, EventArgs e, List<string[]> data)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            dataGridView6.Rows.Clear();
            dataGridView7.Rows.Clear();
            foreach (string[] s in data)
            {
                if (tabControl1.SelectedTab.Text == "Понедельник")
                {
                    dataGridView1.Rows.Add(s);
                }
                else if (tabControl1.SelectedTab.Text == "Вторник")
                {
                    dataGridView2.Rows.Add(s);
                }
                else if (tabControl1.SelectedTab.Text == "Среда")
                {
                    dataGridView3.Rows.Add(s);
                }
                else if (tabControl1.SelectedTab.Text == "Четверг")
                {
                    dataGridView4.Rows.Add(s);
                }
                else if (tabControl1.SelectedTab.Text == "Пятница")
                {
                    dataGridView5.Rows.Add(s);
                }
                else if (tabControl1.SelectedTab.Text == "Суббота")
                {
                    dataGridView6.Rows.Add(s);
                }
                else if (tabControl1.SelectedTab.Text == "Воскресенье")
                {
                    dataGridView7.Rows.Add(s);
                }
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
        private void сведенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная программа является программой передач телеканалов. " +
                "Тут есть сортировка по жанрам, каналам и возрасту, а так же поиск по названию телепередачи.\n\n" +
                "Авторы: Даниил Ануфриев, Эльза Салиндер, Данила Рудыченко\n Группа ИС-22", "Сведения о программе");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace courseWork
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        string URI = File.ReadAllText(@"..\..\Resources/path.txt");
        //private SqlDataAdapter adapter = null;
        //private DataTable table = null;

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

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet1.TVprograms". При необходимости она может быть перемещена или удалена.
            //this.tVprogramsTableAdapter.Fill(this.database1DataSet1.TVprograms);
            sqlConnection = new SqlConnection(URI);

            sqlConnection.Open();
            string channel = comboBox1.Text;
            string ganre = comboBox2.Text;
            string cense = comboBox3.Text;
            string search = textBox1.Text;
            if (channel == "" || channel == "Все")
            {
                channel = "";
            }
            else
            {
                channel = " AND Канал LIKE N\'" + channel + "\'";
            }
            if (ganre == "" || ganre == "Все")
            {
                ganre = "";
            }
            else
            {
                ganre = " AND Жанр LIKE N\'" + ganre + "\'";
            }
            if (cense == "" || cense == "Все")
            {
                cense = "";
            }
            else
            {
                cense = " AND Ограничение LIKE N\'"+cense+"       \'";
            }
            if (search == "" || search == "Все")
            {
                search = "";
            }
            else
            {
                search = " AND Название LIKE N\'%"+ search + "%\'";
            }
            string query = "SELECT Канал, Название, Время, Жанр, Ограничение FROM TVprograms WHERE День LIKE N\'" + tabControl1.SelectedTab.Text + "\' "+ channel + ganre + cense + search;

            SqlCommand command = new SqlCommand(query, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);
                for (int i = 0; i < 5; i++)
                    data[data.Count - 1][i] = reader[i].ToString();          
            }

            reader.Close();

            sqlConnection.Close();

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}

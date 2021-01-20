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
            string query = "SELECT Канал, Название, Время, Жанр, Ограничение FROM TVprograms WHERE День LIKE N\'"+ tabControl1.SelectedTab.Text + "\' AND Канал LIKE N\'" + channel + "\'";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
            }

            reader.Close();

            sqlConnection.Close();

            foreach (string[] s in data)
            {
                if (tabControl1.SelectedTab.Text == "Понедельник")
                {
                    this.Column1.HeaderText = "Канал";
                    this.Column3.HeaderText = "Название";
                    this.Column4.HeaderText = "Время";
                    this.Column5.HeaderText = "Жанр";
                    this.Column6.HeaderText = "Ограничение";
                    dataGridView1.Rows.Add(s);
                }
                else if (tabControl1.SelectedTab.Text == "Вторник")
                {
                    this.Column2.HeaderText = "Канал";
                    this.Column7.HeaderText = "Название";
                    this.Column8.HeaderText = "Время";
                    this.Column9.HeaderText = "Жанр";
                    this.Column10.HeaderText = "Ограничение";
                    dataGridView2.Rows.Add(s);
                }
                else if (tabControl1.SelectedTab.Text == "Среда")
                {
                    this.Column11.HeaderText = "Канал";
                    this.Column12.HeaderText = "Название";
                    this.Column13.HeaderText = "Время";
                    this.Column14.HeaderText = "Жанр";
                    this.Column15.HeaderText = "Ограничение";
                    dataGridView3.Rows.Add(s);
                }
                else if (tabControl1.SelectedTab.Text == "Четверг")
                {
                    this.Column16.HeaderText = "Канал";
                    this.Column17.HeaderText = "Название";
                    this.Column18.HeaderText = "Время";
                    this.Column19.HeaderText = "Жанр";
                    this.Column20.HeaderText = "Ограничение";
                    dataGridView4.Rows.Add(s);
                }
                else if (tabControl1.SelectedTab.Text == "Пятница")
                {
                    this.Column21.HeaderText = "Канал";
                    this.Column22.HeaderText = "Название";
                    this.Column23.HeaderText = "Время";
                    this.Column24.HeaderText = "Жанр";
                    this.Column25.HeaderText = "Ограничение";
                    dataGridView5.Rows.Add(s);
                }
                else if (tabControl1.SelectedTab.Text == "Суббота")
                {
                    this.Column26.HeaderText = "Канал";
                    this.Column27.HeaderText = "Название";
                    this.Column28.HeaderText = "Время";
                    this.Column29.HeaderText = "Жанр";
                    this.Column30.HeaderText = "Ограничение";
                    dataGridView6.Rows.Add(s);
                }
                else if (tabControl1.SelectedTab.Text == "Воскресенье")
                {
                    this.Column31.HeaderText = "Канал";
                    this.Column32.HeaderText = "Название";
                    this.Column33.HeaderText = "Время";
                    this.Column34.HeaderText = "Жанр";
                    this.Column35.HeaderText = "Ограничение";
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
    }
}

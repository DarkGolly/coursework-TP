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
        private SqlDataAdapter adapter = null;
        private DataTable table = null;

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
            sqlConnection = new SqlConnection(URI);
            sqlConnection.Open();

            adapter = new SqlDataAdapter("SELECT * FROM Tvprograms", sqlConnection);
            table = new DataTable();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}

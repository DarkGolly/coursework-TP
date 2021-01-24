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
    public partial class Search_results : Form
    {
        private SqlConnection sqlConnection = null;
        string URI = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\DarkGolly\\Desktop\\Учёба\\Техналогия программирования" +
            "\\курсач\\код\\coursework-TP\\courseWork\\courseWork\\main\\Database1.mdf\";Integrated Security=True";
        string text_search;
        public Search_results(string text_search)
        {
            this.text_search = text_search;
            InitializeComponent();
        }
        

        private void Search_results_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(URI);

            sqlConnection.Open();
            
            string query = "SELECT День, Канал, Название, Время, Жанр, Ограничение FROM TVprograms WHERE Название LIKE N\'%" + text_search + "%\' ";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();
            
            List<string[]> data = new List<string[]>();
            data = Utils.reared_to_data(reader, data, 6);
            
            if (data.Count == 0)
            {
                MessageBox.Show("По вашему запросу ничего не найдено!");
                this.Close();
            }
            reader.Close();

            sqlConnection.Close();
            dataGridView1.Rows.Clear();

            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }
        }
    }
}

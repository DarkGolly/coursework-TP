using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace courseWork
{
    static public class Utils
    {
        public static List<string[]> reared_to_data(SqlDataReader reader, List<string[]> data, int count)
        {
            while (reader.Read())
            {
                data.Add(new string[count]);
                for (int i = 0; i < count; i++)
                    data[data.Count - 1][i] = reader[i].ToString();
            }
            return data;
        }

        public static string building_request(string channel, string ganre, string cense, string search, string day)
        {
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
                cense = " AND Ограничение LIKE N\'" + cense + "       \'";
            }
            if (search == "" || search == "Все")
            {
                search = "";
            }
            else
            {
                search = " AND Название LIKE N\'%" + search + "%\'";
            }
            string query = "SELECT Канал, Название, Время, Жанр, Ограничение FROM TVprograms WHERE День LIKE N\'" + day + "\' " +
                channel + ganre + cense + search;

            return query;
        }
    }
}

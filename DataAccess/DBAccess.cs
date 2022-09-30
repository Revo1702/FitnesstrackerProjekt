using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class DBAccess
    {
        public static string connstr = "server=localhost;user=root;database=fitnesstracker;port=3306;password=root";
        MySqlConnection conn = new MySqlConnection(connstr);
        public List<string> ReadDataBase()
        {
            List<string> uebungen = new List<string>();
            conn.Open();
            string sqlcmd = "SELECT ueID, UebungsName, CategoryName FROM fitnesstracker.uebungen INNER JOIN categories ON categories.CategoryID = uebungen.CategoryID GROUP BY ueID Asc;";
            MySqlDataAdapter adr = new MySqlDataAdapter(sqlcmd, conn);
            adr.SelectCommand.CommandType = System.Data.CommandType.Text;
            DataSet dt = new DataSet();
            adr.Fill(dt, "Uebungen");
            int i = 0;
            foreach (DataRow dr in dt.Tables["Uebungen"].Rows)
            {
                uebungen.Add(Convert.ToString(dr[1]) + "," + Convert.ToString(dr[2]));

            }
            return uebungen;
        }

    }
}

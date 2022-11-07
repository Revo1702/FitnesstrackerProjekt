using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class DBAccess
    {
        public static string connstr = "server=localhost;user=root;database=fitnesstracker;port=3306;password=root";
        public static List<Uebungen> ReadAllExercises()
        {
            Uebungen uebungen = new Uebungen();
            List<Uebungen> listOfUebungen = new List<Uebungen>();
            //List<string> uebungen = new List<string>();
            var conn = OpenConnection();
            string sqlcmd = "SELECT ueID, UebungsName, CategoryName FROM fitnesstracker.uebungen INNER JOIN categories ON categories.CategoryID = uebungen.CategoryID GROUP BY ueID Asc;";
            MySqlDataAdapter adr = new MySqlDataAdapter(sqlcmd, conn);
            adr.SelectCommand.CommandType = System.Data.CommandType.Text;
            DataSet dt = new DataSet();
            adr.Fill(dt, "Uebungen");
            foreach (DataRow dr in dt.Tables["Uebungen"].Rows)
            {
                uebungen = new Uebungen(Convert.ToString(dr[1]), Convert.ToString(dr[2]));
                listOfUebungen.Add(uebungen);
                //uebungen.Add(Convert.ToString(dr[1]) + "," + Convert.ToString(dr[2]));
            }
            CloseConnection();
            return listOfUebungen;
        }

        public static MySqlConnection OpenConnection()
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            return conn;
        }

        public static MySqlConnection CloseConnection()
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Close();
            return conn;
        }

        public static void ProfilSpeichern(string ProfilName, string ProfilNachname, int Alter, double Groesse, double Gewicht)
        {
            var conn = OpenConnection();
            string sqlcmd = "INSERT INTO fitnesstracker.profil (ProfilName,ProfilNachname,Alter,Groesse,Gewicht) VALUES (@ProfilName,@ProfilNachname,@Alter,@Groesse,@Gewicht)";
            MySqlCommand command = new MySqlCommand(sqlcmd, conn);
            command.ExecuteNonQuery();
                    
        }
    }
}


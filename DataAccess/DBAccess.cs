using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

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

        public static void ProfilSpeichern(string name, string nachname, int alter, double groesse, double gewicht)
        {
            try
            {
                var conn = OpenConnection();
                string sqlcmd = "INSERT INTO fitnesstracker.profiles (ProfileName, ProfileSurname, Age, Height, Weight) VALUES(@name, @nachname, @alter, @groesse, @gewicht)";
                MySqlCommand comm = new MySqlCommand(sqlcmd, conn);
                comm.Parameters.AddWithValue("@name", name);
                comm.Parameters.AddWithValue("@nachname", nachname);
                comm.Parameters.AddWithValue("@alter", alter);
                comm.Parameters.AddWithValue("@groesse", groesse);
                comm.Parameters.AddWithValue("@gewicht", gewicht);
                comm.ExecuteNonQuery();
                CloseConnection();
                if(name != "")
                {
                    MessageBox.Show("Willkommen " + name + " " + nachname + "! :)");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void ProfilLoeschen(string name, string nachname)
        {
            try
            {
                var conn = OpenConnection();
                string sqlcmd = "DELETE FROM fitnesstracker.profiles WHERE ProfileName = '" + name + "' AND ProfileSurname = '" + nachname + "'";
                MySqlCommand comm = new MySqlCommand(sqlcmd, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("Das Profil " + name + " " + nachname + " wurde gelöscht");
                CloseConnection();
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
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
    }
}


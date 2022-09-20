using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data;
using MySql.Data.MySqlClient;
using Xceed.Wpf.AvalonDock.Layout;

namespace Fitnesstracker
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string connstr = "server=localhost;user=root;database=fitnesstracker;port=3306;password=root";
        MySqlConnection conn = new MySqlConnection(connstr);
        int counter = 0;
        List<Uebung> uebungList = new List<Uebung>();
        
        public MainWindow()
        {
            InitializeComponent();
            conn.Open();
            string sqlcmd = "Select * from uebungen";
            txtDebug.Text = conn.ServerVersion;
            MySqlDataAdapter adr = new MySqlDataAdapter(sqlcmd, conn);
            adr.SelectCommand.CommandType = System.Data.CommandType.Text;
            DataSet dt = new DataSet();
            adr.Fill(dt,"Uebungen");
            int i = 0;
            foreach(DataRow dr in dt.Tables["Uebungen"].Rows)
            {
                

                Button button = new Button();
                button.Name = "btn" + i;
                button.Content = dr[1];
                button.Height = 40;
                button.Width = 40;
                button.HorizontalAlignment = HorizontalAlignment.Center;
                button.VerticalAlignment = VerticalAlignment.Center;
                i++;
                button.IsEnabled = true;
                button.Visibility = Visibility.Visible;
                
               
            }
            uebungList.Add(new Uebung("Latzug"));
            ZurueckButton.Visibility = Visibility.Hidden;
            ZurueckAusUebungen.Visibility = Visibility.Hidden;
            NeueUebungHinzufuegen.Visibility = Visibility.Hidden;
            NeuesTrainingStarten.Visibility = Visibility.Visible;
            VorherigesTrainingAnzeigen.Visibility = Visibility.Visible;
            Latzug.Visibility = Visibility.Hidden;
            WdhUebung1.Visibility = Visibility.Hidden;
            GewichtUebung1.Visibility = Visibility.Hidden;
            Gewicht1.Visibility = Visibility.Hidden;
            Wdh1.Visibility = Visibility.Hidden;
        }

        private void NeuesTrainingStarten_Click(object sender, RoutedEventArgs e)
        {
            NeuesTrainingStarten.Visibility = Visibility.Hidden;
            VorherigesTrainingAnzeigen.Visibility = Visibility.Hidden;
            ZurueckButton.Visibility = Visibility.Visible;
            NeueUebungHinzufuegen.Visibility = Visibility.Visible;
            ShowUebung1("");

        }

        private void VorherigesTrainingAnzeigen_Click(object sender, RoutedEventArgs e)
        {
            NeuesTrainingStarten.Visibility = Visibility.Hidden;
            VorherigesTrainingAnzeigen.Visibility = Visibility.Hidden;
            ZurueckButton.Visibility = Visibility.Visible;


        }

        private void Zurueck_Click(object sender, RoutedEventArgs e)
        {
            NeuesTrainingStarten.Visibility = Visibility.Visible;
            VorherigesTrainingAnzeigen.Visibility = Visibility.Visible;
            ZurueckButton.Visibility = Visibility.Hidden;
            NeueUebungHinzufuegen.Visibility = Visibility.Hidden;
            HideUebung1();

        }

        private void NeueUebungHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            ZurueckButton.Visibility = Visibility.Hidden;
            NeueUebungHinzufuegen.Visibility = Visibility.Hidden;
            ZurueckAusUebungen.Visibility = Visibility.Visible;
            Latzug.Visibility = Visibility.Visible;
            HideUebung1();
        }

        private void ZurueckAusUebungen_Click(object sender, RoutedEventArgs e)
        {
            ZurueckButton.Visibility = Visibility.Visible;
            NeueUebungHinzufuegen.Visibility = Visibility.Visible;
            ZurueckAusUebungen.Visibility = Visibility.Hidden;
            Latzug.Visibility = Visibility.Hidden;

            ShowUebung1("");

        }

        private void Latzug_Click(object sender, RoutedEventArgs e)
        {
            ZurueckButton.Visibility = Visibility.Visible;
            NeueUebungHinzufuegen.Visibility = Visibility.Visible;
            ZurueckAusUebungen.Visibility = Visibility.Hidden;
            Latzug.Visibility = Visibility.Hidden;

            ShowUebung1("Latzug");

            counter++;
        }

        private void Done1_Checked(object sender, RoutedEventArgs e)
        {
            Uebung uebung = new Uebung(Convert.ToString(Uebung1.Content), Convert.ToDouble(Gewicht1.Text), Convert.ToInt32(Wdh1.Text));
        }

        private void ShowUebung1(string uebungsName)
        {
            if (counter > 0)
            {
                Uebung1.Visibility = Visibility.Visible;
                WdhUebung1.Visibility = Visibility.Visible;
                GewichtUebung1.Visibility = Visibility.Visible;
                Gewicht1.Visibility = Visibility.Visible;
                Wdh1.Visibility = Visibility.Visible;
                Done1.Visibility = Visibility.Visible;

            }
            else if (uebungsName != "")
            {

                Uebung1.Content = uebungsName;
                Uebung1.Visibility = Visibility.Visible;
                WdhUebung1.Visibility = Visibility.Visible;
                GewichtUebung1.Visibility = Visibility.Visible;
                Gewicht1.Visibility = Visibility.Visible;
                Wdh1.Visibility = Visibility.Visible;
                Done1.Visibility = Visibility.Visible;
            }
            Uebung1.Content = uebungsName;
        }
        private void HideUebung1()
        {
            Uebung1.Visibility = Visibility.Hidden;
            WdhUebung1.Visibility = Visibility.Hidden;
            GewichtUebung1.Visibility = Visibility.Hidden;
            Gewicht1.Visibility = Visibility.Hidden;
            Wdh1.Visibility = Visibility.Hidden;
            Done1.Visibility = Visibility.Hidden;
        }

        private void Gewicht1_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Wdh1_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}

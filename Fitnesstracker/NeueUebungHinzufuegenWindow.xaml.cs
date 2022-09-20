using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fitnesstracker
{
    /// <summary>
    /// Interaktionslogik für NeueUebungHinzufuegen.xaml
    /// </summary>
    public partial class NeueUebungHinzufuegenWin : Window
    {
        public static string connstr = "server=localhost;user=root;database=fitnesstracker;port=3306;password=root";
        MySqlConnection conn = new MySqlConnection(connstr);
        Trainingsfenster tf = new Trainingsfenster();
        public NeueUebungHinzufuegenWin()
        {
            InitializeComponent();
            conn.Open();
            string sqlcmd = "Select * from uebungen";
            MySqlDataAdapter adr = new MySqlDataAdapter(sqlcmd, conn);
            adr.SelectCommand.CommandType = System.Data.CommandType.Text;
            DataSet dt = new DataSet();
            adr.Fill(dt, "Uebungen");
            int i = 0;
            foreach (DataRow dr in dt.Tables["Uebungen"].Rows)
            {


                Button button = new Button();
                Label label = new Label();
                label.Name = "lbl" + i;
                label.Content = dr[2];
                button.Name = "btn" + i;
                button.Content = dr[1];
                button.Width = 200;
                button.Height = 100;
                label.Height = 100;
                button.Click += new RoutedEventHandler(this.ClickEvent);
                i++;
                StackPanel1.Children.Add(button);
                StackPanel2.Children.Add(label);


            }
        }

        void ClickEvent(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            //string buttonName = Convert.ToString(btn.Content);
            //string name = Regex.Replace(buttonName, @" ", "");
            /*Label UebungsName = new Label();
            Label Gewicht = new Label();
            Gewicht.Name = "KG";
            Gewicht.Width = 150;
            Gewicht.Visibility = Visibility.Visible;
            UebungsName.Name = "lbl" + name;
            UebungsName.Content = btn.Content;
            UebungsName.Width = 150;
            UebungsName.Visibility = Visibility.Visible;
            */
            tf.DataGrid1.Columns.Add(new DataGridTextColumn());
            tf.DataGrid1.Columns.Add(new DataGridTextColumn());
            tf.DataGrid1.Columns.Add(new DataGridTextColumn());
            tf.DataGrid1.Columns[0].Header = btn.Content;
            tf.DataGrid1.Columns[1].Header = "Gewicht";
            tf.DataGrid1.Columns[2].Header = "Wiederholungen";
            tf.DataGrid1.Columns[0].Width = new DataGridLength(200);
            tf.DataGrid1.Columns[1].Width = new DataGridLength(200);
            tf.DataGrid1.Columns[2].Width = new DataGridLength(200);

            tf.Show();
            this.Close();
        }
    }
}

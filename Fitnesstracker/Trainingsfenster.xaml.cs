using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaktionslogik für Trainingsfenster.xaml
    /// </summary>
    public partial class Trainingsfenster : Window
    {
        public Trainingsfenster()
        {
            InitializeComponent();
        }
        private void NeueUebungHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            /* ZurueckButton.Visibility = Visibility.Hidden;
             NeueUebungHinzufuegen.Visibility = Visibility.Hidden;
             ZurueckAusUebungen.Visibility = Visibility.Visible;
             Latzug.Visibility = Visibility.Visible;
             HideUebung1();
            */
            NeueUebungHinzufuegenWin win = new NeueUebungHinzufuegenWin();
            win.Show();
            this.Close();
        }

        private void Zurueck_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}

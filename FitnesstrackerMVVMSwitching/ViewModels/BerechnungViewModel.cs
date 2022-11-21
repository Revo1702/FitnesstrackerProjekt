using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommandHelper;
using Model;

namespace FitnesstrackerMVVMSwitching.ViewModels
{
    class BerechnungViewModel : INotifyPropertyChanged
    {

        private double _gewicht;
        private int _wiederholungen;
        private double _stangeGewicht;
        private double _groesse;
        private int _alter;
        private int _palwert;
        private ICommand _berechneOneRepMaxCommand;
        private ICommand _berechneGewichtsPlattenCommand;
        private ICommand _berechneBMICommand;
        private ICommand _berechneKalorienCommand;
        private ICommand _openMainView;
        private string _message;
        private Visibility _visibleState = Visibility.Hidden;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand OpenMainView
        {
            get
            {
                if (_openMainView == null)
                {
                    _openMainView = new RelayCommand(c => MainViewOeffnen());
                }
                return _openMainView;
            }
        }

        void MainViewOeffnen()
        {
            //MainView muss noch geclosed werde (muss noch eingebaut werden)
            //MainView mv = new MainView();
            //mv.Show();
        }
        
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Message"));
                    PropertyChanged(this, new PropertyChangedEventArgs("VisibleState"));
                }
            }
        }
        
        public Visibility VisibleState 
        {  
            get { return _visibleState; }
            set { _visibleState = value; }
        }
        public double Gewicht
        {
            get { return _gewicht; }
            set { _gewicht = value; }
        }

        
        public int Wiederholungen
        {
            get { return _wiederholungen; }
            set { _wiederholungen = value; }
        }

        public double StangeGewicht
        {
            get { return _stangeGewicht; }
            set { _stangeGewicht = value; }
        }
        public double Groesse
        {
            get { return _groesse; }
            set { _groesse = value; }
        }
        public int Alter
        {
            get { return _alter; }
            set { _alter = value; }
        }
        public int Palwert
        {
            get { return _palwert; }
            set { _palwert = value; }
        }
        public ICommand BerechneOneRepMaxCommand
        {
            get
            {
                if (_berechneOneRepMaxCommand == null)
                    _berechneOneRepMaxCommand = new RelayCommand(c => BerechneOneRepMax());
                return _berechneOneRepMaxCommand;
            }
        }
        private void BerechneOneRepMax()
        {
            try
            {
                string ErgebnisOneRepMax = Convert.ToString(Berechnungen.BerechneOneRepMax(Wiederholungen, Gewicht));
                Message = "Ergebnis: " + ErgebnisOneRepMax + " kg";
                VisibleState = Visibility.Visible;
            }
            catch(Exception e)
            {
                MessageBox.Show("Die Eingabe ist inkorrekt");
            }
        }

        public ICommand BerechneGewichtsPlattenCommand
        {
            get
            {
                if (_berechneGewichtsPlattenCommand == null)
                    _berechneGewichtsPlattenCommand = new RelayCommand(c => BerechneGewichtsPlatten());
                return _berechneGewichtsPlattenCommand;
            }
        }

        private void BerechneGewichtsPlatten()
        {
            try
            {
                string ErgebnisGewichtsPlatten = Convert.ToString(Berechnungen.BerechneGewichtsplatten(Gewicht, StangeGewicht));
                Message = "Ergebnis: " + ErgebnisGewichtsPlatten;
                VisibleState = Visibility.Visible;
            }
            catch (Exception e)
            {
                MessageBox.Show("Die Eingabe ist inkorrekt");
            }
        }

        public ICommand BerechneBMICommand
        {
            get
            {
                if (_berechneBMICommand == null)
                    _berechneBMICommand = new RelayCommand(c => BerechneBMI());
                return _berechneBMICommand;
            }
        }
        private void BerechneBMI()
        {
            try
            {
                string ErgebnisBMI = Convert.ToString(Berechnungen.BMIRechner(Gewicht, Groesse));
                Message = ErgebnisBMI;
                VisibleState = Visibility.Visible;
            }
            catch (Exception e)
            {
                MessageBox.Show("Die Eingabe ist inkorrekt");
            }
        }

        public ICommand BerechneKalorienCommand
        {
            get
            {
                if (_berechneKalorienCommand == null)
                    _berechneKalorienCommand = new RelayCommand(c => BerechneKalorien());
                return _berechneKalorienCommand;
            }
        }
        private void BerechneKalorien()
        {
            try
            {
                string ErgebnisKalorien = Convert.ToString(Berechnungen.Kalorienrechner(Alter, Gewicht, Groesse, Palwert));
                Message = ErgebnisKalorien;
                VisibleState = Visibility.Visible;
            }
            catch (Exception e)
            {
                MessageBox.Show("Die Eingabe ist inkorrekt");
            }
        }


        public BerechnungViewModel()
        {

        }
    }
}

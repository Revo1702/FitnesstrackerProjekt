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
        private ICommand _berechneOneRepMaxCommand;
        private ICommand _berechneGewichtsPlattenCommand;
        private ICommand _openMainView;
        private string _messageOneRepMax = "Ergebnis";
        private string _messageGewichtsPlatten = "Ergebnis";

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

        public string MessageOneRepMax
        {
            get
            {
                return _messageOneRepMax;
            }
            set
            {
                _messageOneRepMax = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MessageOneRepMax"));
            }
        }

        public string MessageGewichtsPlatten
        {
            get
            {
                return _messageGewichtsPlatten;
            }
            set
            {
                _messageGewichtsPlatten = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MessageGewichtsPlatten"));
            }
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
                MessageOneRepMax = ErgebnisOneRepMax + " kg";
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
                MessageGewichtsPlatten = ErgebnisGewichtsPlatten;
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

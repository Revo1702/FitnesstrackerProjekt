using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommandHelper;

namespace FitnesstrackerMVVMSwitching.ViewModels
{
    public class ProfilViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _nachname;
        private int _alter;
        private double _groesse;
        private double _gewicht;
        private ICommand _speichernCommand;
        private ICommand _openMainView;

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
            
        }
        public ICommand SpeichernCommand
        {
            get
            {
                if (_speichernCommand == null)
                    _speichernCommand = new RelayCommand(c => SpeichereProfil());
                return _speichernCommand;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = Name;
            }
        }
        public string Nachname
        {
            get
            {
                return _nachname;
            }
            set
            {
                _nachname = Nachname;
            }
        }
        public int Alter
        {
            get
            {
                return _alter;
            }
            set
            {
                _alter = Alter;
            }
        }
        public double Groesse
        {
            get
            {
                return _groesse;
            }
            set
            {
                _groesse = Groesse;
            }
        }
        public double Gewicht
        {
            get
            {
                return _gewicht;
            }
            set
            {
                _gewicht = Gewicht;
            }
        }
        private void SpeichereProfil()
        {
            DataAccess.DBAccess.ProfilSpeichern(Name, Nachname, Alter, Groesse, Gewicht);
        }
        public ProfilViewModel()
        {
            Gewicht = 34.6;
        }
    }
}

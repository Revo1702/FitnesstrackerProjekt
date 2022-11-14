using CommandHelper;
using FitnesstrackerMVVMSwitching.Views;
using Model;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using static DataAccess.DBAccess;

namespace FitnesstrackerMVVMSwitching.ViewModels
{
    class AddExerciseViewModel : INotifyPropertyChanged
    {
        private DelegateCommand _exerciseCommand;
        StackPanel StackPanel = new StackPanel();
        public event PropertyChangedEventHandler PropertyChanged;
        private RowDefinition _rowDef;
        private ICommand _auswaehlen;
        private int _selectedIndex;
        private List<string> _listOfUebungen = new List<string>();
        int counter = 0;
        public TrainingssessionViewModel tsvm = new TrainingssessionViewModel();
        List<Uebungen> uebungen = new List<Uebungen>(DataAccess.DBAccess.ReadAllExercises());

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; }
        }


        public DelegateCommand ExerciseCommand => _exerciseCommand ?? (_exerciseCommand = new DelegateCommand(Exercise));

        void Exercise()
        {

        }

        public AddExerciseViewModel()
        {
            int zaehler = 0;
            foreach (var i in uebungen)
            {
                if (_rowDef == null)
                {
                    _rowDef = new RowDefinition();
                }
                Binding binding = new Binding
                {
                    Path = new System.Windows.PropertyPath("ExerciseCommand")
                };
                string trimmedName = String.Concat(i.Name.Where(c => !Char.IsWhiteSpace(c)));
                Button btn = new Button
                {
                    Name = trimmedName,
                    Content = i.Name,
                    Width = 200,
                    Height = 100
                };
                btn.SetBinding(Button.CommandProperty, binding);

                StackPanel.Children.Add(btn);
                zaehler++;
            }
        }
        public ICommand Auswaehlen
        {
            get
            {
                if (_auswaehlen == null)
                {
                    _auswaehlen = new RelayCommand(c => TrainingAuswaehlen());
                }
                return _auswaehlen;
            }
        }
        void TrainingAuswaehlen()
        {
            tsvm.AllSelectedUebungen.Add(uebungen[SelectedIndex].Name);
        }

        public List<string> ListOfUebungen
        {
            get
            {
                List<string> listofStrings = new List<string>();
                int counter = 0;
                foreach (var i in uebungen)
                {
                    string nameAndCategory = uebungen[counter].Name + " Kategorie: " + uebungen[counter].Kategorie;
                    listofStrings.Add(nameAndCategory);
                    counter++;
                }
                return listofStrings;
            }
            set
            {
                _listOfUebungen = ListOfUebungen;
            }
        }
       /* public RowDefinition RowDef
        {
            get
            {
                return _rowDef;
            }
            set
            {
                _rowDef = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("RowDef"));
                }
            }
        }*/
    }
}

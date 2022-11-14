using FitnesstrackerMVVMSwitching.Views;
using Model;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FitnesstrackerMVVMSwitching.ViewModels
{
    class TrainingssessionViewModel : INotifyPropertyChanged
    {
        public interface ICloseWindows
        {
            Action Close { get; set; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public Action Close { get; set; }
        private DelegateCommand _closeCommand;
        private DelegateCommand _openUebungenHinzufuegenView;
        private List<string> _allSelectedUebungen = new List<string>();

        public DelegateCommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(NeuesTrainingStarten));
        public DelegateCommand OpenUebungenHinzufuegenViewCommand => _openUebungenHinzufuegenView ?? (_openUebungenHinzufuegenView = new DelegateCommand(NeueUebungHinzufuegen));
        void NeuesTrainingStarten()
        {
            MainView mv = new MainView();
            mv.Show();
            Close?.Invoke();
        }

        public List<string> AllSelectedUebungen
        {
            get
            {

                return _allSelectedUebungen;
            }
            set
            {
                _allSelectedUebungen.Add(Convert.ToString(value));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllSelectedUebungen"));
            }
        }

        void NeueUebungHinzufuegen()
        {
            NeueUebungHinzufuegenView nuhv = new NeueUebungHinzufuegenView();
            nuhv.Show();
        }
    }
}

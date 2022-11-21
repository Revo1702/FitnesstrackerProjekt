using CommandHelper;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FitnesstrackerMVVMSwitching.Views;

namespace FitnesstrackerMVVMSwitching.ViewModels
{
    class MainViewModel : MainViewModel.ICloseWindows
    {
        public Action Close { get; set; }
        private ICommand _neuesTrainingStarten;
        private DelegateCommand _closeCommand;
        private ICommand _openBerechnungen;
        private ICommand _openProfil;
        public DelegateCommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(NeuesTrainingStarten));


        public ICommand OpenProfil
        {
            get
            {
                if (_openProfil == null)
                {
                    _openProfil = new RelayCommand(c => ProfilViewOeffnen());
                }
                return _openProfil;
            }
        }

        void ProfilViewOeffnen()
        {
            ProfilView pv = new ProfilView();
            pv.ShowDialog();
        }
        public ICommand OpenBerechnungen
        {
            get
            {
                if(_openBerechnungen == null)
                {
                    _openBerechnungen = new RelayCommand(c => BerechnungenViewOeffnen());
                }
                return _openBerechnungen;
            }
        }

        void BerechnungenViewOeffnen()
        {
            BerechnungView bv = new BerechnungView();
            
            bv.Show();
            Close?.Invoke();
        }

        void NeuesTrainingStarten()
        {
            TrainingssessionView tv = new TrainingssessionView();
            tv.Show();
            Close?.Invoke();
        }
        public MainViewModel()
        {

        }
        public class MenuItemViewModel
        {
            public MenuItemViewModel()
            {
                this.MenuItems = new List<MenuItemViewModel>();
            }
            public string Text { get; set; }
            public IList<MenuItemViewModel> MenuItems { get; private set; }
        }

        public ICommand NeuesTrainingStartenCommand
        {
            get
            {
                if(_neuesTrainingStarten == null)
                
                    _neuesTrainingStarten = new RelayCommand(c => NeuesTrainingStarten());
                return _neuesTrainingStarten;
                
            }

        }

        public interface ICloseWindows
        {
            Action Close { get; set; }
        }
    }
}

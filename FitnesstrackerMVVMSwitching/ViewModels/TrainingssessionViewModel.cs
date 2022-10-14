using FitnesstrackerMVVMSwitching.Views;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesstrackerMVVMSwitching.ViewModels
{
    class TrainingssessionViewModel : TrainingssessionViewModel.ICloseWindows
    {
        public interface ICloseWindows
        {
            Action Close { get; set; }
        }
        public Action Close { get; set; }
        private DelegateCommand _closeCommand;
        private DelegateCommand _openUebungenHinzufuegenView;

        public DelegateCommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(NeuesTrainingStarten));
        public DelegateCommand OpenUebungenHinzufuegenViewCommand => _openUebungenHinzufuegenView ?? (_openUebungenHinzufuegenView = new DelegateCommand(NeueUebungHinzufuegen));
        void NeuesTrainingStarten()
        {
            MainView mv = new MainView();
            mv.Show();
            Close?.Invoke();
        }

        void NeueUebungHinzufuegen()
        {
            NeueUebungHinzufuegenView nuhv = new NeueUebungHinzufuegenView();
            nuhv.Show();
        }
    }
}

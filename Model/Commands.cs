using FitnesstrackerMVVMSwitching.Views;
using Prism.Commands;
using System;

namespace Model
{
    class Commands
    {
        public interface ICloseWindows
        {
            Action Close { get; set; }
        }
        public Action Close { get; set; }
        private DelegateCommand _closeCommand;

        public DelegateCommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(NeuesTrainingStarten));

        void NeuesTrainingStarten()
        {
            MainView mv = new MainView();
            mv.Show();
            Close?.Invoke();
        }
        private Action<object> _action;
        private bool _canExecute;
        public Commands(Action<object> action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action(parameter);
        }
        public Commands()
        { 
        
        }




    }
}


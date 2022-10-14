using Prism.Commands;
using System;
// Verschieben in Fitnesstracker/ViewModels/Commands
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


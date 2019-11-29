using System;
using System.Windows.Input;

namespace StationFinder
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _methodToExecute;
        public RelayCommand(Action methodToExecute)
        {
            _methodToExecute = methodToExecute;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            if (_methodToExecute != null)
            {
                _methodToExecute();
            }
        }
    }
}
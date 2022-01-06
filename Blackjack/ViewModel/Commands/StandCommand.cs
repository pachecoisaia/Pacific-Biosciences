using System;
using System.Windows.Input;

namespace Blackjack.ViewModel.Commands
{
    public class StandCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute;

        public StandCommand(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();

            return true;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            _execute.Invoke();
        }
    }
}

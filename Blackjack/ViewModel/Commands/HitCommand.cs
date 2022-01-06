using System;
using System.Windows.Input;

namespace Blackjack.ViewModel.Commands
{
    public class HitCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute;

        public HitCommand(Action execute)
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

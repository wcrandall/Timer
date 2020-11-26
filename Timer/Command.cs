using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Timer
{
    public class Command : ICommand
    {
        private Action<Object> _executeMethod;
        private Func<Object, bool> _canExecuteMethod; 
        public event EventHandler CanExecuteChanged;
        public Command(Action<Object> executeMethod, Func<Object, bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod; 
        }
        public bool CanExecute(object parameter)
        { 
            return true; 
        }

        public void Execute(object parameter)
        {
            _executeMethod(parameter);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KT_1.Helpers
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute)
            : this(null, execute)
        {
        }

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            m_CanExecute = canExecute;
            m_Execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return m_CanExecute == null || m_CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            m_Execute(parameter);
        }
        

        private Action<object> m_Execute;
        private Predicate<object> m_CanExecute;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleWeightUnitConverter {
    class DelegateCommand : ICommand {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public DelegateCommand(Action execute)
            : this(execute, () => true) { }

        public DelegateCommand(Action execute, Func<bool> canExecute) {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public void Execute(object parameter) {
            this.execute();
        }

        public bool CanExecute(object parameter) {
            return this.canExecute();
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
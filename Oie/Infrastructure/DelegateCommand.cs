using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Oie.Infrastructure
{
    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action action)
        {
            this.Delegate = action;
        }

        public Action Delegate { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.Delegate();
        }
    }
}

using Oie.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Oie.ViewModels
{
    public class TestViewModel
    {
        public TestViewModel()
        {
            this.TestCommand = new MyCommand();
        }

        public ICommand TestCommand { get; set; }

        private class MyCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                new MySqlDatabase().Test();
            }
        }
    }
}

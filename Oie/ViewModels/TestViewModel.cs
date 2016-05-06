using Oie.DataAccess;
using Oie.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            this.DbContext = new OieDbContext();
            this.TestCommand = new DelegateCommand(this.TestEf);
        }

        public ICommand TestCommand { get; set; }

        private OieDbContext DbContext { get; set; }

        public void TestEf()
        {
            var students = this.DbContext
                .Students
                .Where(dept => dept.FirstName.StartsWith("J"));

            foreach(var student in students)
            {
                Debug.WriteLine(student.EmailPrimary);
            }
        }
    }
}

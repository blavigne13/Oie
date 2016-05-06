using Oie.DataAccess;
using Oie.DataAccess.DbSets;
using Oie.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            this.Students = new ObservableCollection<Student>();
        }

        public ICommand TestCommand { get; set; }

        public ObservableCollection<Student> Students { get; set; }

        private OieDbContext DbContext { get; set; }

        public void TestEf()
        {
            IEnumerable<Student> students = this.DbContext.Students.Take(50).ToList();
            this.Students.Clear();
            this.Students.AddRange(students);
            foreach(var student in students)
            {
                Debug.WriteLine(student.EmailPrimary);
            }
        }
    }
}

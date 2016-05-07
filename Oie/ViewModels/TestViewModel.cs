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

        public ICollection<Student> Students { get; set; }

        public ObservableCollection<Student> OrderedStudents { get; set; }

        private OieDbContext DbContext { get; set; }

        public void TestEf()
        {
            this.LoadData(students => students.OrderBy(s => s.MajorPrimary));
            this.LoadData(students => students.OrderByDescending(s => s.MajorPrimary));
        }

        public void LoadData(Func<IEnumerable<Student>, IOrderedEnumerable<Student>> orderFunc)
        {
            if (!this.Students.Any())
            {
                this.Students = this.DbContext.Students.Take(50).ToList();
            }

            this.OrderedStudents.Clear();
            this.OrderedStudents.AddRange(orderFunc(this.Students));
        }
    }
}

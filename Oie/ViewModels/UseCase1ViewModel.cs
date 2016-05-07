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
    class UseCase1ViewModel
    {
        public UseCase1ViewModel()
        {
            this.DbContext = new OieDbContext();
            this.UseCase1Command = new DelegateCommand(this.TestEf);
            this.Majors = new ObservableCollection<GroupCount>();
            this.ReverseCommand = new DelegateCommand(this.ReverseCollection);
        }
        public ICommand UseCase1Command { get; set; }
        public ICommand ReverseCommand { get; set; }
        public ObservableCollection<GroupCount> Majors { get; set; }
        private OieDbContext DbContext { get; set; }

        public void TestEf()
        {
            IEnumerable<GroupCount> majors = this
                .DbContext
                .Students
                .GroupBy(s => s.MajorPrimary)
                .Select(g => new GroupCount { Major = g.Key, Count = g.Count() })
                .OrderByDescending(gc => gc.Count)
                .ToList();

            this.Majors.Clear();
            this.Majors.AddRange(majors);

            foreach (var m in Majors)
            {
                Debug.WriteLine(m.Major + " " + m.Count);
            }
        }

        public void ReverseCollection()
        {
            var newOrder = this.Majors.Reverse().ToList();
            this.Majors.Clear();
            this.Majors.AddRange(newOrder);
        }

        public class GroupCount
        {
            public string Major { get; set; }
            public int Count { get; set; }
        }
    }
}

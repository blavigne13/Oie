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
    class UseCase16ViewModel
    {
        public UseCase16ViewModel()
        {
            this.DbContext = new OieDbContext();
            this.Majors = new ObservableCollection<GroupCount>();
            this.UseCase16AscendingCommand = new DelegateCommand(this.AscendingCollection);
            this.UseCase16DescendingCommand = new DelegateCommand(this.DescendingCollection);
        }
        private OieDbContext DbContext { get; set; }
        public ObservableCollection<GroupCount> Majors { get; set; }
        public ICommand UseCase16AscendingCommand { get; set; }
        public ICommand UseCase16DescendingCommand { get; set; }

        public void GetData()
        {
            IEnumerable<GroupCount> majors = this
                .DbContext
                .Students
                .GroupBy(s => s.MajorPrimary)
                .Select(g => new GroupCount { Major = g.Key, Count = g.Count() })
                .OrderByDescending(gc => gc.Count);

            this.Majors.Clear();
            this.Majors.AddRange(majors.ToList());

            //foreach (var m in Majors)
            //{
            //    Debug.WriteLine(m.Major + " " + m.Count);
            //}
        }
        public void AscendingCollection()
        {
            var newOrder = this.Majors.Reverse().ToList();
            this.Majors.Clear();
            this.Majors.AddRange(newOrder);
        }

        public void DescendingCollection()
        {
            var newOrder = this.Majors.ToList();
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

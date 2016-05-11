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
using System.Windows;
using System.Windows.Input;

namespace Oie.ViewModels
{
    class UseCase16ViewModel
    {
        public UseCase16ViewModel()
        {
            this.DbContext = new OieDbContext();
            this.UseCase16Command = new DelegateCommand(this.GetData);

            this.Majors = null;
            this.AscendingMajors = new ObservableCollection<GroupCount>();
            this.DescendingMajors = new ObservableCollection<GroupCount>();
        }

        private OieDbContext DbContext { get; set; }
        public ICommand UseCase16Command { get; set; }
        private IEnumerable<GroupCount> Majors { get; set; }
        public ObservableCollection<GroupCount> AscendingMajors { get; set; }
        public ObservableCollection<GroupCount> DescendingMajors { get; set; }
        public int MaxResults { get; set; } = 10;

        public void GetData()
        {
            if (this.Majors == null)
            {
                this.Majors = this
                .DbContext
                .Students
                .GroupBy(s => s.MajorPrimary)
                .Select(g => new GroupCount { Major = g.Key, Count = g.Count() });

                this.AscendingMajors.AddRange(Majors
                    .OrderBy(gc => gc.Count)
                    .Take(MaxResults));

                this.DescendingMajors.AddRange(Majors
                    .OrderByDescending(gc => gc.Count)
                    .Take(MaxResults));
            }
        }

        public class GroupCount
        {
            public string Major { get; set; }
            public int Count { get; set; }
        }
    }
}

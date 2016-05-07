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
            this.Majors = null; //new ObservableCollection<GroupCount>();
            this.AscendingMajors = new ObservableCollection<GroupCount>();
            this.DescendingMajors = new ObservableCollection<GroupCount>();
            this.BoringMajors = new ObservableCollection<GroupCount>();
            this.UseCase16Command = new DelegateCommand(this.GetData);
            //this.UseCase16AscendingCommand = new DelegateCommand(this.AscendingCollection);
            //this.UseCase16DescendingCommand = new DelegateCommand(this.DescendingCollection);
        }
        private OieDbContext DbContext { get; set; }
        public ICommand UseCase16Command { get; set; }
        //public ICommand UseCase16AscendingCommand { get; set; }
        //public ICommand UseCase16DescendingCommand { get; set; }

        private IEnumerable<GroupCount> Majors = null;
        public ObservableCollection<GroupCount> AscendingMajors { get; set; }
        public ObservableCollection<GroupCount> DescendingMajors { get; set; }
        public ObservableCollection<GroupCount> BoringMajors { get; set; }

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

                this.BoringMajors.AddRange(Majors
                    .Where(gc => gc.Count == 0));
            }

            //foreach (var m in Majors)
            //{
            //    Debug.WriteLine(m.Major + " " + m.Count);
            //}
        }
        //public void AscendingCollection()
        //{
        //    this.GetData();
        //    AscendingMajors.AddRange(Majors.OrderBy(gc => gc.Count));
        //}

        //public void DescendingCollection()
        //{
        //    this.GetData();
        //    AscendingMajors.AddRange(Majors.OrderByDescending(gc => gc.Count));
        //}

        public class GroupCount
        {
            public string Major { get; set; }
            public int Count { get; set; }
        }
    }
}

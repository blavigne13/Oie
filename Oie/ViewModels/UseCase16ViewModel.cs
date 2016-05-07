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
        private Visibility ascendingVisibilty;
        private Visibility descendingVisibilty;
        private Visibility boringVisibilty;

        public UseCase16ViewModel()
        {
            this.DbContext = new OieDbContext();
            this.Majors = null; //new ObservableCollection<GroupCount>();
            this.AscendingMajors = new ObservableCollection<GroupCount>();
            this.DescendingMajors = new ObservableCollection<GroupCount>();
            this.BoringMajors = new ObservableCollection<GroupCount>();

            this.descendingVisibilty = Visibility.Collapsed;
            this.ascendingVisibilty = Visibility.Collapsed;
            this.boringVisibilty = Visibility.Collapsed;

            this.UseCase16Command = new DelegateCommand(this.GetData);
            this.UseCase16DescendingCommand = new DelegateCommand(() =>
            {
                this.descendingVisibilty = Visibility.Visible;
                this.ascendingVisibilty = Visibility.Collapsed;
                this.boringVisibilty = Visibility.Collapsed;
            });
            this.UseCase16AscendingCommand = new DelegateCommand(() =>
            {
                this.descendingVisibilty = Visibility.Collapsed;
                this.ascendingVisibilty = Visibility.Visible;
                this.boringVisibilty = Visibility.Collapsed;
            });
            this.UseCase16BoringCommand = new DelegateCommand(() =>
            {
                this.descendingVisibilty = Visibility.Collapsed;
                this.ascendingVisibilty = Visibility.Collapsed;
                this.boringVisibilty = Visibility.Visible;
            });
        }
        private OieDbContext DbContext { get; set; }
        public ICommand UseCase16Command { get; set; }
        public ICommand UseCase16AscendingCommand { get; set; }
        public ICommand UseCase16DescendingCommand { get; set; }
        public ICommand UseCase16BoringCommand { get; set; }

        private IEnumerable<GroupCount> Majors = null;
        private ObservableCollection<GroupCount> AscendingMajors { get; set; }
        private ObservableCollection<GroupCount> DescendingMajors { get; set; }
        private ObservableCollection<GroupCount> BoringMajors { get; set; }

        public int MaxResults { get; set; } = 100;

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
                    .Where(gc => gc.Count == 4));
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

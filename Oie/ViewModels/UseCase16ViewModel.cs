using Oie.DataAccess;
using Oie.DataAccess.DbSets;
using Oie.Infrastructure;
using Oie.Models;
using Prism.Mvvm;
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
    public class UseCase16ViewModel
    {
        private int maxResults;

        public UseCase16ViewModel()
        {
            this.DbContext = new OieDbContext();
            this.UseCase16Command = new DelegateCommand(this.GetData);

            this.Majors = null;
            this.AscendingMajors = new ObservableCollection<GroupCount>();
            this.DescendingMajors = new ObservableCollection<GroupCount>();
            this.MaxResults = 10;
        }

        private OieDbContext DbContext { get; set; }

        public ICommand UseCase16Command { get; set; }
        
        private IEnumerable<GroupCount> Majors { get; set; }
        
        public ObservableCollection<GroupCount> AscendingMajors { get; set; }
        
        public ObservableCollection<GroupCount> DescendingMajors { get; set; }
        
        public int MaxResults
        {
            get
            {
                return this.maxResults;
            }

            set
            {
                var old = this.maxResults;
                this.maxResults = value;
                if (old != this.maxResults)
                {
                    this.RefreshCollections();
                }
            }
        }

        public void GetData()
        {
            if (this.Majors == null)
            {
                this.Majors = this
                .DbContext
                .Students
                .GroupBy(student => student.MajorPrimary)
                .Select(group => new GroupCount { Name = group.Key, Count = group.Count() })
                .OrderBy(gc => gc.Count);

                this.RefreshCollections();
            }
        }

        public void RefreshCollections()
        {
            if (this.Majors == null)
            {
                return;
            }

            this.AscendingMajors.Clear();
            this.DescendingMajors.Clear();
            this.AscendingMajors.AddRange(this.Majors.Take(MaxResults > 0 ? MaxResults : int.MaxValue));
            this.DescendingMajors.AddRange(this.Majors.Reverse().Take(MaxResults > 0 ? MaxResults : int.MaxValue));
        }
    }
}

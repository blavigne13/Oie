using Oie.DataAccess;
using Oie.DataAccess.DbSets;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Oie.ViewModels
{
    public class UseCase6ViewModel
    {
        public UseCase6ViewModel()
        {
            this.DbContext = new OieDbContext();
            this.AirportPickups = new ObservableCollection<AirportPickup>();
            this.SearchCommand = new DelegateCommand(this.Search);
            this.ClearCommand = new DelegateCommand(this.Clear);
        }

        public ICommand SearchCommand { get; set; }

        public ICommand ClearCommand { get; set; }

        public ObservableCollection<AirportPickup> AirportPickups { get; set; }

        private OieDbContext DbContext { get; set; }

        private void Search()
        {
            IEnumerable<AirportPickup> airportPickups = this
                .DbContext
                .AirportPickups
                .Include(ap => ap.Student)
                .Where(ap => ap.ArrivalDateTime > DateTime.Now)
                .OrderBy(ap => ap.ArrivalDateTime)
                .ToList();

            this.AirportPickups.Clear();
            this.AirportPickups.AddRange(airportPickups);
        }

        private void Clear()
        {
            this.AirportPickups.Clear();
        }
    }
}

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
    public class UseCase2ViewModel
    {
        public UseCase2ViewModel()
        {
            this.DbContext = new OieDbContext();
            this.AirportPickups = new ObservableCollection<AirportPickup>();
            this.SearchCommand = new DelegateCommand(this.Search);
        }

        public ICommand SearchCommand { get; set; }

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
    }
}

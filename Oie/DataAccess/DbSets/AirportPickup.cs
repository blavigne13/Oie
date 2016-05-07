using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oie.DataAccess.DbSets
{
    public class AirportPickup
    {
        [Key, Column(Order=0)]
        public int StudentId { get; set; }

        [Key, Column(Order = 1)]
        public DateTime Created { get; set; }

        public string Arrival { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public string Comments { get; set; }

        public bool? FlightItinerary { get; set; }

        public virtual Student Student { get; set; }
    }
}

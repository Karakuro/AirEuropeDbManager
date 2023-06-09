using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirEuropeDbManager.Data
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public int AirRouteId { get; set; }
        public AirRoute AirRoute { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}

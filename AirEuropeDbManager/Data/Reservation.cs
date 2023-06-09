using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirEuropeDbManager.Data
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int AppUserId { get; set; }
        public int FlightId { get; set; }
        public AppUser AppUser { get; set; }
        public List<ReservedSeat> ReservedSeats { get; set; }
        public Flight Flight { get; set; }
    }
}

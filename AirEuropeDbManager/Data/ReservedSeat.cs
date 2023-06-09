using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirEuropeDbManager.Data
{
    public class ReservedSeat
    {
        public int ReservationId { get; set; }
        public int SeatId { get; set; }
        public Reservation Reservation { get; set; }
        public Seat Seat { get; set; }
    }
}

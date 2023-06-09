using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirEuropeDbManager.Data
{
    public class Seat
    {
        public int SeatId { get; set; }
        public List<ReservedSeat> ReservedSeats { get; set; }
    }
}

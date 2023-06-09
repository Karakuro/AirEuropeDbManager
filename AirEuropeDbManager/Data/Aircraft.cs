using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirEuropeDbManager.Data
{
    public class Aircraft
    {
        public int AircraftId { get; set; }
        public List<AirRoute> AirRoutes { get; set; }
        public List<Seat> Seats { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirEuropeDbManager.Data
{
    public class Airport
    {
        public int AirportId { get; set; }
        public List<AirRoute> DepartureAirports { get; set; }
        public List<AirRoute> ArrivalAirports { get; set; }
    }
}

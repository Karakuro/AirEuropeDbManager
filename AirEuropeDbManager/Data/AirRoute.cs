using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirEuropeDbManager.Data
{
    public class AirRoute
    {
        public int AirRouteId { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public int AircraftId { get; set; }
        [ForeignKey("DepartureAirportId")]
        public Airport DepartureAirport { get; set; }
        [ForeignKey("ArrivalAirportId")]
        public Airport ArrivalAirport { get; set; }
        public Aircraft Aircraft { get; set; }

    }
}

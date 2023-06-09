using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirEuropeDbManager.Data
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string Name { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}

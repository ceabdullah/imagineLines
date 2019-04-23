using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Dto
{
    public class ShipDTO
    {
        public int id { get; set; }
        public SalesUnitDTO salesUnit { get; set; }
        public string name { get; set; }
    }
}

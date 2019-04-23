using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Dto
{
    public class BookingDTO
    {
        public int id { get; set; }
        public ShipDTO ship { get; set; }
        public DateTime bookingDate { get; set; }
        public float price { get; set; }
    }
}

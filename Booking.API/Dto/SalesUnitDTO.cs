using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Dto
{
    public class SalesUnitDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string currency { get; set; }

        public float totalPrice { get; set; }
        public List<BookingDTO> bookings { get; set; }
    }
}

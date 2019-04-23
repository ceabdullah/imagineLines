using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Model
{
    [Table("booking")]
    public class Booking
    {
        [Key]
        public int id { get; set; }
        public Ship ship { get; set; }
        public DateTime bookingDate { get; set; }
        public float price { get; set; }
    }
}

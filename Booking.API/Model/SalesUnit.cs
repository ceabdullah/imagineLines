using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Model
{
    [Table("salesUnit")]
    public class SalesUnit
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string currency { get; set; }
    }
}

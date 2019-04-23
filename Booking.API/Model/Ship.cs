using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Model
{
    [Table("ship")]
    public class Ship
    {
        [Key]
        public int id { get; set; }
        public SalesUnit salesUnit { get; set; }
        public string name { get; set; }
    }
}

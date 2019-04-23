using Booking.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Infrastructure
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        { }

        public DbSet<Model.Booking> Bookings { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<SalesUnit> SalesUnits { get; set; }
    }
}

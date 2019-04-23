using Booking.API.Infrastructure;
using Booking.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Repositories
{
    public class SalesUnitDataRepository : ISalesUnitDataRepository<SalesUnit>
    {
        private readonly BookingContext _bookingContext;

        public SalesUnitDataRepository(BookingContext bookingContext)
        {
            _bookingContext = bookingContext;
        }

        public Task Add(SalesUnit entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(SalesUnit entity)
        {
            throw new NotImplementedException();
        }

        public Task<SalesUnit> Get(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SalesUnit>> GetAll()
        {
            return await _bookingContext.SalesUnits.Select(a => new SalesUnit
            {
                id = a.id,
                country = a.country,
                currency = a.currency,
                name = a.name
            }).ToListAsync();
        }

        public Task Update(SalesUnit dbEntity, SalesUnit entity)
        {
            throw new NotImplementedException();
        }
    }
}

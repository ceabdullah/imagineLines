using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.API.Infrastructure;
using Booking.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Booking.API.Repositories
{
    public class BookingDataRepository : IBookingDataRepository<Model.Booking>
    {
        private readonly BookingContext _bookingContext;

        public BookingDataRepository(BookingContext bookingContext)
        {
            _bookingContext = bookingContext;
        }

        public async Task Add(Model.Booking entity)
        {
            _bookingContext.Add(entity);
            await _bookingContext.SaveChangesAsync();
        }

        public async Task Delete(Model.Booking entity)
        {
            _bookingContext.Remove(entity);
            await _bookingContext.SaveChangesAsync();
        }

        public async Task<Model.Booking> Get(long id)
        {
            return await _bookingContext.Bookings.Where(b => b.id == id).Select(a => new Model.Booking
            {
                bookingDate = a.bookingDate,
                id = a.id,
                price = a.price,
                ship = new Ship
                {
                    id = a.ship.id,
                    name = a.ship.name,
                    salesUnit = new SalesUnit
                    {
                        id = a.ship.salesUnit.id,
                        name = a.ship.salesUnit.name,
                        country = a.ship.salesUnit.country,
                        currency = a.ship.salesUnit.currency
                    }
                }
            }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Model.Booking>> GetAll()
        {
            return await _bookingContext.Bookings.Select(a => new Model.Booking
            {
                bookingDate = a.bookingDate,
                id = a.id,
                price = a.price,
                ship = new Ship
                {
                    id = a.ship.id,
                    name = a.ship.name,
                    salesUnit = new SalesUnit
                    {
                        id = a.ship.salesUnit.id,
                        name = a.ship.salesUnit.name,
                        country = a.ship.salesUnit.country,
                        currency = a.ship.salesUnit.currency
                    }
                }
            }).ToListAsync();
        }

        public IEnumerable<Model.Booking> GetAllBySalesUnitId(int salesUnitId)
        {
            return _bookingContext.Bookings.Where(x => x.ship.salesUnit.id == salesUnitId).Select(a => new Model.Booking
            {
                bookingDate = a.bookingDate,
                id = a.id,
                price = a.price,
                ship = new Ship
                {
                    id = a.ship.id,
                    name = a.ship.name,
                    salesUnit = new SalesUnit
                    {
                        id = a.ship.salesUnit.id,
                        name = a.ship.salesUnit.name,
                        country = a.ship.salesUnit.country,
                        currency = a.ship.salesUnit.currency
                    }
                }
            }).ToList();
        }

        public async Task Update(Model.Booking dbEntity, Model.Booking entity)
        {
            dbEntity.bookingDate = entity.bookingDate;
            dbEntity.price = entity.price;
            dbEntity.ship = entity.ship;
            await _bookingContext.SaveChangesAsync();
        }
    }
}

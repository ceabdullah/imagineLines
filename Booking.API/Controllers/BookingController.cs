using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Booking.API.Dto;
using Booking.API.Repositories;
using Booking.API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingDataRepository<Model.Booking> _bookingDataRepository;
        private readonly ISalesUnitDataRepository<Model.SalesUnit> _salesUnitDataRepository;

        public BookingController
            (
            IBookingDataRepository<Model.Booking> bookingDataRepository,
            ISalesUnitDataRepository<Model.SalesUnit> salesUnitDataRepository
            )
        {
            _bookingDataRepository = bookingDataRepository;
            _salesUnitDataRepository = salesUnitDataRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<BookingDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> Get()
        {
            var bookingList = await _bookingDataRepository.GetAll();

            if (bookingList is null)
            {
                return Ok();
            }

            return Ok(bookingList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookingDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<BookingDTO>> Get(int id)
        {
            var booking = await _bookingDataRepository.Get(id);

            if (booking is null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpGet("{minDate}/{maxDate}")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<SalesUnitDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesUnitDTO>> GetByDateRangeBookingIdShipName(DateTime minDate, DateTime maxDate, int? bookingId = null, string shipName = null)
        {
            var salesUnits = await _salesUnitDataRepository.GetAll();

            if (salesUnits is null)
            {
                return Ok();
            }

            var salesUnitsDTO = salesUnits.Select(a => new SalesUnitDTO
            {
                id = a.id,
                name = a.name,
                country = a.country,
                currency = a.currency,
                bookings = _bookingDataRepository.GetAllBySalesUnitId(a.id).Where(y => y.bookingDate >= minDate && y.bookingDate <= maxDate).Select(x => new BookingDTO
                {
                    id = x.id,
                    price = x.price,
                    bookingDate = x.bookingDate,
                    ship = new ShipDTO
                    {
                        id = x.ship.id,
                        name = x.ship.name
                    }
                }).ToList(),
                totalPrice = _bookingDataRepository.GetAllBySalesUnitId(a.id).Where(y => y.bookingDate >= minDate && y.bookingDate <= maxDate)
                .Select(x => x.price).Sum(x => x)
            }).ToList();

            if (bookingId != null)
            {
                salesUnitsDTO = salesUnitsDTO.Where(a => a.bookings.Any(b => b.id == bookingId)).ToList();
            }

            if (!String.IsNullOrEmpty(shipName))
            {
                salesUnitsDTO = salesUnitsDTO.Where(a => a.bookings.Any(b => b.ship.name.ToLower().Contains(shipName.ToLower()))).ToList();
            }

            if (salesUnitsDTO is null)
            {
                return Ok();
            }

            return Ok(salesUnitsDTO);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> Post([FromBody] BookingDTO booking)
        {
            if (booking == null)
            {
                return BadRequest();
            }

            var bookingToCreate = new Model.Booking
            {
                id = booking.id,
                bookingDate = booking.bookingDate,
                price = booking.price,
                ship = new Model.Ship
                {
                    id = booking.ship.id,
                    name = booking.ship.name,
                    salesUnit = new Model.SalesUnit
                    {
                        id = booking.ship.salesUnit.id,
                        name = booking.ship.salesUnit.name,
                        country = booking.ship.salesUnit.country,
                        currency = booking.ship.salesUnit.currency
                    }
                }
            };

            await _bookingDataRepository.Add(bookingToCreate);

            return CreatedAtAction(nameof(Post), new { id = booking.id }, null);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> Put(int id, [FromBody] BookingDTO booking)
        {
            if (id < 1 || booking is null)
            {
                return BadRequest();
            }

            var bookingToUpdate = await _bookingDataRepository.Get(id);

            var bookingNew = new Model.Booking
            {
                id = booking.id,
                bookingDate = booking.bookingDate,
                price = booking.price,
                ship = new Model.Ship
                {
                    id = booking.ship.id,
                    name = booking.ship.name,
                    salesUnit = new Model.SalesUnit
                    {
                        id = booking.ship.salesUnit.id,
                        name = booking.ship.salesUnit.name,
                        country = booking.ship.salesUnit.country,
                        currency = booking.ship.salesUnit.currency
                    }
                }
            };

            await _bookingDataRepository.Update(bookingToUpdate, bookingNew);

            return CreatedAtAction(nameof(Put), new { id = booking.id }, null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var campaignToDelete = await _bookingDataRepository.Get(id);

            if (campaignToDelete is null)
            {
                return NotFound();
            }

            await _bookingDataRepository.Get(id);

            return NoContent();
        }
    }
}
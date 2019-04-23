using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.Repositories
{
    public interface IBookingDataRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> GetAllBySalesUnitId(int salesUnitId);
        Task<TEntity> Get(long id);
        Task Add(TEntity entity);
        Task Update(TEntity dbEntity, TEntity entity);
        Task Delete(TEntity entity);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Domain.Contracts.Repositories
{
    public interface ITruckRepository
    {
        Task<IEnumerable<Truck>> GetAll(bool asNoTracking = true);
        Task<Truck> GetById(Guid id, bool asNoTracking = true);
        Task<Truck> SaveOrUpdate(Truck truck);
        Task<bool> Remove(Guid id);
        Task Commit();
    }
}

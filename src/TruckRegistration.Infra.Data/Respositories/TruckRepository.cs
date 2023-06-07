using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckRegistration.Domain.Contracts.Repositories;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Infra.Data.Context;

namespace TruckRegistration.Infra.Data.Respositories
{
    public class TruckRepository : ITruckRepository
    {
        protected readonly SqlServerDataContext Db;
        protected readonly DbSet<Truck> DbSet;

        public TruckRepository(SqlServerDataContext context)
        {
            Db = context;
            DbSet = Db.Set<Truck>();
        }

        public async Task<IEnumerable<Truck>> GetAll(bool asNoTracking = true)
        {
            if (!asNoTracking)
            {
                return await Db.Truck.ToListAsync();
            }

            return await Db.Truck.AsNoTracking().ToListAsync();
        }

        public async Task<Truck> GetById(Guid id, bool asNoTracking = true)
        {
            if (!asNoTracking)
            {
                return await Db.Truck
                    .Where(r => r.Id.Equals(id))
                    .FirstOrDefaultAsync();
            }

            return await Db.Truck
                .Where(r => r.Id.Equals(id))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Truck> SaveOrUpdate(Truck truck)
        {
            if (await GetById(truck.Id) != null)
            {
                DbSet.Update(truck);
            }
            else
            {
                DbSet.Add(truck);
            }

            return truck;
        }

        public async Task<bool> Remove(Guid id)
        {
            var truck = await GetById(id);

            if (truck != null)
            {
                DbSet.Remove(truck);
                return true;
            }

            return false;
        }

        public async Task Commit()
        {
            await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}

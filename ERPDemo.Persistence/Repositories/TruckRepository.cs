using ERPDemo.Core.Repositories;
using ERPDemo.Core.ValueObjects;
using ERPDemo.Persistence.Data.Entities;
using ERPDemo.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Truck = ERPDemo.Core.Entities.Truck;

namespace ERPDemo.Persistence.Repositories
{
    internal class TruckRepository : ITruckRepository
    {
        private readonly ErpDemoDbContext erpDemoDbContext;

        public TruckRepository(ErpDemoDbContext erpDemoDbContext)
        {
            this.erpDemoDbContext = erpDemoDbContext;
        }

        public async Task CreateTruckAsync(Truck truck, CancellationToken cancellationToken)
        {
            var dbTruck = truck.AsDbEntity();
            await this.erpDemoDbContext.Trucks.AddAsync(dbTruck);
            await this.erpDemoDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteTruckAsync(TruckId truckId, CancellationToken cancellationToken)
        {
            var truckToRemove = await this.erpDemoDbContext.Trucks.SingleOrDefaultAsync(t => t.Code == truckId.Value);
            if (truckToRemove is not null)
            {
                this.erpDemoDbContext.Trucks.Remove(truckToRemove);
                await this.erpDemoDbContext.SaveChangesAsync(cancellationToken);
            }

        }

        public Task<Truck> GetTruckAsync(TruckId truckId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> TruckExistsAsync(TruckId truckId, CancellationToken cancellationToken)
        {
            return await this.erpDemoDbContext.Trucks.AnyAsync(t => t.Code == truckId.Value);
        }

        public Task UpdateTruckAsync(Truck truck, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

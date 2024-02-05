using ERPDemo.Core.Entities;
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

        public async Task<Truck?> GetTruckAsync(TruckId truckId, CancellationToken cancellationToken)
        {
            var dbTruck = await this.erpDemoDbContext.Trucks.SingleOrDefaultAsync(t => t.Code == truckId.Value);
            if (dbTruck is null)
                return null;

            return dbTruck.AsCoreEntity();
        }

        public async Task<bool> TruckExistsAsync(TruckId truckId, CancellationToken cancellationToken)
        {
            return await this.erpDemoDbContext.Trucks.AnyAsync(t => t.Code == truckId.Value);
        }

        public async Task UpdateTruckAsync(Truck truck, CancellationToken cancellationToken)
        {
            var dbTruck = await this.erpDemoDbContext.Trucks.SingleOrDefaultAsync(t => t.Code == truck.Id.Value);
            if (dbTruck is null)
                throw new InvalidOperationException("Truck being updated no longer exists.");

            dbTruck.Name = truck.Name;
            dbTruck.Description = truck.Description;
            dbTruck.StatusId = truck.CurrentStatus.Value;

            await this.erpDemoDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

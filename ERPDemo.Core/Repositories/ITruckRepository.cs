using ERPDemo.Core.Entities;
using ERPDemo.Core.ValueObjects;

namespace ERPDemo.Core.Repositories
{
    public interface ITruckRepository
    {
        Task<Truck?> GetTruckAsync(TruckId truckId, CancellationToken cancellationToken);
        Task<bool> TruckExistsAsync(TruckId truckId, CancellationToken cancellationToken);
        Task CreateTruckAsync(Truck truck, CancellationToken cancellationToken);
        Task UpdateTruckAsync(Truck truck, CancellationToken cancellationToken);
        Task DeleteTruckAsync(TruckId truckId, CancellationToken cancellationToken);
    }
}
    
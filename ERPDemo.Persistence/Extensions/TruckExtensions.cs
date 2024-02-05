using ERPDemo.Core.Entities;
using ERPDemo.Core.ValueObjects;
using DbTruck = ERPDemo.Persistence.Data.Entities.Truck;

namespace ERPDemo.Persistence.Extensions
{
    internal static class TruckExtensions
    {
        public static DbTruck AsDbEntity(this Truck truck)
        {
            return new DbTruck
            {
                 Code = truck.Code,
                 Name = truck.Name,
                 Description = truck.Description,
                 StatusId = truck.CurrentStatus.Value
            };
        }

        public static Truck AsCoreEntity(this DbTruck dbTruck)
        {
            var status = TruckStatus.FromValue(dbTruck.StatusId);
            return Truck.Create(dbTruck.Code, dbTruck.Name, dbTruck.Description, status);
        }
    }
}

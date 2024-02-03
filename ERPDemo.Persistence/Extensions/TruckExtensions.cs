using ERPDemo.Core.Entities;
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
    }
}

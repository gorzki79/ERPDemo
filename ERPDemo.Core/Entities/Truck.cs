using ERPDemo.Core.Entities.Base;
using ERPDemo.Core.ValueObjects;

namespace ERPDemo.Core.Entities
{
    public class Truck : AggregatedRoot<TruckId>
    {
        public string Code => this.Id.Value;
        public string Name { get; }
        public string? Description { get; }
        public TruckStatus CurrentStatus { get; }

        internal Truck(string code, string name, string? description, TruckStatus currentStatus)
        {
            Id = new TruckId(code);
            Name = name;
            Description = description;
            CurrentStatus = currentStatus;
        }

        public static Truck Create(string code, string name, string? description, TruckStatus currentStatus)
        {
            return new Truck(code, name, description, currentStatus);
        }

        public static Truck CreateNew(string code, string name, string? description)
        {
            var truck = new Truck(code, name, description, TruckStatus.OutOfService);
            return truck;
        }

    }
}

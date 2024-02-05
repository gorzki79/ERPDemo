using ERPDemo.Core.Entities.Base;
using ERPDemo.Core.ValueObjects;

namespace ERPDemo.Core.Entities
{
    public class Truck : AggregatedRoot<TruckId>
    {
        public string Code => this.Id.Value;
        public string Name { get; private set;  }
        public string? Description { get; private set; }
        public TruckStatus CurrentStatus { get; private set; }

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

        public void Update(string name, string? description, TruckStatus? status)
        {
            this.Name = name;
            this.Description = description;
            if (status is not null)
            {
                UpdateStatus(status);
            }
        }

        private void UpdateStatus(TruckStatus status)
        {
            //TODO
        }
    }
}

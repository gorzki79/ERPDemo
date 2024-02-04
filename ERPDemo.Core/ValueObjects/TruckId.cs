namespace ERPDemo.Core.ValueObjects
{
    public class TruckId : EntityId<string>
    {
        public TruckId(string value) 
            : base(value)
        {
        }

        public static implicit operator TruckId(string value) => new TruckId(value);
    }
}

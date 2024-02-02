namespace ERPDemo.Core.ValueObjects
{
    public class TruckStatus : IComparable<TruckStatus>, IEquatable<TruckStatus>
    {
        public static TruckStatus OutOfService { get; } = new TruckStatus(0, "Out Of Service");
        public static TruckStatus Loading { get; } = new TruckStatus(1, "Loading");
        public static TruckStatus ToJob { get; } = new TruckStatus(2, "To Job");
        public static TruckStatus AtJob { get; } = new TruckStatus(3, "At Job");
        public static TruckStatus Returning { get; } = new TruckStatus(4, "Returning");

        public string Name { get; private set; }
        public int Value { get; private set; }

        private TruckStatus(int val, string name)
        {
            Value = val;
            Name = name;
        }

        private static IEnumerable<TruckStatus> GetAllStates()
        {
            return new[] { OutOfService, Loading, ToJob, AtJob, Returning };
        }

        public static TruckStatus FromString(string statusString)
        {
            return GetAllStates().Single(r => String.Equals(r.Name, statusString, StringComparison.OrdinalIgnoreCase));
        }

        public static TruckStatus FromValue(int value)
        {
            return GetAllStates().Single(r => r.Value == value);
        }

        public int CompareTo(TruckStatus? other)
        {
            if (other is null)
                return 1;

            return this.Value.CompareTo(other.Value);
        }

        public bool Equals(TruckStatus? other)
        {
            if (other is null)
                return false;

            return this.Value.Equals(other.Value);
        }

        public override int GetHashCode() => this.Value.GetHashCode();
    }
}

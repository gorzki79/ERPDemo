using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

namespace ERPDemo.Core.ValueObjects
{
    public class TruckStatus : IComparable<TruckStatus>, IEquatable<TruckStatus>
    {
        public static TruckStatus OutOfService { get; } = new TruckStatus(0, "Out Of Service");
        public static TruckStatus Loading { get; } = new TruckStatus(1, "Loading");
        public static TruckStatus ToJob { get; } = new TruckStatus(2, "To Job");
        public static TruckStatus AtJob { get; } = new TruckStatus(3, "At Job");
        public static TruckStatus Returning { get; } = new TruckStatus(4, "Returning");

        private static Dictionary<TruckStatus, TruckStatus[]> NextAvailableStatusesDictionary = new Dictionary<TruckStatus, TruckStatus[]>
        {
            { OutOfService, new TruckStatus[] { Loading, ToJob, AtJob, Returning } },
            { Loading, new TruckStatus[] { ToJob, OutOfService } },
            { ToJob, new TruckStatus[] { AtJob, OutOfService } },
            { AtJob, new TruckStatus[] { Returning, OutOfService } },
            { Returning, new TruckStatus[] { Loading, OutOfService } }
        };

        public string Name { get; private set; }
        public int Value { get; private set; }

        public IReadOnlyCollection<TruckStatus> NextAvailableStatuses => NextAvailableStatusesDictionary[this].AsReadOnly();

        private TruckStatus(int val, string name)
        {
            Value = val;
            Name = name;
        }

        private static IEnumerable<TruckStatus> GetAllStatuses()
        {
            return new[] { OutOfService, Loading, ToJob, AtJob, Returning };
        }

        public static TruckStatus FromString(string statusString)
        {
            return GetAllStatuses().Single(r => String.Equals(r.Name, statusString, StringComparison.OrdinalIgnoreCase));
        }

        public static TruckStatus FromValue(int value)
        {
            return GetAllStatuses().Single(r => r.Value == value);
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

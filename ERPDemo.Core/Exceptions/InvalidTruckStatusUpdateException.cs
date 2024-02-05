using ERPDemo.Core.ValueObjects;

namespace ERPDemo.Core.Exceptions
{
    public class InvalidTruckStatusUpdateException : Exception
    {
        public TruckStatus CurrentStatus { get; }
        public TruckStatus AttemptedStatus { get; }

        public InvalidTruckStatusUpdateException(TruckStatus currentStatus, TruckStatus attemptedStatus)
        {
            CurrentStatus = currentStatus;
            AttemptedStatus = attemptedStatus;
        }

    }
}

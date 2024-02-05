using ERPDemo.Core.Repositories;
using ERPDemo.Core.ValueObjects;

namespace ERPDemo.Application.Commands.Handlers
{
    public class UpdateTruckCommandHandler : ICommandHandler<UpdateTruckCommand, string>
    {
        private readonly ITruckRepository truckRepository;

        public UpdateTruckCommandHandler(ITruckRepository truckRepository)
        {
            this.truckRepository = truckRepository;
        }

        public async Task<string> Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
        {
            var truck = await this.truckRepository.GetTruckAsync(request.Code, cancellationToken);
            TruckStatus? status = string.IsNullOrEmpty(request.Status) ? null : TruckStatus.FromString(request.Status);
            truck.Update(request.Name, request.Description, status);
            await this.truckRepository.UpdateTruckAsync(truck, cancellationToken);
            return truck.Code;
        }
    }
}

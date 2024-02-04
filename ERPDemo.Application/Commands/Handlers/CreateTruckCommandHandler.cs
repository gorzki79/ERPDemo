using ERPDemo.Core.Entities;
using ERPDemo.Core.Repositories;

namespace ERPDemo.Application.Commands.Handlers
{
    public class CreateTruckCommandHandler : ICommandHandler<CreateTruckCommand, string>
    {
        private readonly ITruckRepository truckRepository;

        public CreateTruckCommandHandler(ITruckRepository truckRepository)
        {
            this.truckRepository = truckRepository;
        }

        public async Task<string> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            Truck truck = Truck.CreateNew(request.Code, request.Name, request.Description);
            await this.truckRepository.CreateTruckAsync(truck, cancellationToken);
            return truck.Code;
        }
    }
}

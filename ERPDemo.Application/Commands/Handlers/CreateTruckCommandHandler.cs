using ERPDemo.Core.Entities;
using ERPDemo.Core.Repositories;

namespace ERPDemo.Application.Commands.Handlers
{
    public class CreateTruckCommandHandler : ICommandHandler<CreateTruckCommand>
    {
        private readonly ITruckRepository truckRepository;

        public CreateTruckCommandHandler(ITruckRepository truckRepository)
        {
            this.truckRepository = truckRepository;
        }

        public async Task Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            Truck truck = Truck.CreateNew(request.Args.Code, request.Args.Name, request.Args.Description);
            await this.truckRepository.CreateTruckAsync(truck, cancellationToken);
        }
    }
}

using ERPDemo.Core.Repositories;

namespace ERPDemo.Application.Commands.Handlers
{
    public class DeleteTruckCommandHandler : ICommandHandler<DeleteTruckCommand, string>
    {
        private readonly ITruckRepository truckRepository;

        public DeleteTruckCommandHandler(ITruckRepository truckRepository)
        {
            this.truckRepository = truckRepository;
        }

        public async Task<string> Handle(DeleteTruckCommand request, CancellationToken cancellationToken)
        {
            await this.truckRepository.DeleteTruckAsync(request.TruckCode, cancellationToken);
            return request.TruckCode;
        }
    }
}

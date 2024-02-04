using ERPDemo.Core.Repositories;
using ERPDemo.Core.ValueObjects;
using FluentValidation;

namespace ERPDemo.Application.Commands.Validation
{
    public class DeleteTruckCommandValidator : AbstractValidator<DeleteTruckCommand>
    {
        private readonly ITruckRepository truckRepository;

        public DeleteTruckCommandValidator(ITruckRepository truckRepository)
        {
            this.truckRepository = truckRepository;

            RuleFor(cmd => cmd.TruckCode).NotEmpty();
            RuleFor(cmd => cmd.TruckCode).Custom((value, ctx) =>
            {
                var truckExists = this.truckRepository.TruckExistsAsync(new TruckId(value), CancellationToken.None).Result;
                if (!truckExists)
                {
                    ctx.AddFailure("Code", "Truck Code must exist.");
                }
            });
        }
    }
}

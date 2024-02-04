using ERPDemo.Core.Repositories;
using ERPDemo.Core.ValueObjects;
using FluentValidation;

namespace ERPDemo.Application.Commands.Validation
{
    public class CreateTruckCommandValidator : AbstractValidator<CreateTruckCommand>
    {
        private readonly ITruckRepository truckRepository;

        public CreateTruckCommandValidator(ITruckRepository truckRepository)
        {
            this.truckRepository = truckRepository;

            RuleFor(cmd => cmd.Code).NotEmpty();
            RuleFor(cmd => cmd.Code).Length(1, 200);
            RuleFor(cmd => cmd.Code).Custom((value, ctx) => 
            {
                var truckExists = this.truckRepository.TruckExistsAsync(new TruckId(value), CancellationToken.None).Result;
                if (truckExists)
                {
                    ctx.AddFailure("Code", "Truck Code must be unique.");
                }
            });

            RuleFor(cmd => cmd.Name).NotEmpty();
            RuleFor(cmd => cmd.Name).Length(1, 200);

            RuleFor(cmd => cmd.Description).MaximumLength(4000);
        }
    }
}

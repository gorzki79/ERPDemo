using ERPDemo.Core.Repositories;
using ERPDemo.Core.ValueObjects;
using FluentValidation;

namespace ERPDemo.Application.Commands.Validation
{
    public class UpdateTruckCommandValidator : AbstractValidator<UpdateTruckCommand>
    {
        private readonly ITruckRepository truckRepository;

        public UpdateTruckCommandValidator(ITruckRepository truckRepository)
        {
            this.truckRepository = truckRepository;

            RuleFor(cmd => cmd.Code).NotEmpty();
            RuleFor(cmd => cmd.Code).Length(1, 200);
            RuleFor(cmd => cmd.Code).Custom((value, ctx) =>
            {
                var truckExists = this.truckRepository.TruckExistsAsync(new TruckId(value), CancellationToken.None).Result;
                if (!truckExists)
                {
                    ctx.AddFailure("Code", "Truck Code must exist.");
                }
            });

            RuleFor(cmd => cmd.Name).NotEmpty();
            RuleFor(cmd => cmd.Name).Length(1, 200);

            RuleFor(cmd => cmd.Description).MaximumLength(4000);

            RuleFor(cmd => cmd.Status).Custom((value, ctx) =>
            {
                if (string.IsNullOrEmpty(value))
                    return;

                try
                {
                    TruckStatus.FromString(value);
                }
                catch(InvalidOperationException ex)
                {
                    ctx.AddFailure("Status", $"Unknown status value: {value}.");
                }
            });
        }
    }
}

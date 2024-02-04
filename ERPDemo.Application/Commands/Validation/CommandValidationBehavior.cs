using FluentValidation;
using MediatR;

namespace ERPDemo.Application.Commands.Validation
{
    public class CommandValidationBehavior<TCommand, TCommandResult> : IPipelineBehavior<TCommand, TCommandResult>
        where TCommand : notnull, ICommand<TCommandResult>
    {
        private readonly IEnumerable<IValidator<TCommand>> validators;

        public CommandValidationBehavior(IEnumerable<IValidator<TCommand>> validators)
        {
            this.validators = validators;
        }

        public async Task<TCommandResult> Handle(TCommand request, RequestHandlerDelegate<TCommandResult> next, CancellationToken cancellationToken)
        {
            if (!this.validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TCommand>(request);
            var errors = this.validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .GroupBy(
                    x => x.PropertyName,
                    x => x.ErrorMessage,
                    (propertyName, errorMessages) => new
                    {
                        Key = propertyName,
                        Values = errorMessages.Distinct().ToArray()
                    })
                .ToDictionary(x => x.Key, x => x.Values);
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
            return await next();
        }
    }
}

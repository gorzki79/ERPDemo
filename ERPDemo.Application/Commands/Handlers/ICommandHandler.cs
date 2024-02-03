using MediatR;

namespace ERPDemo.Application.Commands.Handlers
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
        where TCommand : class, ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TCommandResult> : IRequestHandler<TCommand, TCommandResult>
    where TCommand : class, ICommand<TCommandResult>
    {
    }
}

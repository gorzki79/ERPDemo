using MediatR;

namespace ERPDemo.Application.Commands
{
    public interface ICommand : IRequest
    {

    }

    public interface ICommand<out TCommandResult> : IRequest<TCommandResult>, ICommand
    {
    }
}

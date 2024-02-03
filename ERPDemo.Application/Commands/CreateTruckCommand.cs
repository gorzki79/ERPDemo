using ERPDemo.Application.Commands.Args;

namespace ERPDemo.Application.Commands
{
    public record CreateTruckCommand(CreateTruckArgs Args) : ICommand
    {
    }
}

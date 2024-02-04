using ERPDemo.Application.Commands.Args;

namespace ERPDemo.Application.Commands
{
    public record CreateTruckCommand(string Code, string Name, string? Description) : ICommand<string>
    {
        public CreateTruckCommand(CreateTruckArgs args) : this(args.Code, args.Name, args.Description) {}
    }
}

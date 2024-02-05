using ERPDemo.Application.Commands.Args;

namespace ERPDemo.Application.Commands
{
    public record UpdateTruckCommand(string Code, string Name, string? Description, string? Status) : ICommand<string>
    {
        public UpdateTruckCommand(string code, UpdateTruckArgs args) : this(code, args.Name, args.Description, args.Status) { }
    }
}

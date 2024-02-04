namespace ERPDemo.Application.Commands
{
    public record DeleteTruckCommand(string TruckCode) : ICommand<string>
    {
    }
}

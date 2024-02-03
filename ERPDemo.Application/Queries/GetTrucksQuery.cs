using ERPDemo.Application.Queries.Dto;

namespace ERPDemo.Application.Queries
{
    public record GetTrucksQuery(string? TruckCode = null, string? TruckName = null, string? TruckStatus = null) 
        : IQuery<IEnumerable<TruckInfo>>;
}
    
using ERPDemo.Application.Queries.Dto;

namespace ERPDemo.Application.Queries
{
    public record GetTruckQuery(string Code) : IQuery<TruckInfo?>;
}

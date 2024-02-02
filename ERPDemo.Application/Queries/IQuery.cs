using MediatR;

namespace ERPDemo.Application.Queries
{
    public interface IQuery<out TQueryResult> : IRequest<TQueryResult>
    {
    }
}

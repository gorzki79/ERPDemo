using ERPDemo.Application.Queries;
using ERPDemo.Persistence.Data.Entities;
using MediatR;

namespace ERPDemo.Persistence.Query.Handlers
{
    public abstract class BaseQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        protected readonly ErpDemoDbContext DbContext;

        protected BaseQueryHandler(ErpDemoDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public abstract Task<TResult> Handle(TQuery request, CancellationToken cancellationToken);
    }
}

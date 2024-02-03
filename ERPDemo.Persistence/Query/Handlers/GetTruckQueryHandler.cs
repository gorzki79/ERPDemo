using ERPDemo.Application.Queries;
using ERPDemo.Application.Queries.Dto;
using ERPDemo.Persistence.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERPDemo.Persistence.Query.Handlers
{
    public class GetTruckQueryHandler : BaseQueryHandler<GetTruckQuery, TruckInfo?>
    {
        public GetTruckQueryHandler(ErpDemoDbContext dbContext) 
            : base(dbContext)
        {
        }

        public override async Task<TruckInfo?> Handle(GetTruckQuery request, CancellationToken cancellationToken)
        {
            return await this.DbContext.Trucks
                .Where(t => t.Code == request.Code)
                .Select(t => new TruckInfo(t.Code, t.Name, t.Description, t.Status.Name))
                .SingleOrDefaultAsync();
        }
    }
}

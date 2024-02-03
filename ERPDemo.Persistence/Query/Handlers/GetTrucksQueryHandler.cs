using ERPDemo.Application.Queries;
using ERPDemo.Application.Queries.Dto;
using ERPDemo.Persistence.Data.Entities;
using Microsoft.EntityFrameworkCore;
    
namespace ERPDemo.Persistence.Query.Handlers
{
    public class GetTrucksQueryHandler : BaseQueryHandler<GetTrucksQuery, IEnumerable<TruckInfo>>
    {
        public GetTrucksQueryHandler(ErpDemoDbContext dbContext) 
            : base(dbContext)
        {
        }

        public override async Task<IEnumerable<TruckInfo>> Handle(GetTrucksQuery request, CancellationToken cancellationToken)
        {
            var query = this.DbContext.Trucks.AsQueryable();

            if (!string.IsNullOrEmpty(request.TruckCode))
            {
                query = query.Where(t => t.Code.Contains(request.TruckCode));
            }

            if (!string.IsNullOrEmpty(request.TruckName))
            {
                query = query.Where(t => t.Name.Contains(request.TruckName));
            }

            if (!string.IsNullOrEmpty(request.TruckStatus))
            {
                var ts = ERPDemo.Core.ValueObjects.TruckStatus.FromString(request.TruckStatus);
                query = query.Where(t => t.StatusId == ts.Value);
            }

            return await query.Select(t => new TruckInfo(t.Code, t.Name, t.Description, t.Status.Name)).ToListAsync();
        }
    }
}

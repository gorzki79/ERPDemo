using ERPDemo.Application;
using ERPDemo.Application.Commands.Handlers;
using ERPDemo.Infrastructure;
using ERPDemo.Persistence.Query.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetTrucksQueryHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CreateTruckCommandHandler).Assembly);
});
builder.Services.AddApplication();
builder.Services.AddInfrastructure();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseInfrastructure();

app.MapControllers();

app.Run();

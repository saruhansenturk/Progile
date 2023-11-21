using Microsoft.EntityFrameworkCore;
using Progile.Application;
using Progile.Persistence;
using Progile.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("ProgileConnectionString");

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior",
    true); // bunun yerine datetime.now yerine utcnow kullanilabilir.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices();

builder.Services.AddDbContext<ProgileContext>(opt =>
{
    opt.UseNpgsql(connection);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

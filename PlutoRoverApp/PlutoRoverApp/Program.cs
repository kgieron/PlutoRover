using PlutoRoverApp.Abstractions;
using PlutoRoverApp.CQS.Commands;
using PlutoRoverApp.CQS.Queries;
using PlutoRoverApp.DAL;
using PlutoRoverApp.Handlers.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPlutoRoverRepository, PlutoRoverRepository>();
builder.Services.AddTransient<IMovePlutoRoverCommand, MovePlutoRoverCommand>();
builder.Services.AddTransient<IGetCurrentPlutoRoverPositionQuery, GetCurrentPlutoRoverPositionQuery>();
builder.Services.AddTransient<IMovementsDecoder, MovementsDecoder>();

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

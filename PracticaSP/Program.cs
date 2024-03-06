using DAC.Configuration;
using DAC.Interfaces;
using DAC.PruebaDac;

using PracticaSP.InterfacesBussines;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<CladenaConexion>(builder.Configuration.GetSection("C"));
builder.Services.AddScoped<IEmpleadoRepo, EmpleadoRepositorio>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

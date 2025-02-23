
using Microsoft.EntityFrameworkCore;
using SalesdatePrediction.Application.Interfaces;
using SalesdatePrediction.Application.Services;
using SalesdatePrediction.Domain.Entities;
using SalesdatePrediction.Domain.Interfaces;
using SalesdatePrediction.Infraestructure;
using SalesdatePrediction.Infraestructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Configuration.AddJsonFile("appsettings.json");
var configuration = builder.Configuration;

builder.Services.AddDbContext<StoreSampleContext>(options => options.UseSqlServer(configuration.GetConnectionString("cadena")));

builder.Services.AddScoped<ICustomerViewService, CustomerViewService>();
builder.Services.AddScoped<ICustomerViewRepository, CustomerViewRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<IShipperService, ShipperService>();
builder.Services.AddScoped<IShipperRepository, ShipperRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar CORS
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

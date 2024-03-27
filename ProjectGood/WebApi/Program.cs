using AutoMapper;
using BLL;
using BLL.FunctionsBLL;
using BLL.InterfacesBLL;
using DAL;
using DAL.functions;
using DAL.Functions;
using DAL.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInjectionBLL();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options => {
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date"
    });
});

builder.Services.AddDbContext<CoronaProjectContext>(ServiceLifetime.Transient);

builder.Services.AddDbContext<CoronaProjectContext>(options => options.UseSqlServer("Server=.;Database=CoronaProject;TrustServerCertificate=True;Trusted_Connection=True;"));

builder.Services.AddScoped(typeof(ICustomer), typeof(customerFuncDal));
builder.Services.AddScoped(typeof(ICustomerBLL), typeof(CustomerBLL));

builder.Services.AddScoped(typeof(IAddressDAL),typeof(addressFuncDal));
builder.Services.AddScoped(typeof(IAddressBLL),typeof(AddressBLL));

builder.Services.AddScoped(typeof(IDisease), typeof(DiseaseFuncDal));
builder.Services.AddScoped(typeof(IDiseaseBLL), typeof(DiseaseBLL));

builder.Services.AddScoped(typeof(IVaccinationDAL), typeof(VaccinationFuncDal));
builder.Services.AddScoped(typeof(IVaccinationBLL), typeof(VaccinationBLL));


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

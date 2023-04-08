using Microsoft.EntityFrameworkCore;
using OnlinePaymentDemo_WebApi;
using OnlinePaymentDemo_WebApi.Contract;
using OnlinePaymentDemo_WebApi.Data;
using OnlinePaymentDemo_WebApi.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContextDb>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

builder.Services.AddScoped<IRepository, Repositroy>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Stripe Infrastructure
builder.Services.AddStripeInfrastructure(builder.Configuration);

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

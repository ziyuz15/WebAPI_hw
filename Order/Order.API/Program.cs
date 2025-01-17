using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Contracts.Repository;
using Order.ApplicationCore.Contracts.Service;
using Order.ApplicationCore.Helper.Mapping;
using Order.ApplicationCore.Model.RequestModel;
using Order.Infrastructure.Data;
using Order.Infrastructure.Repository;
using Order.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrderDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderDb"));
});

//Repository Dependencies
builder.Services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
// builder.Services.AddScoped<IOrderDetailsRepositoryAsync, OrderDetailsRepositoryAsync>();

//Services Dependencies
builder.Services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();

builder.Services.AddAutoMapper(typeof(ApplicationMapper));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
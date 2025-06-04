using Microsoft.EntityFrameworkCore;
using QuadraManagementService.ApplicationServices.Contracts;
using QuadraManagementService.ApplicationServices;
using QuadraManagementService.Infrastructure.Context;
using QuadraManagementService.Infrastructure.Repositories;
using QuadraManagementService.Infrastructure.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SqlContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositórios e handlers
builder.Services.AddTransient<IQuadrasRepository, QuadrasRepository>();
builder.Services.AddScoped<IQuadrasApplicationServices, QuadrasApplicationServices>();


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

await app.RunAsync();
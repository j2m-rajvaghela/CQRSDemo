using CQRSDemo.Data;
using CQRSDemo.Framework;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDI();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Add Database Service
builder.Services.AddDbContext<CustomerContext>(opt => 
             opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#pragma warning disable CS0618 
builder.Services
      .AddControllers()
      // Add fluentvalidation service
      .AddFluentValidation(fv =>  
                fv.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
#pragma warning restore CS0618 

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

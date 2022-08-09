using Autofac;
using Autofac.Extensions.DependencyInjection;
using MaliyetBusiness.DependencyResolvers.Autofac;
using MaliyetDataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

// Add services to the container.

builder.Services.AddControllers();

    builder.Services.AddDbContext<TenderContext>(options =>
    {
        options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConnectionContext"));

    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

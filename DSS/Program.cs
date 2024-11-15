using DSS.Data.Context;
using DSS.Repositories.Absractions;
using DSS.Repositories.Implimentations;
using DSS.Repositories.UOW.Abstraction;
using DSS.Repositories.UOW.Implimentation;
using DSS.Services.Abstractions;
using DSS.Services.Implimentations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ITaskEntityRepository, TaskEntityRepository>();
builder.Services.AddScoped<ITaskEntityServic, TaskEntityServic>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//DB Context connection
string connectionString = builder.Configuration.GetConnectionString("ConnectionString")!;
builder.Services.AddDbContextFactory<DSSDbContext>(options =>
{
    options.UseSqlServer(connectionString); 
    options.EnableSensitiveDataLogging();
});

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

app.UseSwaggerUI(c =>
{
    if (!app.Environment.IsDevelopment())
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DSS API");
        c.RoutePrefix = string.Empty;
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

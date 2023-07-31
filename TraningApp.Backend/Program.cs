

using Microsoft.EntityFrameworkCore;
using Services;
using TraningApp.Backend.Data;
using TraningApp.Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("devDb");
});

// when IRepository is asked - give EfCoreRepository of the same type
builder.Services.AddTransient(typeof(IRepository<>), typeof(EfCoreRepository<>));
builder.Services.AddTransient(typeof(ICurrentUser), typeof(CurrentUser));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

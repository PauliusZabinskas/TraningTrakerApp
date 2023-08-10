using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Services;
using TraningApp.Backend.Configurations;
using TraningApp.Backend.Data;
using TraningApp.Backend.Models;
using TraningApp.Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddCors( Options => {
    Options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod()
    );
});

// string? connectionString = builder.Configuration.GetConnectionString( "TraningListingDBConnectionString" );
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("devEnv");
    
    
});

// builder.Services.AddHttpClient();
// builder.Services.AddIdentityCore<User>(options => {
//     options.Password.RequiredUniqueChars = 0;
//     options.Password.RequireNonAlphanumeric = false;
//     options.Password.RequireDigit = false;
//     options.Password.RequiredLength = 6;
// })
// .AddEntityFrameworkStores<ApplicationDbContext>();

// when IRepository is asked - give EfCoreRepository of the same type
// builder.Services.AddTransient(typeof(IUserManager<User>), typeof(UserManager<User>));
builder.Services.AddTransient(typeof(IRepository<>), typeof(EfCoreRepository<>));
builder.Services.AddTransient(typeof(ICurrentUser), typeof(CurrentUser));
builder.Services.AddTransient(typeof(ICurrentSession), typeof(CurrentSession));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

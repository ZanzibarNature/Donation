using DonationAPI.DAL.Repos;
using DonationAPI.DAL.Repos.Interfaces;
using DonationAPI.Domain;
using DonationAPI.Services;
using DonationAPI.Services.Interfaces;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (!builder.Environment.IsDevelopment())
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.Listen(IPAddress.Any, 8080);
    });
}

builder.Services.AddScoped<IDonationService, DonationService>();
builder.Services.AddScoped<IDonationRepository<Donation>, DonationRepository<Donation>>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

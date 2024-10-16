using Microsoft.EntityFrameworkCore;
using RepasoPC1SebitasJoaco.Data;
using RepasoPC1SebitasJoaco.Interfaces;
using RepasoPC1SebitasJoaco.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var cnx = _config.GetConnectionString("DevConnection");
builder.Services
    .AddDbContext<EventosDbContext>
    (options => options.UseSqlServer(cnx));

builder.Services.AddTransient<IAttendeesRepository, AttendeesRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

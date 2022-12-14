using AutoMapper;
using Microsoft.EntityFrameworkCore;

using roulette.AutoMapperConfig;
using roulette.Models;
using roulette.Repositories;

var builder = WebApplication.CreateBuilder(args);
var AutoMapperConfig = new MapperConfiguration(cfg =>
{
  cfg.AddProfile<StraightBetProfile>();
});
IMapper mapper = AutoMapperConfig.CreateMapper();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(mapper);
builder.Services.AddDbContext<RouletteContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IBetRepository, BetRepository>();

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

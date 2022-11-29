using Microsoft.EntityFrameworkCore;

using roulette.Entities;

namespace roulette.Models;

public class RouletteContext : DbContext
{
  public RouletteContext(DbContextOptions<DbContext> options) : base(options)
  {
  }

  public DbSet<StraightBetEntity> StraightBets { get; set; }
}
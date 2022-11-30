using Microsoft.EntityFrameworkCore;

using roulette.Entities;

namespace roulette.Models;

public class RouletteContext : DbContext
{
  public RouletteContext(DbContextOptions<RouletteContext> options) : base(options)
  {
  }

  public DbSet<StraightBetEntity> StraightBets { get; set; }
  public DbSet<SpinEntity> Spins { get; set; }

  public DbSet<PayoutEntity> Payouts { get; set; }
}
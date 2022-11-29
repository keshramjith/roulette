namespace roulette.Entities;

public abstract class BetEntity
{
  public long Id { get; set; }

  public long SpinId { get; set; }

  public long UserId { get; set; }
}
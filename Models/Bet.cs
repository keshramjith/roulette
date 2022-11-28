namespace roulette.Models;

public abstract class Bet
{
  public string BetType { get; set; } = string.Empty;

  public int PayoutMultiplier { get; set; }
}
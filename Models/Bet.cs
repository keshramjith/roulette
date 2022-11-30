namespace roulette.Models;

public abstract class Bet
{
  public static string BetType { get; set; } = string.Empty;

  public static int PayoutMultiplier { get; set; }
}
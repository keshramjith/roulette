namespace roulette.Models;

public class StraightBet : Bet
{
  public int PlacedBet { get; set; }

  public StraightBet(int PlacedBet)
  {
    this.BetType = "straight";
    this.PayoutMultiplier = 35;
    this.PlacedBet = PlacedBet;
  }
}
namespace roulette.Models;

public class CornerBet : Bet
{
  public int[] PlacedBet = new int[4];

  public CornerBet(int[] PlacedBet)
  {
    this.BetType = "corner";
    this.PayoutMultiplier = 8;
    this.PlacedBet = PlacedBet;
  }
}
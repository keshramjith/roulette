namespace roulette.Models;

public class SplitBet : Bet
{
  public int[] PlacedBet = new int[2];

  public SplitBet(int[] PlacedBet)
  {
    this.BetType = "split";
    this.PayoutMultiplier = 17;
    this.PlacedBet = PlacedBet;
  }
}
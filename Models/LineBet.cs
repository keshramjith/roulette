
namespace roulette.Models;

public class LineBet : Bet
{
  public int[] PlacedBet = new int[6];

  public LineBet(int[] PlacedBet)
  {
    this.BetType = "line";
    this.PayoutMultiplier = 5;
    this.PlacedBet = PlacedBet;
  }
}
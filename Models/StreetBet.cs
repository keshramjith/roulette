
namespace roulette.Models;

public class StreetBet : Bet
{
  public int[] PlacedBet = new int[3];

  public StreetBet(int[] PlacedBet)
  {
    this.BetType = "street";
    this.PayoutMultiplier = 11;
    this.PlacedBet = PlacedBet;
  }
}
namespace roulette.Dtos;

public class BetRequestDto
{
  public long SpinId { get; set; }

  public long UserId { get; set; }

  public string BetType { get; set; }

  public int StraightBet { get; set; }

  public int[] SplitBet { get; set; }

  public int[] StreetBet { get; set; }

  public int[] CornerBet { get; set; }

  public int[] LineBet { get; set; }

}
namespace roulette.Dtos;

public class BetRequestDto
{
  public long SpinId { get; set; }

  public long UserId { get; set; }

  public int Wager { get; set; }

  // Enum ??
  public string BetType { get; set; }

  public int StraightBet { get; set; }
}
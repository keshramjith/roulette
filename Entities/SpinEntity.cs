namespace roulette.Entities;

public class SpinEntity
{
  public long Id { get; set; }

  public int SpinResultNumber { get; set; }

  public List<StraightBetEntity> StraightBets { get; set; }
}
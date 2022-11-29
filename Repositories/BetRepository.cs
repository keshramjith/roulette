using roulette.Dtos;

namespace roulette.Repositories;

public class BetRepository : IBetRepository
{
  private List<(string, string)> Bets;

  public BetRepository()
  {
    Bets = new List<(string, string)>();
  }

  public BetResponseDto PlaceBet(BetRequestDto dto)
  {
    switch (dto.BetType)
    {
      case "straight":
        return new BetResponseDto();
      default:
        return new BetResponseDto();
    }
  }
}
using AutoMapper;

using roulette.Dtos;
using roulette.Entities;

namespace roulette.Repositories;

public class BetRepository : IBetRepository
{
  private List<(string, string)> Bets;
  private readonly IMapper _mapper;

  public BetRepository(IMapper mapper)
  {
    this._mapper = mapper;
    Bets = new List<(string, string)>();
  }

  public BetResponseDto PlaceBet(BetRequestDto dto)
  {
    switch (dto.BetType)
    {
      case "straight":
        // map to StraightBetEntity
        var entity = new StraightBetEntity();
        var projectedEntity = _mapper.Map<StraightBetEntity>(dto);
        // save to db
        // save BetType and BetId in Bets
        // i.e. Bets.Add((dto.BetType, SavedBet.Id))
        return new BetResponseDto();
      default:
        return new BetResponseDto();
    }
  }
}
using AutoMapper;
using System.Collections.ObjectModel;

using roulette.Dtos;
using roulette.Entities;
using roulette.Models;
namespace roulette.Repositories;

public class BetRepository : IBetRepository
{
  private List<(string, long)> Bets;
  private readonly IMapper _mapper;
  private readonly RouletteContext _context;

  public BetRepository(IMapper mapper, RouletteContext context)
  {
    this._mapper = mapper;
    this._context = context;
    Bets = new List<(string BetType, long BetId)>();
  }

  public bool AnyBets()
  {
    return Bets.Count > 0;
  }

  public void ClearBets()
  {
    Bets.Clear();
  }

  public int BetsCount()
  {
    return Bets.Count;
  }

  public ReadOnlyCollection<(string, long)> GetBets()
  {
    return Bets.AsReadOnly();
  }

  public async Task<BetResponseDto> PlaceBet(BetRequestDto dto)
  {
    switch (dto.BetType)
    {
      case "straight":
        // map to StraightBetEntity
        var entity = new StraightBetEntity();
        var projectedEntity = _mapper.Map<StraightBetEntity>(dto);
        // save to db
        await _context.AddAsync(projectedEntity);
        // save BetType and BetId in Bets
        // i.e. Bets.Add((dto.BetType, SavedBet.Id))
        Bets.Add((dto.BetType, projectedEntity.Id));
        var respDto = new BetResponseDto();
        respDto.SpinId = projectedEntity.SpinId;
        respDto.UserId = dto.UserId;
        respDto.BetType = dto.BetType;
        respDto.StraightBet = projectedEntity.PlacedBet;
        return respDto;
      default:
        return new BetResponseDto();
    }
  }
}
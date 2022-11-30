namespace roulette.Repositories;

using AutoMapper;

using roulette.Models;
using roulette.Entities;
using roulette.Dtos;

public class GameRepository : IGameRepository
{
  private bool IsBettingAllowed { get; set; } = true;
  private Spin CurrentSpin { get; set; }

  private readonly IBetRepository _betRepository;
  private readonly RouletteContext _context;
  private readonly IMapper _mapper;

  private int houseCash;

  public GameRepository(IBetRepository betRepository, RouletteContext context, IMapper mapper)
  {
    this._betRepository = betRepository;
    this._mapper = mapper;
    this._context = context;
    this.houseCash = 0;
  }

  public void AddToHouseCash(int wager)
  {
    houseCash = houseCash + wager;
  }

  public void StopBetRequests()
  {
    IsBettingAllowed = false;
  }

  public void StartBetRequests()
  {
    IsBettingAllowed = true;
  }

  public void Spin()
  {
    Random rnd = new Random();
    int res = rnd.Next(0, 37);
    CurrentSpin.Result = res;
  }

  public int GetCurrentSpinResult() => CurrentSpin.Result;

  public bool TakingBets() => IsBettingAllowed;

  public List<StraightBetEntity> GetBets()
  {
    return _context.Set<StraightBetEntity>().ToList();
  }

  public async Task<BetResponseDto> PlaceBet(BetRequestDto dto)
  {
    switch (dto.BetType)
    {
      case "straight":
        var entity = new StraightBetEntity();
        var projectedEntity = _mapper.Map<StraightBetEntity>(dto);
        await _context.StraightBets.AddAsync(projectedEntity);
        await _context.SaveChangesAsync();
        AddToHouseCash(projectedEntity.Wager);
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

  public async Task<PayoutDto> Payout(string betType, long betId)
  {
    if (!IsBettingAllowed)
    {
        switch (betType)
        {
          case "straight":
            StraightBetEntity? bet = await _context.StraightBets.FindAsync(betId);
            if (bet == null)
            {
              Console.WriteLine("Something went very wrong");
              return new PayoutDto();
            }
            if (bet.Wager == GetCurrentSpinResult())
            {
              var payout = new PayoutDto();
              payout.Payout = StraightBet.PayoutMultiplier * bet.Wager;
              return payout;
            }
          break;
        default:
          return new PayoutDto();
        }
    }
    return new PayoutDto();
  }
}
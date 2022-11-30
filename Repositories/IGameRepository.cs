using roulette.Dtos;
using roulette.Entities;

namespace roulette.Repositories;

public interface IGameRepository
{
  bool TakingBets();
  Task<BetResponseDto> PlaceBet(BetRequestDto dto);
  List<StraightBetEntity> GetBets();
  void StopBetRequests();
  void StartBetRequests();
  void Spin();
  Task<PayoutDto> Payout(string betType, long betId);

  int GetCurrentSpinResult();

  void AddToHouseCash(int wager);
}
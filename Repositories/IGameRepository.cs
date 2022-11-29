namespace roulette.Repositories;

public interface IGameRepository
{
  bool TakingBets();
  void StopBetRequests();
  void StartBetRequests();
  void Spin();
  void Payout();
}
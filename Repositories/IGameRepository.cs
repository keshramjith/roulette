namespace roulette.Repositories;

public interface IGameRepository
{
  bool TakingBets();
  void StopBetRequests();
  void StartBetRequests();
  int Spin();
  void Payout();
}
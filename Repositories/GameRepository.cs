namespace roulette.Repositories;

using roulette.Models;

public class GameRepository : IGameRepository
{
  private bool IsBettingAllowed { get; set; } = false;
  private Spin CurrentSpin { get; set; }

  private readonly IBetRepository betRepository;

  public GameRepository(IBetRepository betRepository)
  {
    this.betRepository = betRepository;
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

  public bool TakingBets() => IsBettingAllowed;

  public async void Payout()
  {
    // go through Bets list of tuples
    if (!IsBettingAllowed && betRepository.AnyBets())
    {
      // for (int i = 0; i < betRepository.BetsCount(); i++)
      // {
        
      // }
    }
  }
}
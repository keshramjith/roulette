using roulette.Dtos;

namespace roulette.Repositories;

public interface IBetRepository
{
  BetResponseDto PlaceBet(BetRequestDto dto);
}
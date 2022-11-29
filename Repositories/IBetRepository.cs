using roulette.Dtos;

namespace roulette.Repositories;

public interface IBetRepository
{
  Task<BetResponseDto> PlaceBet(BetRequestDto dto);
}
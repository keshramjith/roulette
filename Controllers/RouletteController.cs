using Microsoft.AspNetCore.Mvc;

using roulette.Dtos;
using roulette.Repositories;

namespace roulette.Controllers;

[ApiController]
[Route("[controller]")]
public class RouletteController : ControllerBase
{
  private readonly IBetRepository _betRepository;

  public RouletteController(IBetRepository betRepository)
  {
    this._betRepository = betRepository;
  }

  [HttpPost]
  public async Task<ActionResult<BetResponseDto>> PlaceBet([FromBody] BetRequestDto dto)
  {
    if (dto.BetType == string.Empty)
    {
      return BadRequest();
    }
    ActionResult<BetResponseDto> PlacedBet = await PlaceBet(dto);
    return Created("roulette/", PlacedBet);
  }
}
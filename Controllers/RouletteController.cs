using Microsoft.AspNetCore.Mvc;

using roulette.Dtos;
using roulette.Repositories;
using roulette.Entities;

namespace roulette.Controllers;

[ApiController]
[Route("[controller]")]
public class RouletteController : ControllerBase
{
  private readonly IGameRepository _gameRepository;

  public RouletteController(IGameRepository gameRepository)
  {
    this._gameRepository = gameRepository;
  }

  [HttpPost]
  public async Task<ActionResult<BetResponseDto>> PlaceBet(BetRequestDto dto)
  {
    if (dto.BetType == string.Empty)
    {
      return BadRequest();
    }
    ActionResult<BetResponseDto> PlacedBet = await _gameRepository.PlaceBet(dto);
    return Created("roulette/", PlacedBet);
  }

  [HttpGet]
  public List<StraightBetEntity> GetAllBets()
  {
   return _gameRepository.GetBets();
  }
}
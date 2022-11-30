using AutoMapper;
using System.Collections.ObjectModel;

using roulette.Dtos;
using roulette.Entities;
using roulette.Models;
namespace roulette.Repositories;

public class BetRepository : IBetRepository
{
  private List<(string, long)> Bets;
  private readonly RouletteContext _context;

  public BetRepository(IMapper mapper, RouletteContext context)
  {
    this._context = context;
    Bets = new List<(string BetType, long BetId)>();
  }
}
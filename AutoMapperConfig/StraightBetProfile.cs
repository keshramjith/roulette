using AutoMapper;

using roulette.Dtos;
using roulette.Entities;

namespace roulette.AutoMapperConfig;

public class StraightBetProfile : Profile
{
  public StraightBetProfile()
  {
    CreateMap<BetRequestDto, StraightBetEntity>()
      .ForMember(dest => dest.PlacedBet, opt => opt.MapFrom(src => src.StraightBet));
  }
}
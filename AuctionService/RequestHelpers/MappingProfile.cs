using AuctionService.Dtos;
using AuctionService.Entities;
using AutoMapper;

namespace AuctionService.RequestHelpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Auction,AuctionDto>().IncludeMembers(x=>x.Item);
        CreateMap<Item,AuctionDto>();
        CreateMap<CreateAuctionDto,Auction>()
        .ForMember(x=>x.Item, o=>o.MapFrom(s=>s));
    }
}
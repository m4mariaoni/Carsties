using AuctionService.Dtos;
using AuctionService.Entities;
using AutoMapper;
using Contracts;

namespace AuctionService.RequestHelpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Auction,AuctionDto>().IncludeMembers(x=>x.Item);
        CreateMap<Item,AuctionDto>();
        CreateMap<CreateAuctionDto,Auction>()
        .ForMember(x=>x.Item, o=>o.MapFrom(s=>s));
        CreateMap<CreateAuctionDto, Item>();
        CreateMap<AuctionDto, AuctionCreated>();
        CreateMap<Auction, AuctionUpdated>().IncludeMembers(x => x.Item);
        CreateMap<Item, AuctionUpdated>();
        
    }
}
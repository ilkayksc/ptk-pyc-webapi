using AutoMapper;
using PycApi.Data;
using PycApi.Dto;

namespace PycApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorDto, Author>().ReverseMap();

            CreateMap<StoreDto, Store>().ReverseMap();

            CreateMap<AccountDto, Account>().ReverseMap();

            CreateMap<CardDto, Card>().ReverseMap();

            CreateMap<Person, PersonDto>().ReverseMap();

            CreateMap<PersonInfo, PersonInfoDto>().ReverseMap();
        }

    }
}

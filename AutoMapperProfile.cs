using AutoMapper;
using CarteiraDigitalAPI.Dtos.Conta;
using CarteiraDigitalAPI.Dtos.Divida;

namespace CarteiraDigitalAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Conta, GetContaDto>();
            CreateMap<AddContaDto, Conta>();
            
            CreateMap<Divida, GetDividaDto>();
            CreateMap<AddDividaDto, Divida>();
        }
    }
}

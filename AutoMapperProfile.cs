using AutoMapper;
using CarteiraDigitalAPI.Dtos.Conta;

namespace CarteiraDigitalAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Conta, GetContaDto>();
            CreateMap<AddContaDto, Conta>();
        }
    }
}

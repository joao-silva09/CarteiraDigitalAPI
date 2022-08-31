using AutoMapper;
using CarteiraDigitalAPI.Dtos.Conta;
using CarteiraDigitalAPI.Dtos.Divida;
using CarteiraDigitalAPI.Dtos.Objetivo;
using CarteiraDigitalAPI.Dtos.Operacao;
using CarteiraDigitalAPI.Dtos.Planejamento;

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
            
            CreateMap<Objetivo, GetObjetivoDto>();
            CreateMap<AddObjetivoDto, Objetivo>();

            CreateMap<Operacao, GetOperacaoDto>();
            CreateMap<AddOperacaoDto, Operacao>();
            
            CreateMap<Planejamento, GetPlanejamentoDto>();
            CreateMap<AddPlanejamentoDto, Planejamento>();
        }
    }
}

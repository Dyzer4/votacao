using AutoMapper;
using VotacaoAPI.DTO;
using VotacaoAPI.Model;

namespace VotacaoAPI.Mapper;

public class VotoProfile : Profile
{
    public VotoProfile()
    {
        CreateMap<VotoRequest, VotoModel>();
        CreateMap<VotoModel, VotoRequest>();
    }

}
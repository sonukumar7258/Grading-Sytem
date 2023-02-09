using AutoMapper;
using GradingModule.Models;
using GradingModule.Dtos;

namespace GradingModule.Profiles
{
    public class GradingModuleProfile : Profile
    {
        public GradingModuleProfile()
        {
            CreateMap<UpdateMarksDtos,Category>();
        } 
    }
}
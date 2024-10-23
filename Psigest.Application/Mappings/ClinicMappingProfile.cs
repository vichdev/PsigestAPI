using AutoMapper;
using Psigest.Domain.Entities;
using Psigest.Application.DTO.Clinic;
using Psigest.Application.DTO.HealthInsurance;

namespace Psigest.Application.Mappings;

public class ClinicMappingProfile : Profile
{
    public ClinicMappingProfile()
    { 
        CreateMap<Clinic, ClinicGetDTO>().ReverseMap();

        CreateMap<Clinic, ClinicGetDTO>().ForMember(dest => dest.HealthInsurances,
            opt => opt.MapFrom(src => src.HealthInsurances)
        );

        CreateMap<HealthInsurance, HealthInsuranceDTO>();

        CreateMap<ClinicCreateDTO, Clinic>().ForMember(dest => dest.HealthInsurances, opt => opt.Ignore());

        CreateMap<ClinicUpdateDTO, Clinic>().ForMember(dest => dest.HealthInsurances, opt => opt.Ignore());
    }
}
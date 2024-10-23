using AutoMapper;
using Psigest.Domain.Entities;
using Psigest.Application.DTO.HealthInsurance;
using Psigest.Application.DTO.Clinic;

namespace Psigest.Application.Mappings;

public class HealthInsuranceMappingProfile : Profile
{
    public HealthInsuranceMappingProfile()
    {
        CreateMap<HealthInsurance, HealthInsuranceGetDTO>().ReverseMap();

        CreateMap<HealthInsurance, HealthInsuranceGetDTO>().ForMember(dest => dest.Clinics,
            opt => opt.MapFrom(src => src.Clinics)
        );

        CreateMap<Clinic, ClinicDTO>();


        CreateMap<HealthInsuranceCreateDTO, HealthInsurance>().ForMember(dest => dest.Clinics, opt => opt.Ignore());

        CreateMap<HealthInsuranceUpdateDTO, HealthInsurance>().ForMember(dest => dest.Clinics, opt => opt.Ignore());
    }
}
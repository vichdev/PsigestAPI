using AutoMapper;
using Psigest.Application.DTO;
using Psigest.Domain.Entities;

namespace Psigest.Application.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Clinic, ClinicDto>().ReverseMap();
        CreateMap<HealthInsurance, HealthInsuranceDto>().ReverseMap();
    }
}
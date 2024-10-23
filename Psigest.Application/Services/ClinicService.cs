using AutoMapper;
using Psigest.Application.DTO.Clinic;
using Psigest.Application.Interface;
using Psigest.Domain.Entities;
using Psigest.Domain.Interfaces;

namespace Psigest.Application.Services;

public class ClinicService(IClinicRepository clinicRepository, IMapper mapper) : IClinicService
{
    private readonly IClinicRepository _clinicRepository = clinicRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ClinicGetDTO>> GetClinicsAsync()
    {
        var clinics = await _clinicRepository.GetClinicsAsync();

        return _mapper.Map<IEnumerable<ClinicGetDTO>>(clinics);
    }

    public async Task<ClinicGetDTO> GetClinicByIdAsync(Guid id)
    {
        var clinic = await _clinicRepository.GetByIdAsync(id);
        
        return _mapper.Map<ClinicGetDTO>(clinic);
    }

    public async Task<ClinicGetDTO> AddClinicAsync(ClinicCreateDTO clinicDto)
    {
        var clinic = _mapper.Map<Clinic>(clinicDto);

        var clinicInclude = await _clinicRepository.CreateAsync(clinic, clinicDto.HealthInsurancesIds);
        
        return _mapper.Map<ClinicGetDTO>(clinicInclude);
    }

    public async Task<ClinicGetDTO> UpdateClinicAsync(ClinicUpdateDTO clinicDto)
    {
        var clinic = _mapper.Map<Clinic>(clinicDto);

        var clinicUpdate = await _clinicRepository.UpdateAsync(clinic);
        
        return _mapper.Map<ClinicGetDTO>(clinicUpdate);
    }

    public async Task DeleteClinicAsync(Guid id)
    {
        var clinic = await _clinicRepository.GetByIdAsync(id) ?? throw new Exception($"Category with id: {id} does not exist");

        await _clinicRepository.DeleteAsync(clinic);
    }
}
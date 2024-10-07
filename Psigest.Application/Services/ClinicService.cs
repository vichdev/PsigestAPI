using AutoMapper;
using Psigest.Application.DTO;
using Psigest.Application.Interface;
using Psigest.Domain.Entities;
using Psigest.Domain.Interfaces;

namespace Psigest.Application.Services;

public class ClinicService(IClinicRepository clinicRepository, IMapper mapper) : IClinicService
{
    private readonly IClinicRepository _clinicRepository = clinicRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ClinicDto>> GetClinicsAsync()
    {
        var clinics = await _clinicRepository.GetClinicsAsync();

        return _mapper.Map<IEnumerable<ClinicDto>>(clinics);
    }

    public async Task<ClinicDto> GetClinicByIdAsync(Guid id)
    {
        var clinic = await _clinicRepository.GetByIdAsync(id);
        
        return _mapper.Map<ClinicDto>(clinic);
    }

    public async Task<ClinicDto> AddClinicAsync(ClinicDto clinicDto)
    {
        var clinic = _mapper.Map<Clinic>(clinicDto);
        
        var clinicInclude = await _clinicRepository.CreateAsync(clinic);
        
        return _mapper.Map<ClinicDto>(clinicInclude);
    }

    public async Task<ClinicDto> UpdateClinicAsync(ClinicDto clinicDto)
    {
        var clinic = _mapper.Map<Clinic>(clinicDto);

        var clinicUpdate = await _clinicRepository.UpdateAsync(clinic);
        
        return _mapper.Map<ClinicDto>(clinicUpdate);
    }

    public async Task DeleteClinicAsync(Guid id)
    {
        var clinic = await _clinicRepository.GetByIdAsync(id) ?? throw new Exception($"Category with id: {id} does not exist");

        await _clinicRepository.DeleteAsync(clinic);
    }
}
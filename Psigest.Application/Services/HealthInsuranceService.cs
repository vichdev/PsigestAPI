using AutoMapper;
using Psigest.Application.DTO.HealthInsurance;
using Psigest.Application.Interface;
using Psigest.Domain.Entities;
using Psigest.Domain.Interfaces;

namespace Psigest.Application.Services;

public class HealthInsuranceService(IHealthInsuranceRepository healthInsuranceRepository, IMapper mapper) : IHealthInsuranceService
{
    private readonly IHealthInsuranceRepository _healthInsuranceRepository = healthInsuranceRepository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<IEnumerable<HealthInsuranceGetDTO>> GetHealthInsurances()
    {
        var healthInsurances = await _healthInsuranceRepository.GetHealthInsurancesAsync();
        
        return _mapper.Map<IEnumerable<HealthInsuranceGetDTO>>(healthInsurances);
    }

    public async Task<HealthInsuranceGetDTO> GetHealthInsuranceById(Guid id)
    {
        var healthInsurance = await _healthInsuranceRepository.GetByIdAsync(id);

        return _mapper.Map<HealthInsuranceGetDTO>(healthInsurance);
    }

    public async Task<HealthInsuranceGetDTO> CreateHealthInsurance(HealthInsuranceCreateDTO healthInsuranceDto)
    {
        var healthInsurance = _mapper.Map<HealthInsurance>(healthInsuranceDto);

        var healthInsuranceInclude = await _healthInsuranceRepository.CreateAsync(healthInsurance);
        
        return _mapper.Map<HealthInsuranceGetDTO>(healthInsuranceInclude);
    }

    public async Task<HealthInsuranceGetDTO> UpdateHealthInsurance(HealthInsuranceUpdateDTO healthInsuranceDto)
    {
        var healthInsurance = _mapper.Map<HealthInsurance>(healthInsuranceDto);

        var healthInsuranceUpdate = await _healthInsuranceRepository.UpdateAsync(healthInsurance);

        return _mapper.Map<HealthInsuranceGetDTO>(healthInsuranceUpdate);
    }

    public async Task DeleteHealthInsurance(Guid id)
    {
        var healthInsurance = await _healthInsuranceRepository.GetByIdAsync(id) ?? throw new Exception($"Category with id: {id} does not exist");

        await _healthInsuranceRepository.DeleteAsync(healthInsurance);
    }
}
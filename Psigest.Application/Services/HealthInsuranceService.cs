using AutoMapper;
using Psigest.Application.DTO;
using Psigest.Application.Interface;
using Psigest.Domain.Entities;
using Psigest.Domain.Interfaces;

namespace Psigest.Application.Services;

public class HealthInsuranceService(IHealthInsuranceRepository healthInsuranceRepository, IMapper mapper) : IHealthInsuranceService
{
    private readonly IHealthInsuranceRepository _healthInsuranceRepository = healthInsuranceRepository;
    private readonly IMapper _mapper = mapper;
    
    public async Task<IEnumerable<HealthInsuranceDto>> GetHealthInsurances()
    {
        var healthInsurances = await _healthInsuranceRepository.GetHealthInsurancesAsync();
        
        return _mapper.Map<IEnumerable<HealthInsuranceDto>>(healthInsurances);
    }

    public async Task<HealthInsuranceDto> GetHealthInsuranceById(Guid id)
    {
        var healthInsurance = await _healthInsuranceRepository.GetByIdAsync(id);

        return _mapper.Map<HealthInsuranceDto>(healthInsurance);
    }

    public async Task<HealthInsuranceDto> CreateHealthInsurance(HealthInsuranceDto healthInsuranceDto)
    {
        var healthInsurance = _mapper.Map<HealthInsurance>(healthInsuranceDto);

        var healthInsuranceInclude = await _healthInsuranceRepository.CreateAsync(healthInsurance);
        
        return _mapper.Map<HealthInsuranceDto>(healthInsuranceInclude);
    }

    public async Task<HealthInsuranceDto> UpdateHealthInsurance(HealthInsuranceDto healthInsuranceDto)
    {
        var healthInsurance = _mapper.Map<HealthInsurance>(healthInsuranceDto);

        var healthInsuranceUpdate = await _healthInsuranceRepository.UpdateAsync(healthInsurance);

        return _mapper.Map<HealthInsuranceDto>(healthInsuranceUpdate);
    }

    public async Task DeleteHealthInsurance(Guid id)
    {
        var healthInsurance = await _healthInsuranceRepository.GetByIdAsync(id) ?? throw new Exception($"Category with id: {id} does not exist");

        await _healthInsuranceRepository.DeleteAsync(healthInsurance);
    }
}
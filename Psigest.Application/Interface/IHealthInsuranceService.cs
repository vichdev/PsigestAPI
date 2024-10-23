using Psigest.Application.DTO.HealthInsurance;

namespace Psigest.Application.Interface;

public interface IHealthInsuranceService
{
    Task<IEnumerable<HealthInsuranceGetDTO>> GetHealthInsurances();
    Task<HealthInsuranceGetDTO> GetHealthInsuranceById(Guid id);    
    Task<HealthInsuranceGetDTO> CreateHealthInsurance(HealthInsuranceCreateDTO healthInsurance);
    Task<HealthInsuranceGetDTO> UpdateHealthInsurance(HealthInsuranceUpdateDTO healthInsurance);
    Task DeleteHealthInsurance(Guid id);
}
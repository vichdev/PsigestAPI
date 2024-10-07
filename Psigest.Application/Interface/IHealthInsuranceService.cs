using Psigest.Application.DTO;

namespace Psigest.Application.Interface;

public interface IHealthInsuranceService
{
    Task<IEnumerable<HealthInsuranceDto>> GetHealthInsurances();
    Task<HealthInsuranceDto> GetHealthInsuranceById(Guid id);    
    Task<HealthInsuranceDto> CreateHealthInsurance(HealthInsuranceDto healthInsurance);
    Task<HealthInsuranceDto> UpdateHealthInsurance(HealthInsuranceDto healthInsurance);
    Task DeleteHealthInsurance(Guid id);
}
using Psigest.Domain.Entities;

namespace Psigest.Domain.Interfaces;

public interface IHealthInsuranceRepository
{
    Task<IEnumerable<HealthInsurance>> GetHealthInsurancesAsync();
    Task<HealthInsurance?> GetByIdAsync(Guid? id);
    Task<HealthInsurance> CreateAsync(HealthInsurance healthInsurance);
    Task<HealthInsurance> UpdateAsync(HealthInsurance healthInsurance);
    Task<HealthInsurance> DeleteAsync(HealthInsurance healthInsurance);
}
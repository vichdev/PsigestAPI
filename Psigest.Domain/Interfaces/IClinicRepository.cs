using Psigest.Domain.Entities;

namespace Psigest.Domain.Interfaces;

public interface IClinicRepository
{
    Task<IEnumerable<Clinic>> GetClinicsAsync();
    Task<Clinic?> GetByIdAsync(Guid? id);
    Task<Clinic> CreateAsync(Clinic clinic);
    Task<Clinic> UpdateAsync(Clinic clinic);
    Task<Clinic> DeleteAsync(Clinic clinic);
}
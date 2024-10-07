using Psigest.Application.DTO;

namespace Psigest.Application.Interface;

public interface IClinicService
{
    Task<IEnumerable<ClinicDto>> GetClinicsAsync();
    Task<ClinicDto> GetClinicByIdAsync(Guid id);
    Task<ClinicDto> AddClinicAsync(ClinicDto categoryDto);
    Task<ClinicDto> UpdateClinicAsync(ClinicDto categoryDto);
    Task DeleteClinicAsync(Guid id);
}
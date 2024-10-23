using Psigest.Application.DTO.Clinic;

namespace Psigest.Application.Interface;

public interface IClinicService
{
    Task<IEnumerable<ClinicGetDTO>> GetClinicsAsync();
    Task<ClinicGetDTO> GetClinicByIdAsync(Guid id);
    Task<ClinicGetDTO> AddClinicAsync(ClinicCreateDTO clinicDTO);
    Task<ClinicGetDTO> UpdateClinicAsync(ClinicUpdateDTO clinicDTO);
    Task DeleteClinicAsync(Guid id);
}
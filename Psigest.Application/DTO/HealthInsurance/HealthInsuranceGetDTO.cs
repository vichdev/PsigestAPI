using Psigest.Application.DTO.Clinic;

namespace Psigest.Application.DTO.HealthInsurance;
public class HealthInsuranceGetDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string ImageURL { get; set; } = "";
    public IEnumerable<ClinicDTO> Clinics { get; set; } = [];

}

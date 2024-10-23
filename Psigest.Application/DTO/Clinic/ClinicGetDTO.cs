using Psigest.Application.DTO.HealthInsurance;

namespace Psigest.Application.DTO.Clinic;
public class ClinicGetDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    public IEnumerable<HealthInsuranceDTO> HealthInsurances { get; set; } = [];

}

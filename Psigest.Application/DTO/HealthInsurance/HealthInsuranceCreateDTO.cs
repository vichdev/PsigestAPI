using System.ComponentModel.DataAnnotations;

namespace Psigest.Application.DTO.HealthInsurance;
public class HealthInsuranceCreateDTO
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(3, ErrorMessage = "O nome precisa ter no minimo 3 caracteres")]
    [MaxLength(100, ErrorMessage = "O nome não pode ser maior que 100 caracteres")]
    public string Name { get; set; } = "";

    [MaxLength(250)]
    public string ImageURL { get; set; } = "";
    public IEnumerable<Guid> ClinicsIds { get; set; }
}

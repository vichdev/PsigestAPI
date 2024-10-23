using System.ComponentModel.DataAnnotations;

namespace Psigest.Application.DTO.Clinic;
public class ClinicCreateDTO
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(3, ErrorMessage = "O nome precisa ter no minimo 3 caracteres")]
    [MaxLength(100, ErrorMessage = "O nome não pode ser maior que 100 caracteres")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "O endereço é obrigatório")]
    [MinLength(3, ErrorMessage = "O endereço precisa ter no minimo 3 caracteres")]
    [MaxLength(100, ErrorMessage = "O endereço não pode ser maior que 100 caracteres")]
    public string Address { get; set; } = "";
    public IEnumerable<Guid> HealthInsurancesIds { get; set; }
}

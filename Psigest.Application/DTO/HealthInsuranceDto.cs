using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Psigest.Application.DTO;

public class HealthInsuranceDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(3, ErrorMessage = "O nome precisa ter no minimo 3 caracteres")]
    [MaxLength(100, ErrorMessage = "O nome não pode ser maior que 100 caracteres")]
    public string Name { get; set; } = "";

    [MaxLength(250)]
    public string? ImageUrl { get; set; }
    public Guid? ClinicId { get; set; }
}
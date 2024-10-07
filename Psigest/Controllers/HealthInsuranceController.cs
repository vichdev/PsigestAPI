using Microsoft.AspNetCore.Mvc;
using Psigest.Application.DTO;
using Psigest.Application.Interface;

namespace Psigest.Controllers;
[Route("api/[controller]")]
[ApiController]
public class HealthInsuranceController(IHealthInsuranceService healthInsuranceService) : ControllerBase
{
    private readonly IHealthInsuranceService _healthInsuranceService = healthInsuranceService;

    [HttpGet]
    public async Task<IActionResult> GetHealthInsurances()
    {
        var healthInsurances = await _healthInsuranceService.GetHealthInsurances();

        return Ok(healthInsurances);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetHealthInsuranceById([FromRoute] Guid id)
    {
        var healthInsurance = await _healthInsuranceService.GetHealthInsuranceById(id);

        return Ok(healthInsurance);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHealthInsurance(HealthInsuranceDto healthInsuranceDto)
    {
        var healthInsurance = await _healthInsuranceService.CreateHealthInsurance(healthInsuranceDto);

        return CreatedAtAction(nameof(GetHealthInsurances), new { id = healthInsurance.Id }, healthInsurance);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateHealthInsurance(HealthInsuranceDto healthInsuranceDto)
    {
        var healthInsurance = await _healthInsuranceService.UpdateHealthInsurance(healthInsuranceDto);

        return Ok(healthInsurance);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteHealthInsurance(Guid id)
    {
        await _healthInsuranceService.DeleteHealthInsurance(id);

        return NoContent();
    }
}

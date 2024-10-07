using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Psigest.Application.DTO;
using Psigest.Application.Interface;

namespace Psigest.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ClinicController(IClinicService clinicService) : ControllerBase
{
    private readonly IClinicService _clinicService = clinicService;

    [HttpGet]
    public async Task<IActionResult> GetClinics()
    {
        var clinics = await _clinicService.GetClinicsAsync();

        return Ok(clinics);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetClinics([FromRoute] Guid id)
    {
        var clinics = await _clinicService.GetClinicByIdAsync(id);

        return Ok(clinics);
    }

    [HttpPost]
    public async Task<IActionResult> CreateClinic(ClinicDto clinicDto)
    {
        var clinic = await _clinicService.AddClinicAsync(clinicDto);

        return CreatedAtAction(nameof(GetClinics), new { id = clinic.Id }, clinic);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateClinic(ClinicDto clinicDto)
    {
        var clinic = await _clinicService.UpdateClinicAsync(clinicDto);

        return Ok(clinic);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClinic(Guid id)
    {
        await _clinicService.DeleteClinicAsync(id);

        return NoContent();
    }
}

using Microsoft.EntityFrameworkCore;
using Psigest.Domain.Entities;
using Psigest.Domain.Interfaces;
using Psigest.Infrastructure.Data.Context;

namespace Psigest.Infrastructure.Data.Repositories;
public class ClinicRepository(ApplicationDbContext context) : IClinicRepository
{

    private readonly ApplicationDbContext _context = context;

    public async Task<Clinic> CreateAsync(Clinic clinic, IEnumerable<Guid>? healthInsurancesIds)
    {
        var healthInsurances = await _context.HealthInsurances
        .Where(hi => healthInsurancesIds.Contains(hi.Id))
        .ToListAsync();

        clinic.HealthInsurances = healthInsurances;

        _context.Add(clinic);

        await _context.SaveChangesAsync();
        return clinic;
    }

    public async Task<Clinic> DeleteAsync(Clinic clinic)
    {
        _context.Clinics.Remove(clinic);
        await _context.SaveChangesAsync();

        return clinic;
    }

    public async Task<Clinic?> GetByIdAsync(Guid? id)
    {
        var clinic = await _context.Clinics.FindAsync(id);

        return clinic;
    }

    public async Task<IEnumerable<Clinic>> GetClinicsAsync()
    {
        return await _context.Clinics.Include(c => c.HealthInsurances).ToListAsync();
    }

    public async Task<Clinic> UpdateAsync(Clinic clinic)
    {
        _context.Clinics.Update(clinic);

        await _context.SaveChangesAsync();

        return clinic;
    }
}

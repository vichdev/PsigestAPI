using Microsoft.EntityFrameworkCore;
using Psigest.Domain.Entities;
using Psigest.Domain.Interfaces;
using Psigest.Infrastructure.Data.Context;

namespace Psigest.Infrastructure.Data.Repositories;
public class HealthInsuranceRepository(ApplicationDbContext context) : IHealthInsuranceRepository
{

    private readonly ApplicationDbContext _context = context;

    public async Task<HealthInsurance> CreateAsync(HealthInsurance healthInsurance)
    {
        _context.Add(healthInsurance);
        await _context.SaveChangesAsync();
        return healthInsurance;
    }

    public async Task<HealthInsurance> DeleteAsync(HealthInsurance healthInsurance)
    {
        _context.HealthInsurances.Remove(healthInsurance);
        await _context.SaveChangesAsync();

        return healthInsurance;
    }

    public async Task<HealthInsurance?> GetByIdAsync(Guid? id)
    {
        var healthInsurance = await _context.HealthInsurances.FindAsync(id);

        return healthInsurance;
    }

    public async Task<IEnumerable<HealthInsurance>> GetHealthInsurancesAsync()
    {
        return await _context.HealthInsurances.ToListAsync();
    }

    public async Task<HealthInsurance> UpdateAsync(HealthInsurance healthInsurance)
    {
        _context.HealthInsurances.Update(healthInsurance);
        await _context.SaveChangesAsync();

        return healthInsurance;
    }
}

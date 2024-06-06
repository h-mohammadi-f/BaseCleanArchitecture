using System.Linq;
using Application.Abstractions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CompanyRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> AddAsync(Company toCreate)
        {
            await _applicationDbContext.Companies.AddAsync(toCreate);
            return await _applicationDbContext.SaveChangesAsync() > 0;

        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var company = await _applicationDbContext.Companies.FirstOrDefaultAsync(p => p.Id == id);

            if (company is null) await Task.CompletedTask;

            _applicationDbContext.Companies.Remove(company);

            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        public IQueryable<Company> GetAll()
        {
            return _applicationDbContext.Companies.Select(p => p);
        }

        public async Task<Company> GetByIdAsync(Guid id)
        {
            return await _applicationDbContext.Companies.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> UpdatePersonAsync(Company toUpdate)
        {
            _applicationDbContext.Entry(toUpdate).State = EntityState.Modified;
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }
    }
}
using Application.Companies.Create;
using Application.Companies.Query;
using AutoMapper;
using Domain;

namespace Application.Companies
{
    public class CompanyMappingProfiles : Profile
    {
        public CompanyMappingProfiles()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<CreateCompanyCommand, Company>();
        }
    }
}
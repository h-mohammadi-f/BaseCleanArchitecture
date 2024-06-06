using Application.Abstractions;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;


namespace Application.Companies.Query.GetAllCompanies
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<CompanyDto>>>
        {
            public PagingParams PageParams { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PagedList<CompanyDto>>>
        {
            private readonly IMapper _mapper;
            private readonly ICompanyRepository _companyRepository;
            public Handler(ICompanyRepository companyRepository, IMapper mapper)
            {
                _companyRepository = companyRepository;
                _mapper = mapper;
            }
            public async Task<Result<PagedList<CompanyDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                //Eager loading does not have efficient queries from db
                // var activities = await _context.Activities
                // .Include(a => a.Attendees)
                // .ThenInclude(u => u.AppUser)
                // .ToListAsync(cancellationToken);

                var query = _companyRepository.GetAll()
                .OrderBy(c => c.Name)
                .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
                //projectto  doing this for us
                // var activitiesToReturn = _mapper.Map<List<CompanyDto>>(companies);
                return Result<PagedList<CompanyDto>>.Success(
                    await PagedList<CompanyDto>.CreateAsync(query,
                    request.PageParams.PageNumber, request.PageParams.PageSize)
                );
            }
        }
    }
}
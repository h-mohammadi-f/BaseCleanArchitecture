using Application.Abstractions;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Companies.Create
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CreateCompanyCommand CreateCompanyCommand { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.CreateCompanyCommand).SetValidator(new CreateCompanyCommandValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IMapper _mapper;

            public Handler(ICompanyRepository companyRepository, IMapper mapper)
            {
                _companyRepository = companyRepository;
                _mapper = mapper;


            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _companyRepository.AddAsync(_mapper.Map<Company>(request.CreateCompanyCommand));


                if (!result)
                {
                    return Result<Unit>.Failure("Failed to create activity");
                }
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
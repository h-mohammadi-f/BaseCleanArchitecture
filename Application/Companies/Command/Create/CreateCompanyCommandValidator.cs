using Domain;
using FluentValidation;


namespace Application.Companies.Create
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
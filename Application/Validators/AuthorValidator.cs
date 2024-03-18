using Domain.Entities;
using FluentValidation;

namespace Application.Validators;

public class AuthorValidator : AbstractValidator<Author>
{
    public AuthorValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("There should be author name")
            .Length(3, 50)
            .WithMessage("Name should be between 3 and 50 characters");
    }
}

using Domain.Entities;
using FluentValidation;

namespace Application.Validators;

public class JanrValidator : AbstractValidator<Janr>
{
    public JanrValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Janr can not be empty")
            .Length(4, 50)
            .WithMessage("There should be at least 4 characters or less than 50");

    }
}

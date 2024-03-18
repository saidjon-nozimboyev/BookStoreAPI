using Domain.Entities;
using FluentValidation;

namespace Application.Validators;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can not be empty")
            .Length(3, 20)
            .WithMessage("Nme must be between 3 and 20 characters");
        
        RuleFor(x => x.Id)
            .NotEqual(0)
            .WithMessage("Id is incorrect");
    }
}



using FluentValidation.Results;

namespace Application.Common;

public class BookException
    : Exception
{
    public BookException(string message) : base(message)
    {
        
    }
    public BookException(ValidationResult result)
        : base(string.Join("\n", result.Errors.Select(x => x.ErrorMessage)))
    {
        
    }
}

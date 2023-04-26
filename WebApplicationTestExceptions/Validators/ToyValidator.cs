using FluentValidation;
using WebApplicationTestExceptions.Entities;

namespace WebApplicationTestExceptions.Validators;

public class ToyValidator : AbstractValidator<Toy>
{
    public ToyValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name.Length).InclusiveBetween(3, 10);
        RuleFor(x => x.Price).GreaterThan(0);
    }
}
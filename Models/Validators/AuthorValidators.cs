using BookStoreApi.Models.Repositories;
using FluentValidation;

namespace BookStoreApi.Models.Validators
{
    public class AuthorModelValidator : AbstractValidator<AuthorModel>
    {
        public AuthorModelValidator()
        {
            RuleFor(command => command.AuthorName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(command => command.AuthorSurname).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(command => command.AuthorBirthday).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}

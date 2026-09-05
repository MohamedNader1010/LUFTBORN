using FluentValidation;

namespace LUFTBORN.Application.Users.Queries.GetUserById;

public class GetUserByIdQueryValidator
    : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();
    }
}
using FluentValidation;
using MediatR;

namespace Application.Account;

public class Login
{
    public class LoginCommand : IRequest<Unit>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty().NotNull();
        }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, Unit>
    {
        public async Task<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Guests;

public class CreateGuest
{
    public class CreateGuestCommand : IRequest<GuestDto>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Confirm { get; set; }
    }

    public class CreateGuestCommandValidator : AbstractValidator<CreateGuestCommand>
    {
        public CreateGuestCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotNull().NotEmpty();
            RuleFor(x => x.Confirm).NotNull().NotEmpty();
        }
    }

    public class CreateGuestCommandHandler : IRequestHandler<CreateGuestCommand, GuestDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public CreateGuestCommandHandler(IUnitOfWork unitOfWork, IUserAccessor userAccessor,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userAccessor = userAccessor;
            _mapper = mapper;
        }

        public async Task<GuestDto> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = new Guest
            {
                Name = request.Name,
                Email = request.Email,
                Confirm = request.Confirm,
                CreatedByUserId = _userAccessor.GetCurrentUserID()
            };
            _unitOfWork.Repository<Guest>().Add(guest);
            var result = await _unitOfWork.Complete() > 0;
            if (result) return _mapper.Map<Guest,GuestDto>(guest);

            throw new Exception("Problem Saving");
        }
    }
}
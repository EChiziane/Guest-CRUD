using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Guests;

public class UpdateGuest
{
    public class UpdateGuestCommand:IRequest<GuestDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Confirm { get; set; }
    }

    public class UpdateGuestCommandHandler : IRequestHandler<UpdateGuestCommand, GuestDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public UpdateGuestCommandHandler(IUnitOfWork unitOfWork,IUserAccessor userAccessor, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userAccessor = userAccessor;
            _mapper = mapper;
        }
        public async Task<GuestDto> Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = await _unitOfWork.Repository<Guest>().GetByIdAsync(request.Id);
            if (guest ==null)
            {
                throw new Exception("No Guest With This Id");
            }

            guest.Name = request.Name;
            guest.Confirm = request.Confirm;
            guest.Email = request.Email;
            guest.LastUpdatedAt= DateTime.Now;
            guest.LastUpdatedByUserId = _userAccessor.GetCurrentUserID();

            var result = await _unitOfWork.Complete() > 0;
            if (result)
            {
                return _mapper.Map<Guest,GuestDto>(guest) ;
            }
            throw new Exception("Could not update");
        }
    }
}
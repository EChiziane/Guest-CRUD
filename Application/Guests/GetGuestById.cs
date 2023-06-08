using Application.Guests.Specification;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Guests;

public class GetGuestById
{
    public class GetGuestByIdQuery:IRequest<GuestDto>
    {
        public int GuestId { get; set; }
    }
    public class GetGuestByIdQueryHandler:IRequestHandler<GetGuestByIdQuery,GuestDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGuestByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GuestDto> Handle(GetGuestByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetGuestByIdSpecification(request.GuestId);
            var guest = await _unitOfWork.Repository<Guest>().GetEntityWithSpec(spec);

            if (guest is null)
                throw new Exception("No Guest With This Id");
            return _mapper.Map<Guest, GuestDto>(guest);
        }
    }
    
}
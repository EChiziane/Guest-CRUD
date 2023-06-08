using Application.Guests.Specification;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Guests;

public class ListConfirmedGuest
{
    public class ListConfirmedGuestQuery:IRequest<List<GuestDto>>
    {
      
    }
    public class ListConfirmedGuestQueryHandler:IRequestHandler<ListConfirmedGuestQuery,List<GuestDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListConfirmedGuestQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GuestDto>> Handle(ListConfirmedGuestQuery request, CancellationToken cancellationToken)
        {
            var spec = new ListConfirmedGuestSpecification();
            var guests = await _unitOfWork.Repository<Guest>().ListWithSpecAsync(spec);

            return _mapper.Map<List<Guest>, List<GuestDto>>(guests);
        }
    }
}
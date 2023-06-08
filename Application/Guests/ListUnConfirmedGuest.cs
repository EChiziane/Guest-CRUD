using Application.Guests.Specification;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Guests;

public class ListUnConfirmedGuest
{
    public class ListUnConfirmedGuestQuery:IRequest<List<GuestDto>>
    {
        
    }
    
    public class ListUnConfirmedGuestQueryHandler:IRequestHandler<ListUnConfirmedGuestQuery,List<GuestDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListUnConfirmedGuestQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GuestDto>> Handle(ListUnConfirmedGuestQuery request, CancellationToken cancellationToken)
        {
            var spec = new ListUnConfirmedGuestSpecification();
            var guests = await _unitOfWork.Repository<Guest>().ListWithSpecAsync(spec);
            return _mapper.Map<List<Guest>, List<GuestDto>>(guests);
        }
    }
}
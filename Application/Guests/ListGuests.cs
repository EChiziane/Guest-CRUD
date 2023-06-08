using Application.Guests.Specification;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Guests;

public class ListGuests
{
    
    public class ListGuestsQuery:IRequest<List<GuestDto>>
    {
        
    }
    
    public class ListGuestsQueryHandler:IRequestHandler<ListGuestsQuery,List<GuestDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListGuestsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GuestDto>> Handle(ListGuestsQuery request, CancellationToken cancellationToken)
        {
            var spec = new ListGuestSpecification();
            var guests = await _unitOfWork.Repository<Guest>().ListWithSpecAsync(spec);

            return _mapper.Map<List<Guest>,List<GuestDto>>(guests);
        }
    }
    
}
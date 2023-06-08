using Application.Specifications;
using Domain;

namespace Application.Guests.Specification;

public class GetGuestByIdSpecification:BaseSpecification<Guest>
{
    public GetGuestByIdSpecification(int id):base(guest =>guest.Id==id )
    {
        
    }
}
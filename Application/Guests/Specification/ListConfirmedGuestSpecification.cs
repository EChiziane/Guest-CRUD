using Application.Specifications;
using Domain;

namespace Application.Guests.Specification;

public class ListConfirmedGuestSpecification:BaseSpecification<Guest>
{
    public ListConfirmedGuestSpecification():base(guest =>guest.Confirm == true )
    {
        AddInclude(guest =>guest.CreatedByUser);
        AddInclude(guest =>guest.LastUpdatedByUser);
    }
}
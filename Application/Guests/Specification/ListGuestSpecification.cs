using Application.Specifications;
using Domain;

namespace Application.Guests.Specification;

public class ListGuestSpecification:BaseSpecification<Guest>
{
    public ListGuestSpecification()
    {
        AddInclude(guest => guest.CreatedByUser );
        AddInclude(guest => guest.LastUpdatedByUser);
    }
}
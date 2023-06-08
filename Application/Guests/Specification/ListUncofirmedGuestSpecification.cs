using Application.Specifications;
using Domain;

namespace Application.Guests.Specification;

public class ListUnConfirmedGuestSpecification : BaseSpecification<Guest>
{
    public ListUnConfirmedGuestSpecification() : base(guest => guest.Confirm == false)
    {
        AddInclude(guest => guest.CreatedByUser);
        AddInclude(guest => guest.LastUpdatedByUser);
    }
}
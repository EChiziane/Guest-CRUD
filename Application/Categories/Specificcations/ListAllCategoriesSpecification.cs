using Application.Specifications;
using Domain;

namespace Application.Categories.Specificcations;

public class ListAllCategoriesSpecification : BaseSpecification<Category>
{
    public ListAllCategoriesSpecification()
    {
        AddInclude(x => x.CreatedByUser);
        AddInclude(x => x.LastUpdatedByUser);
        AddOrderBy(x => x.Name);
    }
}
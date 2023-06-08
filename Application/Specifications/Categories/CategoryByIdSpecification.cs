using Domain;

namespace Application.Specifications.Categories;

public class CategoryByNameSpecification : BaseSpecification<Category>
{
    public CategoryByNameSpecification(string name) : base(x => x.Name == name)
    {
    }
}
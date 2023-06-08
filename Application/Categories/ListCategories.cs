using Application.Categories.Specificcations;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Categories;

public class ListCategories
{
    public class ListCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }

    public class ListCategoriesQueryHandler : IRequestHandler<ListCategoriesQuery, List<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ListCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(ListCategoriesQuery request, CancellationToken cancellationToken)
        {
            var spec = new ListAllCategoriesSpecification();
            var categories = await _unitOfWork.Repository<Category>().ListWithSpecAsync(spec);

            /*var list = new List<CategoryDto>();

            foreach (var category in categories)
            {
                list.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    CreatedAt = category.CreatedAt,
                    CreatedBy = category.CreatedByUser.FullName
                });
            }

            return list;*/

            return _mapper.Map<List<Category>, List<CategoryDto>>(categories);
        }
    }
}
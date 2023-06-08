using System.Net;
using Application.Errors;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Categories;

public class GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public int CategoryId { get; set; }
    }


    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(request.CategoryId);

            if (category == null) throw new RestException(HttpStatusCode.NotFound, "Category not found");

            return category;
        }
    }
}
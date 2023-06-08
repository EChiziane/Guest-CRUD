using System.Net;
using Application.Errors;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Categories;

public class DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<Category>
    {
        public int CategoryId { get; set; }
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Category>
    {
        private readonly ILocalizerHelper<DeleteCategoryCommandHandler> _localizerHelper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork,
            ILocalizerHelper<DeleteCategoryCommandHandler> localizerHelper)
        {
            _unitOfWork = unitOfWork;
            _localizerHelper = localizerHelper;
        }

        public async Task<Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(request.CategoryId);

            if (category == null)
                throw new RestException(HttpStatusCode.NotFound,
                    _localizerHelper.GetString("CategoryNotFoundMessage", request.CategoryId.ToString()));

            _unitOfWork.Repository<Category>().Delete(category);

            var result = await _unitOfWork.Complete() > 0;

            if (result) return category;

            throw new Exception(_localizerHelper.GetString("ProblemSaving", request.CategoryId.ToString()));
        }
    }
}
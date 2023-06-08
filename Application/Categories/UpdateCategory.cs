using System.Net;
using Application.Errors;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Categories;

public class UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {
        private readonly ILocalizerHelper<UpdateCategoryCommandHandler> _localizerHelper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork,
            ILocalizerHelper<UpdateCategoryCommandHandler> localizerHelper)
        {
            _unitOfWork = unitOfWork;
            _localizerHelper = localizerHelper;
        }

        public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(request.Id);

            if (category == null)
                throw new RestException(HttpStatusCode.NotFound, _localizerHelper.GetString("CategoryNotFound"));

            category.Name = request.Name;

            _unitOfWork.Repository<Category>().Update(category);

            var result = await _unitOfWork.Complete() > 0;

            if (result) return category;

            throw new Exception(_localizerHelper.GetString("Could not update category"));
        }
    }
}
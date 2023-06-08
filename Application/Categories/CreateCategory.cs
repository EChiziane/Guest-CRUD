using System.Net;
using Application.Errors;
using Application.Interfaces;
using Application.Specifications.Categories;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Categories;

public class CreateCategory
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public string Name { get; set; }
    }

    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        private readonly ILocalizerHelper<CreateCategoryCommandHandler> _localizerHelper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork,
            ILocalizerHelper<CreateCategoryCommandHandler> localizerHelper)
        {
            _unitOfWork = unitOfWork;
            _localizerHelper = localizerHelper;
        }

        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Prepare the specification to get category by name
            var spec = new CategoryByNameSpecification(request.Name);

            // Get category by name

            var category = await _unitOfWork.Repository<Category>().GetEntityWithSpec(spec);

            if (category != null)
                throw new RestException(HttpStatusCode.Conflict,
                    _localizerHelper.GetString("CategoryExistsMessage", request.Name));

            category = new Category
            {
                Name = request.Name
            };

            _unitOfWork.Repository<Category>().Add(category);

            var result = await _unitOfWork.Complete() > 0;

            if (result) return category;

            throw new Exception(_localizerHelper.GetString("ProblemSaving"));
        }
    }
}
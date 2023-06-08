using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Admin.SystemLanguages;

public class GetAllLanguages
{
    public class GetAllLanguagesQuery : IRequest<List<SystemLanguage>>
    {
    }

    public class GetAllLanguagesQueryHandler : IRequestHandler<GetAllLanguagesQuery, List<SystemLanguage>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllLanguagesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SystemLanguage>> Handle(GetAllLanguagesQuery request,
            CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<SystemLanguage>().ListAllAsync();
        }
    }
}
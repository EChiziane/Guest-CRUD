using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Guests;

public class DeleteGuest
{
    public class DeleteGuestCommand:IRequest<Guest>
    {
        public int GuestId { get; set; }
    }
    
    public class DeleteGuestCommandHandler:IRequestHandler<DeleteGuestCommand, Guest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGuestCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task<Guest> Handle(DeleteGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = await _unitOfWork.Repository<Guest>().GetByIdAsync(request.GuestId);
            if (guest is null)
                throw new Exception("No Guest Found");
            _unitOfWork.Repository<Guest>().Delete(guest);
            var result = await _unitOfWork.Complete() > 0;
            if (result)
            {
                return guest;
            }

            throw new Exception("Problem Deleting");
        }
        
    }
}
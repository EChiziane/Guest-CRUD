using System.Net.Http.Headers;
using Application.Guests;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class GuestController:BaseApiController
{
    private readonly IMediator _mediator;
   

    public GuestController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<List<Guest>>> GetAllGuests()
    {
        return Ok(await _mediator.Send(new ListGuests.ListGuestsQuery()));
    }

    [HttpPost]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<Guest>> CreateGuest(CreateGuest.CreateGuestCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<GuestDto> GetGuestById(int id)
    {
        return await _mediator.Send(new GetGuestById.GetGuestByIdQuery { GuestId = id });
    }

    [HttpDelete("{id}")]
    [AllowAnonymous]
    public async Task<Guest> DeleteGuest(int id)
    {
        return await _mediator.Send(new DeleteGuest.DeleteGuestCommand { GuestId = id });
    }

    [HttpPut("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<GuestDto>> UpdateGuest(int id, UpdateGuest.UpdateGuestCommand command)
    {
        command.Id = id;
        return await _mediator.Send(command);
    }
    
    [HttpGet("Confirmed")]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<List<Guest>>> GetConfirmedGuests()
    {
        return Ok(await _mediator.Send(new ListConfirmedGuest.ListConfirmedGuestQuery()));
    }
    
    [HttpGet("UnConfirmed")]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<List<Guest>>> GetUnConfirmedGuests()
    {
        return Ok(await _mediator.Send(new ListUnConfirmedGuest.ListUnConfirmedGuestQuery()));
    }
}
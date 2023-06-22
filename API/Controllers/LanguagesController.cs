using Application.Admin.SystemLanguages;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class LanguagesController : BaseApiController
{
    private readonly IMediator _mediator;

    public LanguagesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<List<SystemLanguage>>> GetLanguages()
    {
        return await _mediator.Send(new GetAllLanguages.GetAllLanguagesQuery());
    }
}
using Application.Categories;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CategoriesController : BaseApiController
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize]
    [AllowAnonymous]
    public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
    {
        return Ok(await _mediator.Send(new ListCategories.ListCategoriesQuery()));
    }

    [HttpGet("{id}")]
    public async Task<Category> GetById(int id)
    {
        return await _mediator.Send(new GetCategoryById.GetCategoryByIdQuery { CategoryId = id });
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Category>> CreateCategory(CreateCategory.CreateCategoryCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Category>> DeleteCategory(int id)
    {
        return await _mediator.Send(new DeleteCategory.DeleteCategoryCommand { CategoryId = id });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Category>> UpdateCategory(int id, UpdateCategory.UpdateCategoryCommand command)
    {
        command.Id = id;
        return await _mediator.Send(command);
    }
}
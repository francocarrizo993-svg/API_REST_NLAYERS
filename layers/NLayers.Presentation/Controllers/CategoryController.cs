using Microsoft.AspNetCore.Mvc;
using NLayers.BusinessLogic.Interfaces;
using NLayers.Entities.Models;
using NLayers.Presentation.Models.Inputs;
using NLayers.Presentation.Models.Outputs;

namespace NLayers.Presentation.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryManager _categoryManager;

    public CategoryController(ICategoryManager categoryManager)
    {
        _categoryManager = categoryManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoryManager.GetAllAsync();

        var response = categories.Select(category => new CategoryOutput
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _categoryManager.GetByIdAsync(id);

        if (category == null)
        {
            return NotFound();
        }

        var response = new CategoryOutput
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryInput input)
    {
        try
        {
            var category = new Category
            {
                Name = input.Name,
                Description = input.Description
            };

            var createdCategory =
                await _categoryManager.AddAsync(category);

            var response = new CategoryOutput
            {
                Id = createdCategory.Id,
                Name = createdCategory.Name,
                Description = createdCategory.Description
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id = response.Id },
                response
            );
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateCategoryInput input
    )
    {
        try
        {
            var updatedCategory =
                await _categoryManager.UpdateAsync(
                    id,
                    input.Name,
                    input.Description
                );

            if (updatedCategory == null)
            {
                return NotFound();
            }

            var response = new CategoryOutput
            {
                Id = updatedCategory.Id,
                Name = updatedCategory.Name,
                Description = updatedCategory.Description
            };

            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted =
            await _categoryManager.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
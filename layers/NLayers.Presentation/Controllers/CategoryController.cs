using Microsoft.AspNetCore.Mvc;
using NLayers.BusinessLogic.Managers;
using NLayers.Entities.Models;
using NLayers.Presentation.Models.Inputs;
using NLayers.Presentation.Models.Outputs;

namespace NLayers.Presentation.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly CategoryManager _categoryManager;

    public CategoryController(CategoryManager categoryManager)
    {
        _categoryManager = categoryManager;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var categories = _categoryManager.GetAll();

        var response = categories.Select(category => new CategoryOutput
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var category = _categoryManager.GetById(id);

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
    public IActionResult Create(CreateCategoryInput input)
    {
        var category = new Category
        {
            Name = input.Name,
            Description = input.Description
        };

        var createdCategory = _categoryManager.Add(category);

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
}
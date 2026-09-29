using Microsoft.AspNetCore.Mvc;
using NLayers.BusinessLogic.Interfaces;
using NLayers.Entities.Models;
using NLayers.Presentation.Models.Inputs;
using NLayers.Presentation.Models.Outputs;

namespace NLayers.Presentation.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductManager _productManager;

    public ProductController(IProductManager productManager)
    {
        _productManager = productManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productManager.GetAllAsync();

        var response = products.Select(product => new ProductOutput
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productManager.GetByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        var response = new ProductOutput
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductInput input)
    {
        try
        {
            var product = new Product
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price
            };

            var createdProduct = await _productManager.AddAsync(product);

            var response = new ProductOutput
            {
                Id = createdProduct.Id,
                Name = createdProduct.Name,
                Description = createdProduct.Description,
                Price = createdProduct.Price
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
    public async Task<IActionResult> Update(int id, UpdateProductInput input)
    {
        try
        {
            var updatedProduct = await _productManager.UpdateAsync(
                id,
                input.Name,
                input.Description,
                input.Price
            );

            if (updatedProduct == null)
            {
                return NotFound();
            }

            var response = new ProductOutput
            {
                Id = updatedProduct.Id,
                Name = updatedProduct.Name,
                Description = updatedProduct.Description,
                Price = updatedProduct.Price
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
        var deleted = await _productManager.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
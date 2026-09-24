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
    public IActionResult GetAll()
    {
        var products = _productManager.GetAll();

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
    public IActionResult GetById(int id)
    {
        var product = _productManager.GetById(id);

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
    public IActionResult Create(CreateProductInput input)
    {
        try
        {
            var product = new Product
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price
            };

            var createdProduct = _productManager.Add(product);

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
    public IActionResult Update(int id, UpdateProductInput input)
    {
        try
        {
            var updatedProduct = _productManager.Update(
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
    public IActionResult Delete(int id)
    {
        var deleted = _productManager.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
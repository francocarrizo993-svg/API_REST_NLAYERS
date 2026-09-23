namespace NLayers.Presentation.Models.Inputs;

public class CreateProductInput
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
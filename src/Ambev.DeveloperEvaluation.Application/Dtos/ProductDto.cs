namespace Ambev.DeveloperEvaluation.Application.Dtos;

/// <summary>
/// Data transfer object for Product entity
/// </summary>
public class ProductDto
{
    /// <summary>
    /// Gets or sets the product.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the product.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the category of the product.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Get Avarage of ratings
    /// </summary>
    public decimal RateAverage { get; set; }
}
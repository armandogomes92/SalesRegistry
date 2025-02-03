using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a product in the system with details and rating information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Product : BaseEntity
{
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


    public decimal RateAverage { get; set; }

    /// <summary>
    /// Gets or sets the ratings of the product.
    /// </summary>
    public ICollection<Rating> Ratings { get; set; }
    /// <summary>
    /// Calculates the average rating of the product.
    /// </summary>
    /// <returns>The average rating as a decimal.</returns>
    public decimal GetAverageRating(ICollection<Rating> ratings)
    {
        if (ratings == null || !ratings.Any())
        {
            return 0;
        }

        return (decimal)ratings.Average(r => r.Rate);
    }
}
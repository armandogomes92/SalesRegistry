using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a rating in the system with details about the rating value and associated user.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Rating : BaseEntity
{
    /// <summary>
    /// Gets the ID of the customer who gave the rating.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets the ID of the product being rated.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets the rating value given by the customer.
    /// Must be a value between 1 and 5.
    /// </summary>
    public int Rate { get; set; }

    /// <summary>
    /// Gets or sets the customer who gave the rating.
    /// </summary>
    public virtual Customer Customer { get; set; }

    /// <summary>
    /// Gets or sets the product being rated.
    /// </summary>
    public virtual Product Product { get; set; }
}
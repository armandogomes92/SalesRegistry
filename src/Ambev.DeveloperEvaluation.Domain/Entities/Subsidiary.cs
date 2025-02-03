using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a subsidiary in the system with details and associated customers.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Subsidiary : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the subsidiary.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the company identifier code of the subsidiary.
    /// </summary>
    public string CompanyIdentifierCode { get; set; }

    /// <summary>
    /// Gets or sets the address of the subsidiary.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the subsidiary.
    /// Must be a valid phone number format following the pattern (XX) XXXXX-XXXX.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Gets the date and time when the subsidiary was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the subsidiary's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
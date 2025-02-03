namespace Ambev.DeveloperEvaluation.Application.Dtos;

public class SubsidiaryDto
{
    /// <summary>
    /// Gets or sets id of the subsidiary
    /// </summary>
    public Guid Id { get; set; }

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
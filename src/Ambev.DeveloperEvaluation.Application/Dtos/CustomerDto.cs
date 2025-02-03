namespace Ambev.DeveloperEvaluation.Application.Dtos;

/// <summary>
/// Data transfer object for Customer entity
/// </summary>
public class CustomerDto
{
    /// <summary>
    /// Get or Set Customer
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the main name of the customer.
    /// </summary>
    public string MainName { get; set; }

    /// <summary>
    /// Gets or sets the contract name of the customer.
    /// </summary>
    public string ContractName { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the customer.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Gets or sets the email address of the customer.
    /// </summary>
    public string Email { get; set; }
}
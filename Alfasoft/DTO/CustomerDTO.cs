using Alfasoft.Models;
using System.ComponentModel.DataAnnotations;

namespace Alfasoft.DTO;

public class CustomerDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MinLength(5, ErrorMessage = "Name must be at least 5 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Contact is required.")]
    [RegularExpression(@"^\d{9}$", ErrorMessage = "Contact must be exactly 9 digits.")]
    public int Contact { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string? Email { get; set; }

    public Customer ToCostumer(CustomerDTO customerDTO)
    {
        Customer customer = new()
        {
            Id = customerDTO.Id,
            Name = customerDTO.Name,
            Contact = customerDTO.Contact,
            Email = customerDTO.Email
        };
        return customer;
    }
}

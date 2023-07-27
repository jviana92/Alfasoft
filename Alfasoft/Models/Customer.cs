using System.ComponentModel.DataAnnotations;

namespace Alfasoft.Models;

public class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Contact { get; set; }

    public string? Email { get; set; }

}

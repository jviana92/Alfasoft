using Alfasoft.DTO;
using Alfasoft.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alfasoft.Pages.Customers;

public class CreateModel : PageModel
{
    private readonly ICustomerService _customerService;

    [BindProperty]
    public CustomerDTO Customer { get; set; } = new();
    public CreateModel(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _customerService.CreateCustomer(Customer);
        return RedirectToPage("/Index");
    }
}

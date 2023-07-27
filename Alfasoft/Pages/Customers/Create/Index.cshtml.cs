using Alfasoft.DTO;
using Alfasoft.Models;
using Alfasoft.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alfasoft.Pages.Customers.Create;

public class IndexModel : PageModel
{
    private readonly ICustomerService _customerService;

    [BindProperty]
    public CustomerDTO? Customer { get; set; } = new();
    public IndexModel(ICustomerService customerService)
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


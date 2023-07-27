using Alfasoft.DTO;
using Alfasoft.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Alfasoft.Pages.Customers;

public class EditModel : PageModel
{
    private readonly ICustomerService _customerService;

    [BindProperty]
    public CustomerDTO Customer { get; set; } = new();

    public EditModel(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task OnGetAsync(int id)
    {
        Customer = await _customerService.GetCustomersById(id);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _customerService.UpdateCustomer(Customer);
        return RedirectToPage("/Index");
    }
}

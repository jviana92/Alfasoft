using Alfasoft.DTO;
using Alfasoft.Models;
using Alfasoft.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Alfasoft.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ICustomerService _customerService;

    public List<CustomerDTO> Customers { get; set; }

    public IndexModel(ILogger<IndexModel> logger, ICustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }

    public async Task OnGetAsync()
    {
        Customers = await _customerService.GetAllCustomersIQ().ToListAsync();
    }

    // Delete handler
    public async Task OnPostDeleteAsync(int id)
    {
        await _customerService.DeleteCustomerById(id);

        Customers = await _customerService.GetAllCustomersIQ().ToListAsync();
    }

}
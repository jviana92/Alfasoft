using Alfasoft.DTO;
using Alfasoft.Models;

namespace Alfasoft.Services.CustomerService;

public interface ICustomerService
{
    IQueryable<CustomerDTO> GetAllCustomersIQ();
    Task<CustomerDTO?> GetCustomersById(int id);
    Task UpdateCustomer(CustomerDTO customer);
    Task DeleteCustomerById(int id);
    Task CreateCustomer(CustomerDTO customer);
}

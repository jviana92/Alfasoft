using Alfasoft.DTO;
using Alfasoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfasoft.Services.CustomerService;

public class CustomerService : ICustomerService
{
    private readonly ApplicationDbContext _context;

    public CustomerService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<CustomerDTO> GetAllCustomersIQ()
    {
        return _context.Customers.Select(c => new CustomerDTO
        {
            Id = c.Id,
            Name = c.Name,
            Contact = c.Contact,
            Email = c.Email
        });
    }

    public async Task<CustomerDTO?> GetCustomersById(int id)
    {
        var customer = await _context.Customers.Where(c => c.Id == id).Select(c => new CustomerDTO
        {
            Id = c.Id,
            Name = c.Name,
            Contact = c.Contact,
            Email = c.Email
        }).FirstOrDefaultAsync();

        return customer;
    }

    public async Task DeleteCustomerById(int id)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer == null)
        {
            return;
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }

    public Task UpdateCustomer(CustomerDTO customer)
    {
        throw new NotImplementedException();
    }

    public async Task CreateCustomer(CustomerDTO customer)
    {
        var newCustomer = new Customer
        {
            Id = customer.Id,
            Name = customer.Name,
            Contact = customer.Contact,
            Email = customer.Email
        };

        await _context.Customers.AddAsync(newCustomer);
        await _context.SaveChangesAsync();
    }
}

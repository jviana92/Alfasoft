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

    public async Task UpdateCustomer(CustomerDTO customerDto)
    {
        Customer? customer = await _context.Customers.FindAsync(customerDto.Id);

        if (customer == null)
        {
            return;
            //Todo - Shouldn't happen, but throw expection
        }

        customer.Name = customerDto.Name;
        customer.Contact = customerDto.Contact;
        customer.Email = customerDto.Email;

        await _context.SaveChangesAsync();
    }

    public async Task CreateCustomer(CustomerDTO customerDto)
    {
        var newCustomer = new Customer
        {
            Id = customerDto.Id,
            Name = customerDto.Name,
            Contact = customerDto.Contact,
            Email = customerDto.Email
        };

        await _context.Customers.AddAsync(newCustomer);
        await _context.SaveChangesAsync();
    }
}

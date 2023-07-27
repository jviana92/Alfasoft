using Alfasoft.Models;
using Microsoft.EntityFrameworkCore;

namespace Alfasoft;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public ApplicationDbContext() : base()
    {

    }

    public DbSet<Customers> Customers { get; set; }
}

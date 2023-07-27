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

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasIndex(e => new { e.Email, e.Contact }).IsUnique();

            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.Contact)
                  .IsRequired()
                  .HasPrecision(9);

            entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(100)
                  .IsUnicode(false)
                  .HasColumnType("varchar(100)")
                  .HasAnnotation("RegularExpression", @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        });
    }
}

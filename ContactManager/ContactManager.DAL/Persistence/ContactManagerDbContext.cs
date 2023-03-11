using ContactManager.DAL.Entities;
using ContactManager.DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManager.DAL.Persistence;

public class ContactManagerDbContext: DbContext
{
    public ContactManagerDbContext()
    {
    }
    public ContactManagerDbContext(DbContextOptions<ContactManagerDbContext> options)
        : base(options)
    {
    }

    public DbSet<ContactData> ContactData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactData>()
        .Property(c => c.Salary)
        .HasColumnType("decimal(18,2)");

        modelBuilder.SeedData();
    }
}

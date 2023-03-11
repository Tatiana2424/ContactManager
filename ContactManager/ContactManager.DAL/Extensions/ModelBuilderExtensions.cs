using ContactManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ContactManager.DAL.Extensions;

public static class ModelBuilderExtensions
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactData>().HasData(
            new ContactData
            {
                Id = 1,
                Name = "Anna",
                DateOfBirth = new DateTime(2008, 3, 1, 0, 0, 0),
                Married = true,
                Phone = "0987654321",
                Salary = 5000,
            },
            new ContactData
            {
                Id = 2,
                Name = "Bob",
                DateOfBirth = new DateTime(2001, 4, 2, 0, 0, 0),
                Married = false,
                Phone = "0987644441",
                Salary = 4000,
            },
            new ContactData
            {
                Id = 3,
                Name = "Tom",
                DateOfBirth = new DateTime(1999, 8, 2, 0, 0, 0),
                Married = false,
                Phone = "0987644490",
                Salary = 14000,
            },
            new ContactData
            {
                Id = 4,
                Name = "Maria",
                DateOfBirth = new DateTime(2003, 4, 10, 0, 0, 0),
                Married = false,
                Phone = "0667644441",
                Salary = 8000,
            },
            new ContactData
            {
                Id = 5,
                Name = "David",
                DateOfBirth = new DateTime(1999, 8, 2, 0, 0, 0),
                Married = false,
                Phone = "0777644490",
                Salary = 10000,
            });
    }
}

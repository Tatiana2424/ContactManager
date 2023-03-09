using ContactManager.DAL.Entities;
using ContactManager.DAL.Persistence;
using ContactManager.DAL.Repositories.Interfaces;
using ContactManager.DAL.Repositories.Realizations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ContactManager.DAL.Repositories.Realizations;

public class ContactDataRepository : RepositoryBase<ContactData>, IContactDataRepository
{
    public ContactDataRepository(ContactManagerDbContext dbContext )
        : base(dbContext)
    {
    }
}
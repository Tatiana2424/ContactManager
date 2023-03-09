using ContactManager.DAL.Persistence;
using ContactManager.DAL.Repositories.Interfaces;
using ContactManager.DAL.Repositories.Interfaces.Base;

namespace ContactManager.DAL.Repositories.Realizations.Base;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly ContactManagerDbContext _contactManagerDbContext;

    private IContactDataRepository _contactDataRepository;

    public RepositoryWrapper(ContactManagerDbContext contactManagerDbContext)
    {
        _contactManagerDbContext = contactManagerDbContext;
    }

    public IContactDataRepository ContactDataRepository
    {
        get
        {
            if (_contactDataRepository is null)
            {
                _contactDataRepository = new ContactDataRepository(_contactManagerDbContext);
            }
            return _contactDataRepository;
        }
    }

    public int SaveChanges()
    {
        return _contactManagerDbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _contactManagerDbContext.SaveChangesAsync();
    }

}
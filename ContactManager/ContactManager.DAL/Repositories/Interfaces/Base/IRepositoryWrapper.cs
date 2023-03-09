namespace ContactManager.DAL.Repositories.Interfaces.Base;

public interface IRepositoryWrapper
{
    IContactDataRepository ContactDataRepository { get; }

    public int SaveChanges();

    public Task<int> SaveChangesAsync();
}
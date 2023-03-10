using ContactManager.DAL.Repositories.Interfaces.Base;
using FluentResults;
using MediatR;


namespace ContactManager.BLL.MediatR.ContactData.Delete;

public class DeleteContactDataHandler : IRequestHandler<DeleteContactDataCommand, Result<Unit>>
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public DeleteContactDataHandler(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<Result<Unit>> Handle(DeleteContactDataCommand request, CancellationToken cancellationToken)
    {
        var contactData = await _repositoryWrapper.ContactDataRepository.GetFirstOrDefaultAsync(f => f.Id == request.Id);

        if (contactData is null)
        {
            return Result.Fail(new Error($"Cannot find a fact with corresponding categoryId: {request.Id}"));
        }

        _repositoryWrapper.ContactDataRepository.Delete(contactData);

        var resultIsSuccess = await _repositoryWrapper.SaveChangesAsync() > 0;
        return resultIsSuccess ? Result.Ok(Unit.Value) : Result.Fail(new Error("Failed to delete a contactData"));
    }
}
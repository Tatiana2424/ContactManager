using AutoMapper;
using ContactManager.DAL.Repositories.Interfaces.Base;
using FluentResults;
using MediatR;


namespace ContactManager.BLL.MediatR.ContactData.Update;

public class UpdateContactDataHandler : IRequestHandler<UpdateContactDataCommand, Result<Unit>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public UpdateContactDataHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(UpdateContactDataCommand request, CancellationToken cancellationToken)
    {
        var contactData = _mapper.Map<ContactManager.DAL.Entities.ContactData>(request.ContactData);

        if (contactData is null)
        {
            return Result.Fail(new Error("Cannot convert null to contactData"));
        }

        _repositoryWrapper.ContactDataRepository.Update(contactData);

        var resultIsSuccess = await _repositoryWrapper.SaveChangesAsync() > 0;
        return resultIsSuccess ? Result.Ok(Unit.Value) : Result.Fail(new Error("Failed to update a contactData"));
    }
}
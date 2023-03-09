using AutoMapper;
using ContactManager.BLL.DTO;
using ContactManager.DAL.Repositories.Interfaces.Base;
using FluentResults;
using MediatR;

namespace ContactManager.BLL.MediatR.ContactData.GetAll;

public class GetAllContactDataHandler : IRequestHandler<GetAllContactDataQuery, Result<IEnumerable<ContactDataDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetAllContactDataHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<ContactDataDTO>>> Handle(GetAllContactDataQuery request, CancellationToken cancellationToken)
    {
        var contactData = await _repositoryWrapper
            .ContactDataRepository
            .GetAllAsync();

        if (contactData is null)
        {
            return Result.Fail(new Error($"Cannot find any contactData"));
        }

        var contactDataDtos = _mapper.Map<IEnumerable<ContactDataDTO>>(contactData);
        return Result.Ok(contactDataDtos);
    }
}

using AutoMapper;
using ContactManager.BLL.DTO;
using ContactManager.DAL.Repositories.Interfaces.Base;
using FluentResults;
using MediatR;


namespace ContactManager.BLL.MediatR.ContactData.GetById;

public class GetContactDataByIdHandler : IRequestHandler<GetContactDataByIdQuery, Result<ContactDataDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetContactDataByIdHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<ContactDataDTO>> Handle(GetContactDataByIdQuery request, CancellationToken cancellationToken)
    {
        var contactData = await _repositoryWrapper
            .ContactDataRepository
            .GetSingleOrDefaultAsync(c => c.Id == request.Id);

        if (contactData is null)
        {
            return Result.Fail(new Error($"Cannot find any contactData with corresponding id: {request.Id}"));
        }

        var contactDataDto = _mapper.Map<ContactDataDTO>(contactData);
        return Result.Ok(contactDataDto);
    }
}
using ContactManager.BLL.DTO;
using FluentResults;
using MediatR;

namespace ContactManager.BLL.MediatR.ContactData.GetAll;

public record GetAllContactDataQuery : IRequest<Result<IEnumerable<ContactDataDTO>>>;

using ContactManager.BLL.DTO;
using FluentResults;
using MediatR;


namespace ContactManager.BLL.MediatR.ContactData.Update;

public record UpdateContactDataCommand(ContactDataDTO ContactData) : IRequest<Result<Unit>>;
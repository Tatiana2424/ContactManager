using FluentResults;
using MediatR;

namespace ContactManager.BLL.MediatR.ContactData.Delete;

public record DeleteContactDataCommand(int Id) : IRequest<Result<Unit>>;
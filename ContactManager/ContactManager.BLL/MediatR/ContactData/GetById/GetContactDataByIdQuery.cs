using ContactManager.BLL.DTO;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.BLL.MediatR.ContactData.GetById;

public record GetContactDataByIdQuery(int Id) : IRequest<Result<ContactDataDTO>>;

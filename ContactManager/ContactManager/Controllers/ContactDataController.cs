using ContactManager.BLL.DTO;
using ContactManager.BLL.MediatR.ContactData.Delete;
using ContactManager.BLL.MediatR.ContactData.GetAll;
using ContactManager.BLL.MediatR.ContactData.GetById;
using ContactManager.BLL.MediatR.ContactData.Update;
using ContactManager.WebApi.Controllers.BaseController;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.WebApi.Controllers;

public class ContactDataController : BaseApiController
{
    private readonly IMediator _mediator;
    public ContactDataController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return HandleResult(await Mediator.Send(new GetAllContactDataQuery()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new GetContactDataByIdQuery(id)));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ContactDataDTO data)
    {
        data.Id = id;
        return HandleResult(await Mediator.Send(new UpdateContactDataCommand(data)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new DeleteContactDataCommand(id)));
    }
}

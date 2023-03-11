using ContactManager.BLL.DTO;
using ContactManager.BLL.MediatR.ContactData.Delete;
using ContactManager.BLL.MediatR.ContactData.GetAll;
using ContactManager.BLL.MediatR.ContactData.GetById;
using ContactManager.BLL.MediatR.ContactData.Update;
using ContactManager.DAL.Persistence;
using ContactManager.WebApi.Controllers.BaseController;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.WebApi.Controllers;

public class ContactDataController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly ContactManagerDbContext _dbContext;
    public ContactDataController(IMediator mediator, ContactManagerDbContext dbContext)
    {
        _mediator = mediator;
        _dbContext = dbContext;
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
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ContactDataDTO contactData)
    {
        contactData.Id = id;
        return HandleResult(await Mediator.Send(new UpdateContactDataCommand(contactData)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new DeleteContactDataCommand(id)));
    }
}

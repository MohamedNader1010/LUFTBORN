using LUFTBORN.Application.Users.Commands.CreateUser;
using LUFTBORN.Application.Users.Commands.DeleteUser;
using LUFTBORN.Application.Users.Commands.UpdateUser;
using LUFTBORN.Application.Users.Queries.GetUserById;
using LUFTBORN.Application.Users.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LUFTBORN.Api.Controllers;

[Route("api/[Controller]")]
public class UsersController(IMediator sender) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateUserCommand command)
    {
        var result = await sender.Send(command);

        return result.Match(
            id => Ok(id),
            Problem);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetUserByIdQuery(id);

        var result = await sender.Send(query);

        return result.Match(
            user => Ok(user),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetUsersQuery();

        var result = await sender.Send(query);

        return result.Match(
            users => Ok(users),
            Problem);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateUserCommand command)
    {
        if (id != command.UserId)
        {
            return BadRequest(
                "Route ID does not match UserId.");
        }

        var result = await sender.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {
        var command = new DeleteUserCommand(id);

        var result = await sender.Send(command);

        return result.Match(
            _ => NoContent(),
            Problem);
    }
}
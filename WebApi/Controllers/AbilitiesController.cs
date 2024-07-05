using Application.Features.Abilities.Commands.Create;
using Application.Features.Abilities.Commands.Kill;
using Application.Features.Abilities.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AbilitiesController : BaseController
{

    //943cf0dd-ceed-4b0b-ac01-57d7469e42a9
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdAbilityResponse response = await Mediator.Send(new GetByIdAbilityQuery { Id = id });
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAbilityCommand createAbilityCommand)
    {
        CreatedAbilityResponse response = await Mediator.Send(createAbilityCommand);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Kill([FromRoute]Guid id)
    {
        KilledAbilityResponse response = await Mediator.Send(new KillAbilityCommand { Id = id});
        return Ok(response);
    }

 


}

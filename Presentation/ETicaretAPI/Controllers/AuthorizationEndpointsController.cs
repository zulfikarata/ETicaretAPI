using ETicaretAPI.Application.Features.Commands.AuthorizationEndpoint.AssignRole;
using ETicaretAPI.Application.Features.Queries.AuthorizationEndpoints.GetRolesToEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationEndpointsController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthorizationEndpointsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("action")]
        public async Task<IActionResult> GetRolesToEndpoints(GetRolesToEndpointQueryRequest getRolesToEndpointRequest)
        {
            GetRolesToEndpointQueryResponse response = await _mediator.Send(getRolesToEndpointRequest);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> AssignRoleEndpoint( AssignRoleEndpointCommandRequest assignRoleEndpointCommandRequest )
        {
            assignRoleEndpointCommandRequest.Type = typeof(Program);
            AssignRoleEndpointCommandResponse response = await _mediator.Send(assignRoleEndpointCommandRequest);
            return Ok(response);
        }
    }
}

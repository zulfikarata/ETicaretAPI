﻿using MediatR;

namespace ETicaretAPI.Application.Features.Commands.AuthorizationEndpoint.AssignRole
{
    public class AssignRoleEndpointCommandRequest : IRequest<AssignRoleEndpointCommandResponse>
    {
        public string[] Roles { get; set; }
        public string Code { get; set; }
        public string Menu{ get; set; }
        public Type? Type { get; set; }
    }
}
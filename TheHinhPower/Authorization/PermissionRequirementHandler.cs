using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHinhPower.Service.Interfaces;

namespace TheHinhPower.Authorization
{
    public class PermissionRequirementHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IRoleService _roleService;
        IHttpContextAccessor httpContextAccessor;
        public PermissionRequirementHandler(IRoleService roleService, IHttpContextAccessor httpContextAccessor)
        {
            _roleService = roleService;
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var roles = (httpContextAccessor.HttpContext.User).Claims.FirstOrDefault(x => x.Type == "Roles");
            if (roles != null)
            {
                var listRole = roles.Value.Split(";");
                var hasPermission = await _roleService.CheckPermission(requirement.FunctionId, requirement.Action, listRole);
                if (hasPermission || listRole.Contains("Admin"))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
            else
            {
                context.Fail();
            }
        }
    }
}

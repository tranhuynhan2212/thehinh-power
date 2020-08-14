using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHinhPower.Authorization
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string FunctionId { get; }
        public string Action { get; }

        public PermissionRequirement(string functionId, string action)
        {
            FunctionId = functionId;
            Action = action;
        }
    }
}

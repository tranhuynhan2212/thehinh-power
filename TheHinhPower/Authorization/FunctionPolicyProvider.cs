using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHinhPower.Authorization
{
    internal class FunctionPolicyProvider //: IAuthorizationPolicyProvider
    {
        //const string POLICY_PREFIX = "Function";
        //public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

        //public FunctionPolicyProvider(IOptions<AuthorizationOptions> options)
        //{
        //    FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        //}

        //public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        //{
        //    return FallbackPolicyProvider.GetDefaultPolicyAsync();
        //}

        //public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        //{
        //    var functionId = "";
        //    var action = "";
        //    try
        //    {
        //        var permission = policyName.Substring(POLICY_PREFIX.Length).Split(",");
        //        functionId = permission.FirstOrDefault().Trim();
        //        action = permission.LastOrDefault().Trim();
        //    }
        //    catch (Exception)
        //    {

        //    }

        //    if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase))
        //    {
        //        var policy = new AuthorizationPolicyBuilder();
        //        policy.AddRequirements(new PermissionRequirement(functionId, action));
        //        return Task.FromResult(policy.Build());
        //    }

        //    return FallbackPolicyProvider.GetPolicyAsync(policyName);
        //}

        //public Task<AuthorizationPolicy> GetFallbackPolicyAsync()
        //{
        //    return FallbackPolicyProvider.GetFallbackPolicyAsync();
        //}
    }
}

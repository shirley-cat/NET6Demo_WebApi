using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;

namespace NET6Demo.Utility.Authorize
{
    public class Net6DemoAuthorizationMiddleware : IAuthorizationMiddlewareResultHandler
    {
        private readonly AuthorizationMiddlewareResultHandler defaultHandler = new();
        public async Task HandleAsync(
            RequestDelegate next,
            HttpContext context,
            AuthorizationPolicy policy,
            PolicyAuthorizationResult authorizeResult)
        {
            
            if (authorizeResult.Forbidden
                && authorizeResult.AuthorizationFailure!.FailedRequirements
                    .OfType<Show404Requirement>().Any())
            {
                // Return a 404 to make it appear as if the resource doesn't exist.

                throw new KeyNotFoundException();
            }
            
            throw new ApplicationException("Invalid token");
        }


    }
    public class Show404Requirement : IAuthorizationRequirement { }
}

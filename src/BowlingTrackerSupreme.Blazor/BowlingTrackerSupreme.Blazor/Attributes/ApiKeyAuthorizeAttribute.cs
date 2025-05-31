using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BowlingTrackerSupreme.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

public class ApiKeyAuthorizeAttribute : Attribute, IAsyncActionFilter
{
    private const string ApiKeyHeaderName = "X-Api-Key";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var potentialApiKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var dbContext = context.HttpContext.RequestServices.GetService(typeof(BowlingTrackerSupremeDbContext)) as BowlingTrackerSupremeDbContext;
        if (dbContext == null)
        {
            context.Result = new StatusCodeResult(500);
            return;
        }

        var exists = await dbContext.ApiKeySet.FirstOrDefaultAsync(k => k.Key == potentialApiKey);
        if (exists == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();
    }
}
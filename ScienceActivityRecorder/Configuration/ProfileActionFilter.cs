using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ScienceActivityRecorder.Providers;
using System.Threading.Tasks;

namespace ScienceActivityRecorder.Configuration
{
    public class ProfileActionFilter : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controller = context.Controller as Controller;
            if (controller == null)
            {
                await base.OnActionExecutionAsync(context, next);
                return;
            }

            var profileProvider = context.HttpContext.RequestServices.GetService(typeof(IProfileProvider)) as IProfileProvider;
            if (profileProvider == null)
            {
                await base.OnActionExecutionAsync(context, next);
                return;
            }

            var profile = await profileProvider.GetCurrentProfile(controller.User);
            if (profile == null)
            {
                await base.OnActionExecutionAsync(context, next);
                return;
            }

            controller.ViewBag.Profile = profile;
            await base.OnActionExecutionAsync(context, next);
        }
    }
}

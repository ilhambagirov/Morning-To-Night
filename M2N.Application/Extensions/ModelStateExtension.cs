using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace M2N.Application.Extensions
{
    public static class ModelStateExtension
    {
        static public ModelStateDictionary IsModelState(this IActionContextAccessor ctx)
        {
            return ctx.ActionContext.ModelState;
        }
    }
}

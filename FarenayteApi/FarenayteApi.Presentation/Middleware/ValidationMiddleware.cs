using FarenayteApi.Application.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace FarenayteApi.Presentation.Middleware
{
    public class ValidationMiddleware : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var jsonModelValidate = context.ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();

                MessageDTO message = new MessageDTO()
                {
                    Mensagem = string.Join(",", jsonModelValidate)
                };

                context.Result = new BadRequestObjectResult(message);
                return;
            }

            await next();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiProvaCSharp.Filters
{
    public class InvalidRequestFilter : ActionFilterAttribute
    {

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is BadRequestObjectResult badRequestObjectResult)
            {
                if (badRequestObjectResult.Value is ValidationProblemDetails)
                {

                    context.Result = new ObjectResult("Os valores informados n�o s�o v�lidos")
                    {
                        StatusCode = 412,
                    };
                }
            }

            base.OnResultExecuting(context);
        }

    }

}


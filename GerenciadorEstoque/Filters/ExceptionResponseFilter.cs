using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GerenciadorEstoque.Filters
{
    public class ExceptionResponseFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {

            if (context.Exception is not null)
            {
                context.Result = new ObjectResult("Ocorreu um erro desconhecido")
                {
                    StatusCode = 400,

                };
                context.ExceptionHandled = true;
            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
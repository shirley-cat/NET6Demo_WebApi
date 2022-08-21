using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NET6Demo.Utility.ApiResult
{
    public class ApiResultFilterAttribute : ActionFilterAttribute
    {
        private ResultHelper _result;

        public ApiResultFilterAttribute(ResultHelper result)
        {
            _result = result;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var objectResult = context.Result as ObjectResult;
            var code = objectResult != null ? objectResult.StatusCode : 500;           
            context.Result = _result.GetResult((int)code, string.Empty, objectResult.Value);


        }
    }
}

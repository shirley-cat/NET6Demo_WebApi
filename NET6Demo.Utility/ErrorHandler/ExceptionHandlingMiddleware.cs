using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NET6Demo.IRepository;
using System.Text.Json;

namespace NET6Demo.Utility.ErrorHandler
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;  // 用来处理上下文请求  
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private IResultModel errorResponse;
        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger,
            IResultModel result
           )
        {
            _next = next;
            _logger = logger;
            errorResponse = result;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext); //要么在中间件中处理，要么被传递到下一个中间件中去
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex); // 捕获异常了 在HandleExceptionAsync中处理
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //errorResponse = new ResultModel();

            _logger.LogError(exception.Message);
            context.Response.ContentType = "application/json";  // 返回json 类型

            var response = context.Response;

            switch (exception)
            {
                case ApplicationException ex:
                    if (ex.Message.Contains("Invalid token"))
                    {
                        response.StatusCode = errorResponse.StatusCode = StatusCodes.Status403Forbidden;
                        errorResponse.Message = "Invalid token";
                        break;
                    }

                    response.StatusCode = errorResponse.StatusCode = StatusCodes.Status400BadRequest;
                    errorResponse.Message = ex.Message;
                    break;

                case KeyNotFoundException ex:

                    response.StatusCode = errorResponse.StatusCode = StatusCodes.Status404NotFound;
                    errorResponse.Message = ex.Message;
                    break;
                default:
                    response.StatusCode = errorResponse.StatusCode = StatusCodes.Status500InternalServerError;
                    errorResponse.Message = "Internal Server errors. Check Logs!";
                    break;
            }
            _logger.LogError(exception.Message);
            var result = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(result);
        }
    }
}

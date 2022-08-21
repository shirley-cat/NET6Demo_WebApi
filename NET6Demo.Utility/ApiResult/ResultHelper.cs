using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NET6Demo.IRepository;

namespace NET6Demo.Utility.ApiResult
{
    public class ResultHelper
    {
        private readonly ILogger<ResultHelper> _logger;
        private IResultModel _result;
        public ResultHelper(ILogger<ResultHelper> logger, IResultModel result)
        {
            _logger = logger;
            _result = result;
        }

        public IActionResult GetResult(int code, string msg = null, object value = null)
        {
            _result.StatusCode = code;
            _result.Result = value;
            if (string.IsNullOrWhiteSpace(msg))
            {
                if (code > 199 && code < 299)
                {
                    _result.Message = "success";
                }
                else if (code > 399 && code < 499)
                {
                    _result.Message = "error";
                }
                else if (code > 499 && code < 599)
                {
                    _result.Message = "reject";
                }
            }

            ObjectResult objResult = new ObjectResult(_result);
            return objResult;
        }
    }
}

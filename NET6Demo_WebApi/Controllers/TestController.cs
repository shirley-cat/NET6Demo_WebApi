using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NET6Demo.IRepository;
using NET6Demo.IService;
using NET6Demo.Model;
using NET6Demo.Utility.Token;
using System.IdentityModel.Tokens.Jwt;

namespace NET6Demo_WebApi.Controllers
{
    public class TestController : BaseController
    {
        private ILogger<TestController> _logger;
        private readonly IServiceProvider _provider;        
        private IUserInfo _user;
        private JwtSecurityTokenHandler _jwtHandler;
        private TokenHelper _tokenHelper;
        private auth_dbContext _dbContext;

        public TestController(
            ILogger<TestController> logger,
            IServiceProvider provider,
            IUserInfo user,
            JwtSecurityTokenHandler jwtSecurityTokenHandler,
            TokenHelper tokenHelper,
            auth_dbContext authDbContext)
        {
            _logger = logger;
            _provider = provider;
            _user = user;
            _jwtHandler = jwtSecurityTokenHandler;
            _tokenHelper = tokenHelper;
            _dbContext = authDbContext;
        }

        [AllowAnonymous]
        [HttpGet("GetTest")]
        public async Task<IActionResult> GetTestResult(string userId)
        {
            Console.WriteLine("测试一下输出日志");
            _logger.LogInformation("日志输出了");
            _user = _provider.GetService<IUsers>().GetUser(userId);
            //throw new Exception("Test exception");
            //return Ok(_user);
            //return BadRequest();

            //return Ok(_tokenHelper.CreateJwtToken(_user));
            var user = _dbContext.Set<tb_info_user>().FirstOrDefault();
            return Ok(user);


        }

    }
}

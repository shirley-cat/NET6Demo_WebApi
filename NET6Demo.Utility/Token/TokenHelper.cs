using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NET6Demo.IRepository;
using CommonCode.JWT;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace NET6Demo.Utility.Token
{
    public class TokenHelper
    {
        private readonly IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly ILogger<TokenHelper> _logger;
        private ITokenModel _tokenModel;
        private IUserInfo _user;


        public TokenHelper(
            IConfiguration configuration,
            JwtSecurityTokenHandler jwtSecurityTokenHandler,
            ILogger<TokenHelper> logger,
            ITokenModel tokenModel

            //IUserInfo user
            )
        {
            _configuration = configuration;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
            _logger = logger;
            _tokenModel = tokenModel;

           // _user = user;
        }
        // <summary>
        /// 创建加密JwtToken
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string CreateJwtToken(IUserInfo user)
        {
            _user = user;
            // 从 appsettings.json 中读取配置
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

            _tokenModel.Expires = Convert.ToDouble(_configuration["JWT:Expires"]);
            _tokenModel.Issuer = _configuration["JWT:Issuer"];
            _tokenModel.Audience = _configuration["JWT:Audience"];

            return JwtHelper.CreateJwtToken(_user, _tokenModel, secretKey);
        }


        public IUserInfo GetToken(string Token)
        {
            return JwtHelper.GetToken<IUserInfo>(Token);
        }

        public bool VerTokenAsync(string Token)
        {
            return true;
        }
    }
}

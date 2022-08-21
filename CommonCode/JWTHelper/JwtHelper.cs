using CommonCode.Converts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;

namespace CommonCode.JWT
{
    /// <summary>
    /// 单例
    /// 用于产生Token和验证Token
    /// </summary>
    public class JwtHelper
    {
        private readonly static JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        /// <summary>
        /// 创建加密JwtToken
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string CreateJwtToken<T, U>(in T user,in U jwt, SymmetricSecurityKey secretKey)
        {
            IJwtModel jwtModel = ConvertTo.ConvertModel<U,JwtModel>(jwt);
            var claimList = CreateClaimList<T>(user);


            //  选择加密算法
            var algorithm = SecurityAlgorithms.HmacSha256;

            // 生成Credentials
            var signingCredentials = new SigningCredentials(secretKey, algorithm);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
               jwtModel.Issuer,     //Issuer
               jwtModel.Audience,   //Audience
               claims: claimList,
               DateTime.Now,                    //notBefore
               DateTime.Now.AddDays(jwtModel.Expires),   //expires
               signingCredentials               //Credentials
               );
            string jwtToken = _jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return jwtToken;
        }

        public static T GetToken<T>(string Token)
        {
            Type t = typeof(T);

            object objA = Activator.CreateInstance(t);
            var b = _jwtSecurityTokenHandler.ReadJwtToken(Token);
            foreach (var item in b.Claims)
            {
                PropertyInfo _Property = t.GetProperty(item.Type);
                if (_Property != null && _Property.CanRead)
                {
                    _Property.SetValue(objA, item.Value, null);
                }

            }
            return (T)objA;
        }


        /// <summary>
        /// 创建包含用户信息的CalimList
        /// </summary>
        /// <param name="authUser"></param>
        /// <returns></returns>
        private static List<Claim> CreateClaimList<T>(T authUser)
        {
            var Class = typeof(T);
            List<Claim> claimList = new List<Claim>();
            foreach (var item in Class.GetProperties())
            {
                claimList.Add(new Claim(item.Name, Convert.ToString(item.GetValue(authUser))));
            }
            return claimList;
        }


    }
}

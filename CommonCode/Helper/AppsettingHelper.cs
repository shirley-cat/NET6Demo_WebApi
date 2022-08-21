using Microsoft.Extensions.Configuration;

namespace CommonCode.Helper
{
    public class AppsettingHelper
    {
        private static IConfiguration _config;
        private static string _basePath;
        

        public AppsettingHelper(IConfiguration config)
        {
            _config = config;
            _basePath = AppContext.BaseDirectory;
        }


        public static string Get(string key, string settingFileName = "appsettings.json")
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }


            //引用Microsoft.Extensions.Configuration;
            var Configuration = new ConfigurationBuilder()
            .SetBasePath(_basePath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.test.json", true, reloadOnChange: true);

            var config = Configuration.Build();
            string value = config[key];

            return value;
        }

        /// <summary>
        /// 读取实体信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <returns></returns>
        public static List<T> Get<T>(params string[] session)
        {
            List<T> list = new List<T>();
            _config.Bind(string.Join(":", session), list);
            return list;
        }
    }
}

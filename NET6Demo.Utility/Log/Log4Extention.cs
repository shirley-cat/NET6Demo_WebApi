using Microsoft.Extensions.Logging;

namespace NET6Demo.Utility.Log
{
    public static class Log4Extention
    {
        public static void InitLog4(ILoggingBuilder loggingBuilder)
        {
            loggingBuilder.AddFilter("System", LogLevel.Warning);
            loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);//过滤掉系统默认的一些日志
            loggingBuilder.AddLog4Net(new Log4NetProviderOptions()
            {
                Log4NetConfigFileName = "Config/log4net.config",
                Watch = true
            });
        }
    }
}

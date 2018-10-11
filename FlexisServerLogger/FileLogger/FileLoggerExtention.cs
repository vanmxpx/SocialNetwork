using Microsoft.Extensions.Logging;

namespace FileLogger
{
    public static class FileLoggerExtensions
    {
        public static ILoggerFactory AddFileLogger(this ILoggerFactory factory, string filePath)
        {
            factory.AddProvider(new FileLoggerProvider(filePath));
            return factory;
        }
    }
}
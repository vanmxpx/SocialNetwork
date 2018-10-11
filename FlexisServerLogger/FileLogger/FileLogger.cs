using Microsoft.Extensions.Logging;
using System;
using System.IO;
 
namespace FileLogger
{
internal class FileLogger : ILogger
    {
        private string filePath;
        private object _lock = new object();
        public FileLogger(string path)
        {
            filePath = path;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
 
        public bool IsEnabled(LogLevel logLevel)
        {
            //return logLevel == LogLevel.Trace;
            return true;
        }
 
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    File.AppendAllText(filePath, DateTime.Now +": "+ DateTime.Now.Millisecond + ": " +  formatter(state, exception) + Environment.NewLine);
                }
            }
        }
    }
}
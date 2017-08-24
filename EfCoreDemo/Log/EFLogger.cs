using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EfCoreDemo.Log
{
    public class EfLogger : ILogger
    {
        private readonly string categoryName;

        public EfLogger(string categoryName) => this.categoryName = categoryName;

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {

            Debug.WriteLine($"时间:{DateTime.Now.ToString("o")} 日志级别: {logLevel} {eventId.Id} 产生的类{this.categoryName}");
            //DbCommandLogData data = state as DbCommandLogData;
            //Debug.WriteLine($"SQL语句:{data.CommandText},\n 执行消耗时间:{data.ElapsedMilliseconds}");

        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}

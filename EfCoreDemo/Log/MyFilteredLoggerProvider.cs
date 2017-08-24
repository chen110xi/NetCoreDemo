using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;

namespace EfCoreDemo.Log
{
    public class MyFilteredLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            // NOTE: 这里要注意,这是 EF Core 1.1的使用方式,如果你用的 EF Core 1.0, 就需把IRelationalCommandBuilderFactory替换成下面的类
            //       Microsoft.EntityFrameworkCore.Storage.Internal.RelationalCommandBuilderFactory
            /* */  //1.1.0

            //Microsoft.EntityFrameworkCore.DbLoggerCategory

            if (categoryName == typeof(IRelationalCommandBuilderFactory).FullName)
            {
                return new EfLogger(categoryName);
            }
            return NullLogger.Instance;
        }
        public void Dispose()
        { }
    }
}

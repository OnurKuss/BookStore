using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string Message)
        {
            Console.WriteLine("[ConsoleLogger] - " + Message);
        }
    }
}

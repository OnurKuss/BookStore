using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class DbLogger : ILoggerService
    {
        public void Write(string Message)
        {
            Console.WriteLine("[DbLogger] - " + Message);
        }
    }
}

using Dependency_Injection.Services.Interfaces;
using System;

namespace Dependency_Injection.Services
{
    public class ConsoleLog :ILog
    {
        public ConsoleLog(int x)
        {

        }

        public void Log()
        {
            Console.WriteLine("Console'a loglama işlemi gerçekleştirildi.");
        }
    }
}

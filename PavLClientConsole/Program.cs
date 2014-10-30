using PavL.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavLClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var logHandler = new LogHandler();

            logHandler.Listen(s => Console.WriteLine(s));

            Console.WriteLine("Press Any Key to Continue");
            Console.ReadKey();
        }
    }
}

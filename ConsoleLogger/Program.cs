using PavL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sender");

            string message = String.Empty;
            do
            {
                message = Console.ReadLine();
                // Sends a message to the host to which you have connected.
                Logger.Log(message, "");

            } while (message != String.Empty);



            Console.WriteLine("Press Any Key to Continue");
            Console.ReadKey();

        }
    }
}

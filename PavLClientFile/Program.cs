using PavL.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavLClientFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\MyTest.log";

            if (!File.Exists(path))
            {
                // Create a file to write to. 
                string createText = "Log File" + Environment.NewLine;
                File.WriteAllText(path, createText);
            }


            var logHandler = new LogHandler();

            logHandler.Listen(s => File.AppendAllText(path, String.Format("{0}{1}", s, Environment.NewLine)));

            Console.WriteLine("Press Any Key to Continue");
            Console.ReadKey();
        }
    }
}

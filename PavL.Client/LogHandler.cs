using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavL.Client
{
    public class LogHandler
    {
        private UdpListener listener;

        public LogHandler()
        {
            listener = new UdpListener("239.0.0.222", 11000);
        }

        public void Listen(Action<string> action)
        {
            listener.Listen(action);
        }
    }
}

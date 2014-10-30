using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavL
{
    public class Logger
    {
        private static UdpBroadcaster _broadcaster;
        public static UdpBroadcaster Broadcaster
        {
            get
            {
                if(_broadcaster == null)
                {
                    _broadcaster = new UdpBroadcaster("239.0.0.222", 11000);
                }
                return _broadcaster;
            }
        }

        // TODO: change this to take a log item as a param
        public static void Log(string summary, string description)
        {
            Broadcaster.SendMessage(summary);
        }
    }
}

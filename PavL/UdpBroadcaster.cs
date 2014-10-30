using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PavL
{
    public class UdpBroadcaster : IDisposable
    {
        private IPAddress broadcastIpAddress;
        private UdpClient udpClient;
        private IPEndPoint broadcastIpEndpoint;

        public UdpBroadcaster(string ipAddress, int port)
        {
            this.broadcastIpAddress = IPAddress.Parse(ipAddress);
            this.broadcastIpEndpoint = new IPEndPoint(broadcastIpAddress, port);

            this.udpClient = new UdpClient();
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpClient.JoinMulticastGroup(broadcastIpAddress);
        }

        public void SendMessage(string summary)
        {
            Byte[] sendBytes = Encoding.ASCII.GetBytes(summary);

            udpClient.Send(sendBytes, sendBytes.Length, this.broadcastIpEndpoint);
        }

        public void Dispose()
        {
            udpClient.Close();
        }
    }
}

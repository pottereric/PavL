using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PavL.Client
{
    class UdpListener : IDisposable
    {
        // todo generate an event to raise when something is received or take a lambda

        private IPAddress broadcastIpAddress;
        private UdpClient udpClient;
        private IPEndPoint broadcastIpEndpoint;

        public UdpListener(string ipAddress, int port)
        {
            this.broadcastIpAddress = IPAddress.Parse(ipAddress);
            this.broadcastIpEndpoint = new IPEndPoint(broadcastIpAddress, port);

            this.udpClient = new UdpClient();
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 11000));

            udpClient.JoinMulticastGroup(broadcastIpAddress);
        }

        public void Listen(Action<string> action)
        {
        // todo generate an event to raise when something is received or take a lambda
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            string message = String.Empty;
            do
            {

                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                message = Encoding.ASCII.GetString(receiveBytes);

                action(message);

                //// Uses the IPEndPoint object to determine which of these two hosts responded.
                //Console.WriteLine("This is the message you received: " +
                //                             message);
                //Console.WriteLine("This message was sent from " +
                //                            RemoteIpEndPoint.Address.ToString() +
                //                            " on their port number " +
                //                            RemoteIpEndPoint.Port.ToString());
            }
            while (message != "exit");
        }

        public void Dispose()
        {
            udpClient.Close();
        }
    }
}

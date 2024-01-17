using System.Net.Sockets;
using System.IO;
using ServerData;
using System.Net;

namespace BooksTCP
{
    internal class Program
    {
        static Socket listenerSocket;
        static List<ClientData> _clients;
        static void Main(string[] args)
        {
            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //create socket
            _clients = new List<ClientData>(); //create the clients list

            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(Packet.GetIP4Address()), 4242); //create IP endpoint with our ip

            listenerSocket.Bind(ip); //bind the local ip to our socket

            Thread listenThread = new Thread(ListenThread);
            listenThread.Start();

        }

        static void ListenThread()
        {
            for (; ; )
            {
                listenerSocket.Listen();
                _clients.Add(new ClientData(listenerSocket.Accept()));
            }

        }

    }
}
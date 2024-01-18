using System.Net.Sockets;
using System.IO;
using ServerData;
using System.Net;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;

namespace BooksTCP
{
    class Server
    {
        static Socket listenerSocket;
        static List<ClientData> _clients;
        static void Main(string[] args)
        {
            Console.WriteLine("Starting server on " + Packet.GetIP4Address());  
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

        public static void Data_IN(object cSocket)//receive data from client
        {
            Socket clientSocket = (Socket)cSocket;
            byte[] Buffer;
            int readBytes;

            for(; ; )
            {
                Buffer = new byte[clientSocket.SendBufferSize];
                readBytes = clientSocket.Receive(Buffer);

                if (readBytes > 0)
                {
                    Packet packet = new Packet(Buffer);
                    DataManager(packet);
                }
            }

        }

        public static void DataManager(Packet p)
        {

        }

    }
}
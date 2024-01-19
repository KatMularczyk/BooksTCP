using System.Net.Sockets;
using System.IO;
using ServerData;
using System.Net;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using static System.Reflection.Metadata.BlobBuilder;

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
            JsonReader r = new JsonReader("C:\\Users\\lenovo\\source\\repos\\BooksTCP\\server\\books.json");
            List<Books> b = new List<Books>();
            b = r.listCreator();
            foreach (Books book in b) 
            { 
                book.printBookData();
            }

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
            byte[] data;
            int readBytes;

            for(; ; )
            {
                // Buffer to store the response bytes.
                data = new Byte[786];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                readBytes = clientSocket.Receive(data); //(**This receives the data using the byte method**)
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, readBytes); //(**This converts it to string**)
                
                

                /*if (readBytes > 0)
                {
                    Console.WriteLine(responseData);
                    Console.WriteLine(readBytes);
                    *//*Packet packet = new Packet(Buffer);
                    DataManager(packet);*//*
                }*/
            }

        }

        /*public static void DataManager(string responseData)
        {

        }*/

    }
}
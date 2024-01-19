using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using static System.Reflection.Metadata.BlobBuilder;

namespace BooksTCP
{
    
    class Server
    {
        static List<Books> b = new List<Books>();
        static Socket listenerSocket;
        static List<ClientData> _clients;
        static void Main(string[] args)
        {
            Console.WriteLine("Starting server on " + GetIP4Address());  
            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //create socket
            _clients = new List<ClientData>(); //create the clients list

            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(GetIP4Address()), 4242); //create IP endpoint with our ip

            listenerSocket.Bind(ip); //bind the local ip to our socket

            Thread listenThread = new Thread(ListenThread);
            listenThread.Start();
            JsonReader r = new JsonReader("C:\\Users\\lenovo\\source\\repos\\BooksTCP\\server\\books.json");
            
            b = r.listCreator();
            foreach (Books book in b) 
            { 
                book.printBookData();
            }
            

            string x = Books.DataManager("The Desert Spear\nPeter V. Brett\nFantasy", b);
            Console.WriteLine(x);
        }

        static void ListenThread()
        {
            for (; ; )
            {
                listenerSocket.Listen();
                _clients.Add(new ClientData(listenerSocket.Accept()));
            }

        }

        public static string GetIP4Address()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress ip in ips)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "127.0.0.1";
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
                
                

                if (readBytes > 0)
                {
                    Console.WriteLine(responseData);
                    Console.WriteLine(readBytes);
                    

                    
                }
            }

        }

        

    }
}
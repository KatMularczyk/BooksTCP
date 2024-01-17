using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BooksTCP
{
    internal class ClientData
    {
        public Socket clientSocket;
        public Thread clientThread;
        public string id;

        public ClientData()
        {
            id = Guid.NewGuid().ToString();
        }

        public ClientData(Socket clientSocket)
        {
            id = Guid.NewGuid().ToString();
            this.clientSocket = clientSocket;
        }

    }
}

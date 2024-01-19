using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BooksTCP
{
    class ClientData
    {
        public Socket clientSocket;
        public Thread clientThread;
        public string id;

        public ClientData()
        {
            id = Guid.NewGuid().ToString();
            clientThread = new Thread(Server.Data_IN);
            clientThread.Start(clientSocket);
        }

        public ClientData(Socket clientSocket)
        {
            id = Guid.NewGuid().ToString();
            this.clientSocket = clientSocket;
            clientThread = new Thread(Server.Data_IN);
            clientThread.Start(clientSocket);
        }

        /*public void SendRegistrationPacket()
        {
            Packet p = new Packet(PacketType.Registration, "server");
            clientSocket.Send(p.ToBytes());//sends a connection confirmation, not sure how will work with C-based client 
            p.gData.Add(id);
        }*/

    }
}

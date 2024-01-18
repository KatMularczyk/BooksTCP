using System.Text;
using System.Threading.Tasks;
using System.IO;
using ServerData;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ServerData
{
    [Serializable]
    public class Packet
    {
        public List<string> gData;
        public int packetInt;
        public bool packetBool;
        public string senderID;
        public PacketType packetType;

        public Packet(PacketType type, string senderID) 
        {
            gData = new List<string>();
            this.senderID = senderID;
            this.packetType = type;

        }

        public Packet(byte[] packetbytes)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            Packet p = (Packet)bf.Deserialize(ms);
            ms.Close();
            this.gData = p.gData;
            this.packetInt = p.packetInt;
            this.packetBool = p.packetBool;
            this.senderID = p.senderID;
            this.packetType = p.packetType;

        }



        public byte[] ToBytes()//changes the object into bytes array
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            bf.Serialize(ms, this);
            byte[] bytes = ms.ToArray();
            ms.Close();
            return bytes;

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

        }
    public enum PacketType
    {
        Registration
    }
}
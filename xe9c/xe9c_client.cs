using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace xe9c;

public class Xe9c_client
{
    private string _clientName = "None";
    private string _ip = "0.0.0.0";
    private int _port = 0;

    public string ClientName 
    {
        get => _clientName;
        private set { if (value != null) _clientName = value; }
    }
    public string IP
    {
        get => _ip;
        private set { if (value != null) _ip = value;}
    }
    public int Port
    {
        get => _port;
        private set { if (value != null) _port = value; }
    }

    public Xe9c_client() { }

    public Xe9c_client(string clientName, string ip, int port)
    {
        _clientName = clientName;
        _ip = ip;
        _port = port;
    }

    public string ConnectionInfo()
    {
        return $"### CONNECTION INFO ###\n\nName: {_clientName}\nIP: {_ip}\nPort: {_port}";
    }

    private Socket _connectToGateway()
    {
        IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(_ip), _port);
        Socket __socket = new Socket(
            AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        __socket.Connect(ipEndPoint);
        
        return __socket;
    }

    private string ReceiveMsg(Socket __socket)
    {
        byte[] getMsgLength = new byte[1];
        __socket.Receive(getMsgLength);
        byte[] getMsg = new byte[getMsgLength[0]];
        __socket.Receive(getMsg);

        return Encoding.UTF8.GetString(getMsg);
    }

    private void SendMsg(Socket __socket)
    {
        string message = Console.ReadLine();
        byte[] getMsgLength = BitConverter.GetBytes(message.Length);
        byte[] getMsg = Encoding.UTF8.GetBytes(message);
        __socket.Send(getMsgLength);
        __socket.Send(getMsg);
    }
}

using System.Net.Sockets;

namespace xe9c;

internal class Program
{
    static void Main(string[] args)
    {
        Xe9c_client x = new(args[0], args[1], int.Parse(args[2]));
        Console.WriteLine(x.ConnectionInfo());
        Socket serverSocket = x.ConnectToGateway();
        Console.WriteLine("Connected!");
        Task.Run(() => x.ReceiveMsg(serverSocket));
        while (true)
        {
            Console.Write($"{x.ClientName}> ");
            string msg = Console.ReadLine();
            x.SendMsg(serverSocket, $"{x.ClientName}> {msg}");
        }
    }
}
//  0      1          2      3
// xe9c clientName 0.0.0.0 5555
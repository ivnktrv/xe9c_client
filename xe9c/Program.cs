namespace xe9c;

internal class Program
{
    static void Main(string[] args)
    {
        Xe9c_client x = new("PC", "1.1.1.1", 5555);
        Console.WriteLine(x.ConnectionInfo());
    }
}

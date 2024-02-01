using System.Net;
using System.Net.Sockets;
using System.Text;
class Servidor
{
    static TcpListener server;
    static TcpClient client;

    public void Iniciar()
    {
        server = new TcpListener(IPAddress.Any, 1234);
        server.Start();

        Console.WriteLine("Servidor esperando conexiones...");

        client = server.AcceptTcpClient();
        Console.WriteLine("Cliente conectado.");

        Thread receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.Start();

        while (true)
        {
            string message = Console.ReadLine();
            SendMessage(message);
        }
    }

    static void ReceiveData()
    {
        while (true)
        {
            try
            {
                byte[] buffer = new byte[1024];
                NetworkStream stream = client.GetStream();
                stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.ASCII.GetString(buffer);
                Console.WriteLine("Cliente: " + message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                break;
            }
        }
    }

    static void SendMessage(string message)
    {
        try
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
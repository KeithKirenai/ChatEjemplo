using System.Net.Sockets;
using System.Text;
class Cliente
{
    static TcpClient client;

    public void Iniciar()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Ingresa la dirección IP del servidor:");
        Console.ResetColor();

        string serverIp = Console.ReadLine();

        client = new TcpClient(serverIp, 1234);

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
                Console.WriteLine("Servidor: " + message);
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

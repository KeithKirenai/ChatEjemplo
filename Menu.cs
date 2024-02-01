class Start
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("   _____ _                             _____              _ ");
        Console.WriteLine("  / ____| |                           / ____|            | |");
        Console.WriteLine(" | (___ | |__   __ _ _ __ _ __ ______| |     ___  _ __ __| |");
        Console.WriteLine("  \\___ \\| '_ \\ / _` | '__| '_ \\______| |    / _ \\| '__/ _` |");
        Console.WriteLine("  ____) | | | | (_| | |  | |_) |     | |___| (_) | | | (_| |");
        Console.WriteLine(" |_____/|_| |_|\\__,_|_|  | .__/       \\_____\\___/|_|  \\__,_|");
        Console.WriteLine("                         | |                                 ");
        Console.WriteLine("                         |_|                                 ");
        Console.ResetColor();
        Thread.Sleep(1000);

        Opcion Opcion = new Opcion();
        
        Opcion.ElegirOpcion();
    }
}


class Opcion
{
    public void ElegirOpcion()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Seleccione el modo (1 para servidor, 2 para cliente):");
        Console.ResetColor();
        string modo = Console.ReadLine();

        OpcionChat OpcionChat = new OpcionChat();

        if (modo == "1")
        {
            OpcionChat.IniciarServidor();
        }
        else if (modo == "2")
        {
            OpcionChat.IniciarCliente();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Modo no válido.");
            Console.ResetColor();
        }
    }
}

class OpcionChat
{
    public void IniciarServidor()
    {
        // Lógica de inicialización del servidor
        Servidor servidor = new Servidor();
        servidor.Iniciar();
    }

    public void IniciarCliente()
    {
        // Lógica de inicialización del cliente
        Cliente cliente = new Cliente();
        cliente.Iniciar();
    }
}

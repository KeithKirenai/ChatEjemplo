using System;
using System.Media;
using System.Threading;
class Start
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        string[] logoLines = {
            "   _____ _                             _____              _ ",
            "  / ____| |                           / ____|            | |",
            " | (___ | |__   __ _ _ __ _ __ ______| |     ___  _ __ __| |",
            "  \\___ \\| '_ \\ / _` | '__| '_ \\______| |    / _ \\| '__/ _` |",
            "  ____) | | | | (_| | |  | |_) |     | |___| (_) | | | (_| |",
            " |_____/|_| |_|\\__,_|_|  | .__/       \\_____\\___/|_|  \\__,_|",
            "                         | |                                 ",
            "                         |_|                                 "
        };

        // Calculate the center position for the text
        int consoleWidth = Console.WindowWidth;
        int consoleHeight = Console.WindowHeight;
        int centerX = (consoleWidth - logoLines[0].Length) / 2;
        int centerY = (consoleHeight - logoLines.Length) / 2;

        // Print each line of the logo centered
        foreach (string line in logoLines)
        {
            Console.SetCursorPosition(centerX, centerY++);
            Thread.Sleep(100);
            Console.WriteLine(line);
        }

        Console.ResetColor();
        Thread.Sleep(1000);

        Opcion Opcion = new Opcion();
        Opcion.ElegirOpcion();
    }
}


class Opcion
{

    private int seleccion = 1;

    public void ElegirOpcion()
    {
        ConsoleKeyInfo key;
        do
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Seleccione el modo:");
            Console.ResetColor();

            Console.WriteLine(seleccion == 1 ? "-> Servidor" : "   Servidor");
            Console.WriteLine(seleccion == 2 ? "-> Cliente" : "   Cliente");

            key = Console.ReadKey();

            if (key.Key == ConsoleKey.UpArrow && seleccion > 1)
            {
                seleccion--;
            }
            else if (key.Key == ConsoleKey.DownArrow && seleccion < 2)
            {
                seleccion++;
            }
        } while (key.Key != ConsoleKey.Enter);

        OpcionChat OpcionChat = new OpcionChat();

        if (seleccion == 1)
        {
            OpcionChat.IniciarServidor();
        }
        else if (seleccion == 2)
        {
            OpcionChat.IniciarCliente();
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

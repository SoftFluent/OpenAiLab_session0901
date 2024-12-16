namespace OpenAi.PoweredChatbot.ConsoleApp;

public static class ConsoleHelper
{
    public static void WriteAsChatbot(string message)
        => WriteLine($">>   {message}", ConsoleColor.Cyan);

    public static void WriteAsIntro(string message)
        => WriteLine(message, ConsoleColor.Yellow);

    public static void WriteAsError(string message)
        => WriteLine(message, ConsoleColor.Red);

    public static void WriteLine(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.WriteLine();
        Console.ResetColor();
    }
}

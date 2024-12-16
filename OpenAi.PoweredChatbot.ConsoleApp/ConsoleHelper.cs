namespace OpenAi.PoweredChatbot.ConsoleApp;

public static class ConsoleHelper
{
    public static void WriteAsChatbot(string message)
        => WriteLine($">>   {message}", ConsoleColor.Cyan);

    public static void WriteAsIntro(string message)
        => WriteLine(message, ConsoleColor.Yellow, false);

    public static void WriteAsError(string message)
        => WriteLine(message, ConsoleColor.Red, false);

    public static void WriteLine(string message, ConsoleColor color, bool withSeparationLine = true)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        if (withSeparationLine)
        {
            Console.WriteLine();
        }

        Console.ResetColor();
    }
}

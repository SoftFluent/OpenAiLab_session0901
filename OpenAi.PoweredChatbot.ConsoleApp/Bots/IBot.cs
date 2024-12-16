namespace OpenAi.PoweredChatbot.ConsoleApp.Bots;
internal interface IBot
{
    string Name { get; }

    void InitBot();

    string? CompleteChat(string? userMessage);
}
using System.ClientModel;
using OpenAI.Chat;

namespace OpenAi.PoweredChatbot.ConsoleApp;
internal interface IBot
{
    ChatClient Client { get; }

    string Name { get; }

    void InitBot();
    string? CompleteChat(string? userMessage);
}
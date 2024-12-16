using System.ClientModel;
using OpenAI.Chat;

namespace OpenAi.PoweredChatbot.ConsoleApp.Bots;
internal class Dumblebot(ChatClient client) : IBot
{
    public List<ChatMessage> Messages { get; } = [];

    public ChatClient Client { get; } = client;

    public ChatCompletionOptions Options { get; } = new ChatCompletionOptions { Temperature = 0.7f };

    public string Name => nameof(Dumblebot);

    public void InitBot()
    {
        // Ajouter les instructions pour que votre bot puisse proposer
        // de nouveaux sorts magiques de l'univers Harry Potter.
        // Nom du sort, mouvement à faire avec la baguette, effet du sort, etc.
        Messages.Add(new SystemChatMessage(""));
    }

    public string? CompleteChat(string? userMessage)
    {
        Messages.Add(new UserChatMessage(userMessage));
        ClientResult<ChatCompletion> result = Client.CompleteChat(Messages, Options);
        return result.Value?.Content[0]?.Text;
    }
}
